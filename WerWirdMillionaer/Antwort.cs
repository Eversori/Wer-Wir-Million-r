﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerWirdMillionaer
{
    class Antwort
    {
        private String inhalt;
        private Boolean richtig;
        private Boolean joker50 = false;

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

        public bool Richtig
        {
            get
            {
                return richtig;
            }

            set
            {
                richtig = value;
            }
        }

        public bool Joker50
        {
            get
            {
                return joker50;
            }

            set
            {
                joker50 = value;
            }
        }
    }
}
