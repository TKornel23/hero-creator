using HeroCreator.Models;
using HeroCreator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroCreator.Services
{
    public class HeroCreatorService : IHeroCreatorService
    {
        public Hero CreateNewHero()
        {
            CreateNewHeroWindow window = new CreateNewHeroWindow();
            window.ShowDialog();
            
            if(window.DialogResult == true)
            {
                return window.newHero;
            }
            return new Hero();
        }
    }
}
