using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroCreator.Models
{

    public class Hero : ObservableObject
    {
        private Type type;

        public Type Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }
        private int power;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }


        public int ManaCost { get { return this.power * this.speed; } }

        public Hero GetCopy()
        {
            return new Hero()
            {
                Type = this.Type,
                Speed = this.Speed,
                Power = this.Power,
                Name = this.Name
            };
        }

    }
}
