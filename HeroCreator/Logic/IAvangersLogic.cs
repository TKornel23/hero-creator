using HeroCreator.Models;
using System.Collections.Generic;

namespace HeroCreator.Logic
{
    public interface IAvangersLogic
    {
        double AVGPower { get; }
        double AVGSpeed { get; }
        double ManaCost { get; }

        void AddToAvangers(Hero selectedFromBarrack);
        void CreateNewHero();
        void RemoveFromAvangers(Hero selectedFromAvangers);
        void SetupCollections(IList<Hero> barrack, IList<Hero> avangers);
    }
}