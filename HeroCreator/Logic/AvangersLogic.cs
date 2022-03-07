using HeroCreator.Models;
using HeroCreator.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroCreator.Logic
{
    public class AvangersLogic : IAvangersLogic
    {
        IList<Hero> barrack;
        IList<Hero> avangers;
        IMessenger messenger;
        IHeroCreatorService heroCreator; 

        public AvangersLogic(IMessenger mess, IHeroCreatorService service)
        {
            messenger = mess;
            this.heroCreator = service;
        }

        public void SetupCollections(IList<Hero> barrack, IList<Hero> avangers)
        {
            this.barrack = barrack;
            this.avangers = avangers;
        }

        public void AddToAvangers(Hero selectedFromBarrack)
        {
            avangers.Add(selectedFromBarrack);
            messenger.Send("Hero added", "HeroInfo");
        }

        public void RemoveFromAvangers(Hero selectedFromAvangers)
        {
            avangers.Remove(selectedFromAvangers);
            messenger.Send("Hero Removed", "HeroInfo");
        }

        public void CreateNewHero()
        {
            barrack.Add(heroCreator.CreateNewHero());
            messenger.Send("Hero Created", "HeroInfo");
        }

        public double AVGPower { get { return avangers.Count() == 0 ? 0 : avangers.Average(x => x.Power); } }
        public double AVGSpeed { get { return avangers.Count() == 0 ? 0 : avangers.Average(x => x.Speed); } }
        public double ManaCost { get { return avangers.Count() == 0 ? 0 : avangers.Sum(x => x.ManaCost); } }
    }
}
