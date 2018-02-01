using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerWirdMillionaer
{
    class Frage
    {
        private String Inhalt;
        private int level;
        private Antwort antworten;

        public string Inhalt1
        {
            get
            {
                return Inhalt;
            }

            set
            {
                Inhalt = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }
    }
}
