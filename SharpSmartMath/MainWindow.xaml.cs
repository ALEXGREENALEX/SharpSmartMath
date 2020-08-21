using ICSharpCode.AvalonEdit.CodeCompletion;
using Microsoft.CodeAnalysis.Text;
using SharpSmartMathLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace SharpSmartMath
{
    public partial class MainWindow : Window
    {
        Thread CompilingThread, HighlightingThread;
        CompletionWindow CodeCompletionWindow;

        Brush CompiledColor = new SolidColorBrush(Colors.YellowGreen);
        Brush ErrorColor = new SolidColorBrush(Colors.OrangeRed);

        public MainWindow()
        {
            InitializeComponent();
            EditorCode.TextArea.TextView.LineTransformers.Add(new ColorizeAvalonEdit());
            EditorCode.TextArea.TextEntered += EditorCode_TextEntered;

            try
            {
                string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                DynamicCompile.CodeTemplate = File.ReadAllText(Path.Combine(StartupPath, "BaseProgram.cs"));
            }
            catch (Exception ex)
            {
                EditorResult.Foreground = ErrorColor;
                EditorResult.Text = ex.Message;
            }

            StartCompilingThread();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                (CodeCompletionWindow == null ? (this) : (Window)CodeCompletionWindow).Close();
            }
            else if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.K) // Format Code
            {
                string Code = EditorCode.Text;
                EditorCode.Text = CodeHelper.FormatCode(Code);
            }
        }

        private void EditorCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.Space) // Auto complete handle event
            {
                if (CodeCompletionWindow != null)
                {
                    CodeCompletionWindow.Close();
                    CodeCompletionWindow = null;
                }
                e.Handled = true;
            }
        }

        private void EditorCode_KeyUp(object sender, KeyEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.Space) // Auto complete code show
            {
                ShowCodeCompletionWindow();
            }
            else if (e.Key == Key.Enter) // Auto complete code insert
            {
                if (CodeCompletionWindow != null)
                    CodeCompletionWindow.CompletionList.RequestInsertion(e);
            }
        }

        private void EditorCode_TextChanged(object sender, EventArgs e)
        {
            StartCompilingThread();
            StartHighlightingThread();
        }

        private void EditorCode_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == ".")
                ShowCodeCompletionWindow();

            if (e.Text.Length <= 0 || CodeCompletionWindow == null)
                return;
            else if (!char.IsLetterOrDigit(e.Text[0]) && e.Text[0] != '.')
                CodeCompletionWindow.CompletionList.RequestInsertion(e);
            else if (CodeCompletionWindow.CompletionList.CompletionData.Count <= 0)
                CodeCompletionWindow.Close();
        }

        void ShowCodeCompletionWindow()
        {
            string Code = EditorCode.Dispatcher.Invoke(new Func<string>(() => { return EditorCode.Text; }));
            IEnumerable<string> AutocompletionList = CodeHelper.GetCodeAutocompletionList(Code, EditorCode.CaretOffset);

            if (AutocompletionList != null && AutocompletionList.Count() > 0)
            {
                CodeCompletionWindow = new CompletionWindow(EditorCode.TextArea);
                CodeCompletionWindow.Closed += delegate { CodeCompletionWindow = null; };
                CodeCompletionWindow.CompletionList.InsertionRequested += delegate { CodeHelper.CodeAutocompletion_AlreadyEnteredStrLen = 0; };
                IList<ICompletionData> data = CodeCompletionWindow.CompletionList.CompletionData;

                foreach (var str in AutocompletionList)
                    data.Add(new CodeCompletionData(str, CodeHelper.CodeAutocompletion_AlreadyEnteredStrLen));

                if (CodeCompletionWindow != null)
                    CodeCompletionWindow.Show();
            }
        }

        void StartCompilingThread()
        {
            StopCompilingThread();

            CompilingThread = new Thread(new ThreadStart(CompileCodeThreadFunc));
            CompilingThread.Start();
        }

        void StopCompilingThread()
        {
            if (CompilingThread != null && CompilingThread.ThreadState == ThreadState.Running)
                CompilingThread.Abort();
        }

        public void CompileCodeThreadFunc()
        {
            try
            {
                string Code = EditorCode.Dispatcher.Invoke(new Func<string>(() => { return EditorCode.Text; }));

                string ResultStr = String.Empty;
                Brush TextColor = CompiledColor;

                if (Code == String.Empty)
                    ResultStr = String.Empty;
                else
                {
                    if (!DynamicCompile.CompileCode(Code, out ResultStr))
                        TextColor = ErrorColor;
                    else if (ResultStr == String.Empty) // Nothing to return, like with code: "Math.Pow(2, 2)"
                    {
                        string ResultStrPrev = ResultStr;
                        if (!DynamicCompile.CompileCode("return " + Code + "", out ResultStr)) // If error - take last result without "return".
                            ResultStr = ResultStrPrev;
                    }
                }

                PlotViewer.Dispatcher.Invoke(() =>
                {
                    PlotViewer.Model = Plot.Model;
                    PlotViewer.InvalidatePlot();
                });

                EditorResult.Dispatcher.Invoke(() =>
                {
                    EditorResult.Text = ResultStr;
                    EditorResult.Foreground = TextColor;
                });
            }
            catch { }
        }

        void StartHighlightingThread()
        {
            StopHighlightingThread();

            HighlightingThread = new Thread(new ThreadStart(HighlightCodeThreadFunc));
            HighlightingThread.Start();
        }

        void StopHighlightingThread()
        {
            if (HighlightingThread != null && HighlightingThread.ThreadState == ThreadState.Running)
                HighlightingThread.Abort();
        }

        public void HighlightCodeThreadFunc()
        {
            try
            {
                string Code = EditorCode.Dispatcher.Invoke(new Func<string>(() => { return EditorCode.Text; }));
                CodeHelper.GetCodeHighlighting(Code);
                EditorCode.Dispatcher.Invoke(EditorCode.TextArea.TextView.Redraw);
            }
            catch { }
        }
    }
}