using HeroCreator.Models;
using HeroCreator.ViewModels;
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

namespace HeroCreator
{
    /// <summary>
    /// Interaction logic for CreateNewHeroWindow.xaml
    /// </summary>
    public partial class CreateNewHeroWindow : Window
    {
        public Hero newHero { get; set; }

        public CreateNewHeroWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            newHero = new Hero()
            {
                Name = name.Text,
                Power = int.Parse(power.Text),
                Speed = int.Parse(speed.Text),
                Type = (Models.Type)Enum.Parse(typeof(Models.Type), type.Text, true)
            };
            this.DialogResult = true;
        }
    }
}
