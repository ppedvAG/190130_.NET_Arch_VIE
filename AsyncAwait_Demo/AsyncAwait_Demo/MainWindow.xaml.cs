using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwait_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IchHabeFertigEvent += TaskIstFertig;
        }

        private void TaskIstFertig(object sender, EventArgs e)
        {
            MessageBox.Show("Ende");
        }

        private event EventHandler IchHabeFertigEvent;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Start");
            MachEtwas();
            //MessageBox.Show("Ende");
        }

        private Task MachEtwas()
        {
           return Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    Dispatcher.Invoke(() => progressBarWert.Value = i); // UI-Thread führt diese Logik für mich aus
                }
                IchHabeFertigEvent?.Invoke(this, EventArgs.Empty);
            });
        }
    }
}
