using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;

using LibExtMethods;
using OxyPlot;

namespace SharpSmartMathLib
{
    public static class DynamicCompile
    {
        public static List<string> VirtualConsoleOutput = new List<string>();
        public static List<string> VirtualConsoleErrorsOutput = new List<string>();
        public static PlotModel VirtualPlotModel = new PlotModel();

        public const string Template_CodeString = "#pragma CODE_WILL_BE_PASTED_HERE";
        public static string CodeTemplate =
        #region CodeTemplate
        @"
        using System;
        using System.Collections.Generic;
        using System.Globalization;
        using System.Threading;
        
        using ExtMethods;
        using OpenToolkit.Mathematics;
        using static ShaderMath;
        
        static class Program
        {
            public static object Execute()
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; // For fix parsing values like '0.5' and '0,5'
#pragma warning disable 1633
" + Template_CodeString + @";
#pragma warning restore 1633
                return ""EMPTY_STRING_FOR_LAST_RETURN_SEGMENT_DONT_USE_IT_DIRECTLY"";
            }
        }";
        #endregion
        
        public static string GetCodeTemplate(string Code, bool ReplaceInstructions = true)
        {
            Code = CodeTemplate.Replace(Template_CodeString, Code);
            if (ReplaceInstructions)
                Code = Regex.Replace(Code, @"\b(discard|abort)\b", "return \"EMPTY_STRING_FOR_LAST_RETURN_SEGMENT_DONT_USE_IT_DIRECTLY\";");
            return Code;
        }

        public static string GetErrorLine(Diagnostic error)
        {
            LinePosition ErrorLine = error.Location.GetLineSpan().StartLinePosition;

            // Get Code line position ("#line 1" not working!)
            try
            {
                int CodePos = CodeTemplate.IndexOf(Template_CodeString);
                if (CodePos >= 0)
                {
                    int LinesBeforeCode = CodeTemplate.Substring(0, CodePos).CountStringOccurrences(Environment.NewLine);
                    ErrorLine = new LinePosition(ErrorLine.Line - LinesBeforeCode + 1, ErrorLine.Character + 1);
                }
            }
            catch { }
            return String.Format("{0} [{1}]: {2}", error.Id, ErrorLine, error.GetMessage());
        }

        public static MetadataReference[] GetMetadataReferences()
        {
            return new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
                MetadataReference.CreateFromFile(Assembly.Load("netstandard, Version=2.0.0.0").Location),
                MetadataReference.CreateFromFile(typeof(DynamicCompile).Assembly.Location)
            };
        }

        public static bool CompileCode(string Code, out string Result)
        {
            Result = String.Empty;

            try
            {
                CSharpCompilation compilation = CSharpCompilation.Create(
                   assemblyName: Path.GetRandomFileName(),
                   syntaxTrees: new[] { CSharpSyntaxTree.ParseText(GetCodeTemplate(Code)) },
                   references: GetMetadataReferences(),
                   options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                );


                using (var ms = new MemoryStream())
                {
                    EmitResult result = compilation.Emit(ms);

                    if (!result.Success)
                    {
                        if (!Code.Contains("return"))
                        {
                            compilation = compilation.RemoveAllSyntaxTrees();
                            compilation = compilation.AddSyntaxTrees(CSharpSyntaxTree.ParseText(GetCodeTemplate("return " + Code)));
                        }

                        EmitResult result_return = compilation.Emit(ms);

                        if (!result_return.Success)
                        {
                            IEnumerable<Diagnostic> Errors = result.Diagnostics.Where(diag => diag.IsWarningAsError || diag.Severity == DiagnosticSeverity.Error);
                            IEnumerable<string> ErrorStrings = Errors.Select((error, index) => GetErrorLine(error));
                            Result = string.Join(Environment.NewLine, ErrorStrings);
                            return false;
                        }
                        else
                            result = result_return;
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    Assembly assembly = Assembly.Load(ms.ToArray());

                    VirtualConsoleErrorsOutput.Clear();
                    VirtualConsoleOutput.Clear();
                    VirtualPlotModel.Series.Clear();

                    Type type_program = assembly.GetType("Program");
                    MethodInfo method_info = type_program.GetMethod("Execute");

                    object obj = null;
                    try
                    {
                        obj = method_info.Invoke(null, null);
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException != null)
                            VirtualConsoleErrorsOutput.Add(ex.InnerException.Message);
                    }
                    Result = (obj == null ? "'null'" : obj.ToString());

                    if (VirtualConsoleErrorsOutput.Count > 0)
                    {
                        Result = string.Join(Environment.NewLine, VirtualConsoleErrorsOutput);
                        return false;
                    }

                    if (obj?.GetType() == typeof(string))
                    {
                        if (Result != "EMPTY_STRING_FOR_LAST_RETURN_SEGMENT_DONT_USE_IT_DIRECTLY")
                        {
                            Result = "\"" + Result + "\"";
                            VirtualConsoleOutput.Add(Result);
                        }
                    }
                    else
                        VirtualConsoleOutput.Add(Result);

                    Result = string.Join(Environment.NewLine, VirtualConsoleOutput);
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }
    }
}