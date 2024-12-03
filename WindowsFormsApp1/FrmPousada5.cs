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
    public partial class FrmPousada5 : Form
    {
        public FrmPousada5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reservado");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPousada4 principal = new FrmPousada4();
            this.Visible = false; // ESCONDER TELA 
            principal.ShowDialog();//ABRI A TELA 
            this.Visible = true; // VOLTA A MOSTRAR A TELA
        }
    }
}
