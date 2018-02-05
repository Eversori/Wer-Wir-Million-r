using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WerWirdMillionaer
{
    public partial class Spielfenster : Form
    {
        private List<Frage> fragen;
        private List<Frage> benuzteFragen;
        private Frage aktuelleFrage;
        private string spielername;
        private Boolean risiko;
        private int stufe=1;
        private Joker joker1;
        private Joker joker2;
        private Joker joker3;
        private Joker joker4;
        private Button ausgewaelterButton=new Button();
        private Boolean naechsteFrage=false;

        public string Spielername
        {
            get
            {
                return spielername;
            }

            set
            {
                spielername = value;
            }
        }

        public Spielfenster(Boolean risiko, string spielername)
        {
            fragen = new List<Frage>();
            benuzteFragen = new List<Frage>();
            InitializeComponent();
            verbindeDatenbank();
            loadFrage();

            this.risiko = risiko;
            this.spielername = spielername;
            checkJoker();
        }

        private void loadFrage()
        {
            int level=0;

            if (stufe<=5)
            {
                level = 1;
            }
            else if(stufe<=10)
            {
                level = 2;
            }
            else if(stufe<=14)
            {
                level = 3;
            }
            else
            {
                level = 4;
            }
            List<Frage> moeglicheFragen = new List<Frage>();
            for(int i=0;i<fragen.Count;i++)
            {
                if(fragen[i].Level==level)
                {
                    if(!benuzteFragen.Contains(fragen[i]))
                    moeglicheFragen.Add(fragen[i]);
                }
            }

            Random r = new Random();
            
            int fragenummer = r.Next(0, moeglicheFragen.Count-1);

            aktuelleFrage = moeglicheFragen[fragenummer];

            labelFrage.Text= aktuelleFrage.Inhalt;
            //ButtonA
            buttonA.Text = aktuelleFrage.Antworten[0].Inhalt;
            //ButtonB
            buttonB.Text = aktuelleFrage.Antworten[1].Inhalt;
            //ButtonC
            buttonC.Text = aktuelleFrage.Antworten[2].Inhalt;
            //ButtonD
            buttonD.Text = aktuelleFrage.Antworten[3].Inhalt;


        }

        private void verbindeDatenbank()
        {

            //Provider=Microsoft.ACE.OLEDB.12.0;Data Source="H:\Eigene Dateien\FI11\GIT\Wer-Wir-Million-r\WerWirdMillionaer\Millionaer1.accdb";Persist Security Info=True
            OleDbConnectionStringBuilder sb = new OleDbConnectionStringBuilder();
            sb.Provider = "Microsoft.ACE.OLEDB.12.0";
            sb.DataSource = "Millionaer1.accdb";
            bool right = false;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = sb.ConnectionString;
            try
            {
                con.Open();
                right = true;

            }
            catch
            {
                MessageBox.Show("Datenbankfehler");
            }


            if (right)
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from Fragen";
                OleDbDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Frage f = new Frage();
                    f.FrageID =Convert.ToInt32(CheckDBNull( reader[0]));
                    f.Inhalt = Convert.ToString(CheckDBNull(reader[1]));
                    f.Level = Convert.ToInt32(CheckDBNull(reader[2]));
                    fragen.Add(f);
                }

                cmd = con.CreateCommand();
                cmd.CommandText = "Select * from Antworten";
                reader = cmd.ExecuteReader();
                int frage=0;

                
                while (reader.Read())
                {
                    Antwort a = new Antwort();
                    a.Inhalt = Convert.ToString(CheckDBNull(reader[0]));
                    frage = Convert.ToInt32(CheckDBNull(reader[1]));
                    a.Richtig = Convert.ToBoolean(CheckDBNull(reader[2]));
                    
                    
                    for(int i=0;i<fragen.Count;i++)
                    {
                        if (frage == fragen[i].FrageID)
                        {
                            fragen[i].Antworten.Add(a);
                        }
                    }
                }

            }

            
           
        }

        private object CheckDBNull(object v)
        {
            if(v==DBNull.Value)
            {
                v = 0;
            }
            return v;
        }

        private void Spielfenster_Load(object sender, EventArgs e)
        {

        }

        private void checkJoker()
        {
            joker1 = new Joker50();
            joker2 = new Publikumsjoker();
            joker3 = new Telefonjoker();
            if (risiko)
            {
                joker4 = new Risikojoker();
                buttonZusatzJoker.Visible = true;
            }
        }

        private void button5050_Click(object sender, EventArgs e)
        {
            joker1.Benutzt = true;
            button5050.Enabled = false;
            joker1.benutzeJoker(aktuelleFrage);
            
        }

        private void buttonTeleJoker_Click(object sender, EventArgs e)
        {
            joker2.Benutzt = true;
            buttonTeleJoker.Enabled = false;
            joker2.benutzeJoker(aktuelleFrage);
            markiereButtons();
        }

        private void markiereButtons()
        {
            for (int i = 0; i <= 4; i++)
            {
                if (buttonA.Text.Equals(aktuelleFrage.Antworten[i].Inhalt))
                {
                    if (aktuelleFrage.Antworten[i].Joker50)
                    {
                        buttonA.Text = "-";
                    }
                }
            }

            for (int i = 0; i <= 4; i++)
            {
                if (buttonB.Text.Equals(aktuelleFrage.Antworten[i].Inhalt))
                {
                    if (aktuelleFrage.Antworten[i].Joker50)
                    {
                        buttonB.Text = "-";
                    }
                }
            }

            for (int i = 0; i <= 4; i++)
            {
                if (buttonC.Text.Equals(aktuelleFrage.Antworten[i].Inhalt))
                {
                    if (aktuelleFrage.Antworten[i].Joker50)
                    {
                        buttonC.Text = "-";
                    }
                }
            }

            for (int i = 0; i <= 4; i++)
            {
                if (buttonD.Text.Equals(aktuelleFrage.Antworten[i].Inhalt))
                {
                    if (aktuelleFrage.Antworten[i].Joker50)
                    {
                        buttonD.Text = "-";
                    }
                }
            }
            
        }

        private void buttonPubJoker_Click(object sender, EventArgs e)
        {
            joker3.Benutzt = true;
            buttonPubJoker.Enabled = false;
        }

        private void buttonZusatzJoker_Click(object sender, EventArgs e)
        {
            joker3.Benutzt = true;
            buttonZusatzJoker.Enabled = false;
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            if(buttonA==ausgewaelterButton)
            {
                loesungCheck();
            }
            else
            {
                ausgewaelterButton.ForeColor = buttonA.ForeColor;
                buttonA.ForeColor = Color.Orange;
                ausgewaelterButton = buttonA;
            }
        }

        private void loesungCheck()
        {
            if(naechsteFrage==false)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (aktuelleFrage.Antworten[i].Richtig == true)
                    {
                        if (ausgewaelterButton.Text.Equals(aktuelleFrage.Antworten[i].Inhalt))
                        {
                            ausgewaelterButton.ForeColor = Color.LightGreen;
                            naechsteFrage = true;
                        }
                        else
                        {
                            ausgewaelterButton.ForeColor = Color.Red;
                            if (buttonA.Text.Equals(aktuelleFrage.Antworten[i].Inhalt))
                            {
                                buttonA.ForeColor = Color.LightGreen;
                            }
                            else if (buttonB.Text.Equals(aktuelleFrage.Antworten[i].Inhalt))
                            {
                                buttonB.ForeColor = Color.LightGreen;
                            }
                            else if (buttonC.Text.Equals(aktuelleFrage.Antworten[i].Inhalt))
                            {
                                buttonC.ForeColor = Color.LightGreen;
                            }
                            else if (buttonD.Text.Equals(aktuelleFrage.Antworten[i].Inhalt))
                            {
                                buttonD.ForeColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }
            else
            {
                next();
                naechsteFrage = false;
                Button faker = new Button();
                buttonA.ForeColor = faker.ForeColor;
                buttonB.ForeColor = faker.ForeColor;
                buttonC.ForeColor = faker.ForeColor;
                buttonD.ForeColor = faker.ForeColor;
            }
        }

        private void next()
        {
            stufe++;
            loadFrage();
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            if (buttonB == ausgewaelterButton)
            {
                loesungCheck();
            }
            else
            {
                ausgewaelterButton.ForeColor = buttonB.ForeColor;
                buttonB.ForeColor = Color.Orange;
                ausgewaelterButton = buttonB;
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            if (buttonC == ausgewaelterButton)
            {
                loesungCheck();
            }
            else
            {
                ausgewaelterButton.ForeColor = buttonC.ForeColor;
                buttonC.ForeColor = Color.Orange;
                ausgewaelterButton = buttonC;
            }
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            if (buttonD == ausgewaelterButton)
            {
                loesungCheck();
            }
            else
            {
                ausgewaelterButton.ForeColor = buttonD.ForeColor;
                buttonD.ForeColor = Color.Orange;
                ausgewaelterButton = buttonD;
            }
        }
    }
}
