using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmPousada4 : Form
    {
        public FrmPousada4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPousada3 principal = new FrmPousada3();
            this.Visible = false; // ESCONDER TELA 
            principal.ShowDialog();//ABRI A TELA 
            this.Visible = true; // VOLTA A MOSTRAR A TELA
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPousada5 principal = new FrmPousada5();
            this.Visible = false; // ESCONDER TELA 
            principal.ShowDialog();//ABRI A TELA 
            this.Visible = true; // VOLTA A MOSTRAR A TELA
        }
    }
}
