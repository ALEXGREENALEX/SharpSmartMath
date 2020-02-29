using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.Text;
using SharpSmartMathLib;

namespace SharpSmartMath
{
    public class CodeHelper
    {
        public static IEnumerable<ClassifiedSpan> ClassifiedSpans;
        public static int CodeAutocompletion_AlreadyEnteredStrLen;

        public static string FormatCode(string Code)
        {
            string FullCode = DynamicCompile.GetCodeTemplate(Code, false);

            Workspace workspace = new AdhocWorkspace();
            Solution solution = workspace.CurrentSolution;
            Project project = solution.AddProject("SharpSmartMath", "SharpSmartMath", LanguageNames.CSharp);

            Document DocumentTemplate = project.AddDocument("SharpSmartMath.cs", DynamicCompile.CodeTemplate);
            string FormattedTemplate = Formatter.FormatAsync(DocumentTemplate).Result.GetTextAsync().Result.ToString();

            Document DocumentCode = project.AddDocument("SharpSmartMath.cs", FullCode);
            string FormattedCode = Formatter.FormatAsync(DocumentCode).Result.GetTextAsync().Result.ToString();

            int CodeStartPos = FormattedTemplate.IndexOf(DynamicCompile.Template_CodeString);
            int CodeEndLen = FormattedTemplate.Length - CodeStartPos - DynamicCompile.Template_CodeString.Length;
            FormattedCode = FormattedCode.Remove(FormattedCode.Length - CodeEndLen, CodeEndLen).Remove(0, CodeStartPos);

            string[] Lines = FormattedCode.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int SpacesCount = Lines.Min(str => str.Length > 0 ? str.Length - str.TrimStart().Length : int.MaxValue);
            return string.Join(Environment.NewLine, Lines.Select(str => str.Remove(0, Math.Min(SpacesCount, str.Length))));
        }

        public static void GetCodeHighlighting(string Code)
        {
            try
            {
                Workspace workspace = new AdhocWorkspace();
                Solution solution = workspace.CurrentSolution;
                Project project = solution.AddProject("SharpSmartMath", "SharpSmartMath", LanguageNames.CSharp);
                Document document = project.AddDocument("SharpSmartMath.cs", Code);
                SourceText SourceCode = document.GetTextAsync().Result;
                ClassifiedSpans = Classifier.GetClassifiedSpansAsync(document, TextSpan.FromBounds(0, SourceCode.Length)).Result;
            }
            catch { }
        }

        public static IEnumerable<string> GetCodeAutocompletionList(string Code, int CarretPosition)
        {
            CodeAutocompletion_AlreadyEnteredStrLen = 0;
            string FullCode = DynamicCompile.GetCodeTemplate(Code, false);

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(FullCode);
            CSharpCompilation compilation = CSharpCompilation.Create("SharpSmartMath.cs").AddReferences(DynamicCompile.GetMetadataReferences()).AddSyntaxTrees(syntaxTree);
            SemanticModel semanticModel = compilation.GetSemanticModel(syntaxTree);

            int TemplateOffset = DynamicCompile.CodeTemplate.IndexOf(DynamicCompile.Template_CodeString);
            Match match = Regex.Match(Code.Substring(0, CarretPosition), @"\S*", RegexOptions.RightToLeft);
            if (!match.Success || match.Length <= 0 || match.Index + match.Length < CarretPosition)
                return null;

            TextSpan MatchSpan = new TextSpan(TemplateOffset + match.Index, match.Length);
            SyntaxNode syntaxNode = syntaxTree.GetRoot().DescendantNodes(MatchSpan).Where(s => !(s is IdentifierNameSyntax)).Last();

            if (syntaxNode is MemberAccessExpressionSyntax)
            {
                MemberAccessExpressionSyntax memberAccessNode = (MemberAccessExpressionSyntax)syntaxNode;
                ITypeSymbol lhsType = semanticModel.GetTypeInfo(memberAccessNode.Expression).Type;
                IEnumerable<string> WordsList = lhsType.GetMembers().Where(
                    s => s.CanBeReferencedByName &&
                    s.DeclaredAccessibility == Accessibility.Public &&
                    s.Name.StartsWith(memberAccessNode.Name.ToString())
                ).Select(s => s.Name).Distinct();

                CodeAutocompletion_AlreadyEnteredStrLen = memberAccessNode.Name.GetLocation().SourceSpan.Length;
                return WordsList;
            }

            return null;
        }
    }

    public class ColorizeAvalonEdit : DocumentColorizingTransformer
    {
        protected override void ColorizeLine(DocumentLine line)
        {
            if (CodeHelper.ClassifiedSpans == null)
                return;

            foreach (ClassifiedSpan span in CodeHelper.ClassifiedSpans)
            {
                if (span.TextSpan.Start >= line.Offset && span.TextSpan.End <= line.EndOffset)
                {
                    ChangeLinePart(span.TextSpan.Start, span.TextSpan.End,
                        (VisualLineElement element) =>
                        {
                            Typeface tf = element.TextRunProperties.Typeface;
                            switch (span.ClassificationType)
                            {
                                case ClassificationTypeNames.NamespaceName:
                                case ClassificationTypeNames.InterfaceName:
                                case ClassificationTypeNames.StructName:
                                case ClassificationTypeNames.ClassName:
                                case ClassificationTypeNames.EnumName:
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.CornflowerBlue));
                                    break;

                                case ClassificationTypeNames.ConstantName: // const int ConstantName
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.Orange));
                                    break;

                                case ClassificationTypeNames.Comment:
                                    element.TextRunProperties.SetTypeface(new Typeface(tf.FontFamily, FontStyles.Italic, FontWeights.Bold, tf.Stretch));
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.GreenYellow));
                                    break;

                                case ClassificationTypeNames.PreprocessorKeyword: // #PreprocessorKeyword
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.DarkOrange));
                                    break;

                                case ClassificationTypeNames.ParameterName: // Foo(int ParameterName)
                                case ClassificationTypeNames.PropertyName:
                                case ClassificationTypeNames.FieldName:
                                case ClassificationTypeNames.EventName:
                                case ClassificationTypeNames.DelegateName:
                                case ClassificationTypeNames.EnumMemberName:
                                case ClassificationTypeNames.NumericLiteral:
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Color.FromArgb(255, 146, 180, 242)));
                                    break;

                                case ClassificationTypeNames.PreprocessorText:
                                case ClassificationTypeNames.StringLiteral:
                                case ClassificationTypeNames.VerbatimStringLiteral: // @"hello world"
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.Orange));
                                    break;

                                case ClassificationTypeNames.StringEscapeCharacter: // "\n\r"
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.Wheat));
                                    break;

                                case ClassificationTypeNames.LabelName: // GOTO label statement
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Color.FromArgb(255, 0, 191, 255)));
                                    break;

                                case ClassificationTypeNames.Keyword: // goto return float new ...
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Color.FromArgb(255, 0, 191, 255)));
                                    break;

                                case ClassificationTypeNames.ControlKeyword: // return
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.CornflowerBlue));
                                    break;

                                case ClassificationTypeNames.Punctuation:
                                case ClassificationTypeNames.Operator:
                                case ClassificationTypeNames.OperatorOverloaded:
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.Silver));
                                    break;

                                case ClassificationTypeNames.Identifier: // classes, functions
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.CornflowerBlue));
                                    break;

                                case ClassificationTypeNames.MethodName: // void MethodName()
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.Orange));
                                    break;

                                case ClassificationTypeNames.StaticSymbol: // static void StaticSymbol()
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Colors.Yellow));
                                    break;

                                case ClassificationTypeNames.LocalName: // int LocalName = 0;
                                    element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Color.FromArgb(255, 128, 255, 128)));
                                    break;

                                case ClassificationTypeNames.TypeParameterName:
                                    // element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)));
                                    break;

                                case ClassificationTypeNames.ExtensionMethodName:
                                    // element.TextRunProperties.SetForegroundBrush(new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)));
                                    break;
                            }
                        });
                }
            }
        }
    }

    public class CodeCompletionData : ICompletionData
    {
        int AlreadyExistingStringLength = 0;

        public CodeCompletionData(string Text, int AlreadyEnteredStringLength)
        {
            this.Text = Text;
            this.AlreadyExistingStringLength = AlreadyEnteredStringLength;
        }

        public ImageSource Image
        {
            get => null;
        }

        public string Text { get; private set; }

        public object Content
        {
            get => Text;
        }

        public object Description
        {
            get => "Description for " + Text;
        }

        public double Priority => 0.0;

        public void Complete(TextArea textArea, ISegment completionSegment, EventArgs insertionRequestEventArgs)
        {
            textArea.Document.Replace(completionSegment.Offset - AlreadyExistingStringLength, completionSegment.Length + AlreadyExistingStringLength, Text);
        }
    }
}
