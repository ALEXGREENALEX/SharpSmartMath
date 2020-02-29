using SharpSmartMathLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SharpSmartMath
{
    public partial class SplashScreen : Window
    {
        bool IsOpened = false;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenMainWindow();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                OpenMainWindow();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Task.Run(() => FirstCompilation());
        }

        void FirstCompilation()
        {
            string ResultStr = String.Empty;
            DynamicCompile.CompileCode("return 0;", out ResultStr);
            Dispatcher.BeginInvoke(new Action(OpenMainWindow));
        }

        void OpenMainWindow()
        {
            if (!IsOpened)
            {
                IsOpened = true;
                new MainWindow().Show();
                Close();
            }
        }
    }
}
