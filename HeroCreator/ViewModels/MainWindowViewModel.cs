using HeroCreator.Logic;
using HeroCreator.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HeroCreator.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ICommand AddToAvangersCommand { get; set; }
        public ICommand RemoveFromAvangersCommand { get; set; }
        public ICommand CreateNewHeroCommand { get; set; }
        private Hero selectedFromAvangers;

        public Hero SelectedFromAvangers
        {
            get { return selectedFromAvangers; }
            set
            {
                SetProperty(ref selectedFromAvangers, value);
                (RemoveFromAvangersCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Hero selectedFromBarrack;
        public Hero SelectedFromBarrack
        {
            get { return selectedFromBarrack; }
            set
            {
                SetProperty(ref selectedFromBarrack, value);
                (AddToAvangersCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ObservableCollection<Hero> Avangers { get; set; }
        public ObservableCollection<Hero> Barrack { get; set; }
        IAvangersLogic logic;

        public double AVGSpeed { get { return this.logic.AVGSpeed; } }
        public double AVGPower { get { return this.logic.AVGPower; } }
        public double ManaCost { get { return this.logic.ManaCost; } }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IAvangersLogic>())
        {

        }


        public MainWindowViewModel(IAvangersLogic logic)
        {
            this.Avangers = new ObservableCollection<Hero>();
            this.Barrack = new ObservableCollection<Hero>();
            this.logic = logic;

            logic.SetupCollections(Barrack, Avangers);

            if (File.Exists("barrack.json"))
            {
                var barrack = JsonConvert.DeserializeObject<ObservableCollection<Hero>>(File.ReadAllText("barrack.json"));
                barrack.ToList().ForEach(x => Barrack.Add(x));
            }
            if (File.Exists("army.json"))
            {
                var army = JsonConvert.DeserializeObject<ObservableCollection<Hero>>(File.ReadAllText("army.json"));
                army.ToList().ForEach(x => Avangers.Add(x));
            }

            AddToAvangersCommand = new RelayCommand(
                () => logic.AddToAvangers(selectedFromBarrack),
                () => selectedFromBarrack != null
            );

            RemoveFromAvangersCommand = new RelayCommand(
                () => logic.RemoveFromAvangers(selectedFromAvangers),
                () => selectedFromAvangers != null
            );

            CreateNewHeroCommand = new RelayCommand(
                () => logic.CreateNewHero()
            );

            Messenger.Register<MainWindowViewModel, string, string>(this, "HeroInfo", (sender, args) =>
             {
                 OnPropertyChanged("AVGSpeed");
                 OnPropertyChanged("AVGPower");
                 OnPropertyChanged("AllCost");
             });
        }
    }
}
