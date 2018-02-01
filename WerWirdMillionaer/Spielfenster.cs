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
        public Spielfenster()
        {
            InitializeComponent();
            verbindeDatenbank();
        }

        private void verbindeDatenbank()
        {
            
        }

        private void Spielfenster_Load(object sender, EventArgs e)
        {

        }
    }
}
