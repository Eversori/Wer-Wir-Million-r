using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerWirdMillionaer
{
    class Frage
    {
        private String frageID;
        private String inhalt;
        private Int32 level;
        private Antwort[] antworten;

        public Frage()
        {
            Antworten = new Antwort[4];
        }

        public string Inhalt
        {
            get
            {
                return inhalt;
            }

            set
            {
                inhalt = value;
            }
        }

        public Int32 Level
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

        internal Antwort[] Antworten
        {
            get
            {
                return antworten;
            }

            set
            {
                antworten = value;
            }
        }

        public string FrageID
        {
            get
            {
                return frageID;
            }

            set
            {
                frageID = value;
            }
        }
    }
}
