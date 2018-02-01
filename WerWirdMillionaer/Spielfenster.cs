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
        private string spielername;
        private Boolean risiko;
        private int stufe=1;
        private Joker joker1;
        private Joker joker2;
        private Joker joker3;
        private Joker joker4;

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
                if(fragen[i].FrageID==level)
                {
                    if(!benuzteFragen.Contains(fragen[i]))
                    moeglicheFragen.Add(fragen[i]);
                }
            }

            Random r = new Random();



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
                string frage;

                int i = 0;
                while (reader.Read())
                {
                    Antwort a = new Antwort();
                    a.Inhalt = Convert.ToString(CheckDBNull(reader[0]));
                    frage = Convert.ToString(CheckDBNull(reader[1]));
                    a.Richtig = Convert.ToBoolean(CheckDBNull(reader[2]));
                    i = 0;
                    while(!frage.Equals(fragen[i].FrageID))
                    {
                        fragen[i].Antworten.Add(a);
                        i++;
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
            joker1.benutzeJoker(fragen);
        }

        private void buttonTeleJoker_Click(object sender, EventArgs e)
        {
            joker2.Benutzt = true;
            buttonTeleJoker.Enabled = false;
            joker2.benutzeJoker(fragen);
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
    }
}
