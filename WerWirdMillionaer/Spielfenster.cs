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

        public Spielfenster(Boolean risiko)
        {
            InitializeComponent();
            verbindeDatenbank();
            fragen = new List<Frage>();
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
                    f.FrageID =Convert.ToString(CheckDBNull( reader[0]));
                    f.Inhalt = Convert.ToString(CheckDBNull(reader[1]));
                    f.Level = Convert.ToInt32(CheckDBNull(reader[2]));
                    fragen.Add(f);
                }

                cmd=con.

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
    }
}
