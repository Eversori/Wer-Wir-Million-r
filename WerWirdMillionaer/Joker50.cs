using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerWirdMillionaer
{
    class Joker50 : Joker
    {
        public override void benutzeJoker(Frage frage)
        {
            Random r = new Random();
            int i = 0;
            int j = 0;

            while (j == i || frage.Antworten[j].Richtig || frage.Antworten[i].Richtig) 
            {            
                    i = r.Next(0, 3);
                    j = r.Next(0, 3);
            }
            frage.Antworten[i].Joker50 = true;
            frage.Antworten[j].Joker50 = true;
        }
    }
}
