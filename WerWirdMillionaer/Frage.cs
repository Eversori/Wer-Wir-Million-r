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
        private List<Antwort> antworten;

        public Frage()
        {
            antworten = new List<Antwort>();
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

        internal List<Antwort> Antworten
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
    }
}
