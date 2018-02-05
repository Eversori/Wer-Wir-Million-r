using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerWirdMillionaer
{
    abstract class Joker
    {
        private Boolean benutzt;
        private String name;
        private Boolean viable;

        public bool Benutzt
        {
            get
            {
                return benutzt;
            }

            set
            {
                benutzt = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool Viable
        {
            get
            {
                return viable;
            }

            set
            {
                viable = value;
            }
        }

        public abstract void benutzeJoker(List<Frage> fragen);
    }
}
