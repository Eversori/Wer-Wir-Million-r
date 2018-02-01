using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WerWirdMillionaer
{
    public partial class Form1 : Form
    {
        private string name;
        private Spielfenster spiel1;
        private Boolean risiko;
        public Form1()
        {
            InitializeComponent();
        }

        public string Name1
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

        public bool Risiko
        {
            get
            {
                return risiko;
            }

            set
            {
                risiko = value;
            }
        }

        private void starteNormalesSpiel(object sender, EventArgs e)
        {
            name = textBoxName.Text;
            risiko = false;
            spiel1 = new Spielfenster(risiko, name);
            spiel1.Visible = true;
            
        }

        private void buttonRiskPlay_Click(object sender, EventArgs e)
        {
            name = textBoxName.Text;
            risiko = true;
            spiel1 = new Spielfenster(risiko, name);
            spiel1.Visible = true;
            
        }
    }
}
