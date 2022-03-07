using HeroCreator.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeroCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            string jsonData = JsonConvert.SerializeObject((this.DataContext as MainWindowViewModel).Barrack);
            File.WriteAllText("barrack.json", jsonData);

            string jsonData2 = JsonConvert.SerializeObject((this.DataContext as MainWindowViewModel).Avangers);
            File.WriteAllText("army.json", jsonData);
        }
    }
}
