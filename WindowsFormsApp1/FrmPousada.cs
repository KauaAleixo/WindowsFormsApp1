using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmPousada : Form
    {
        public FrmPousada()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btmCadastrar_Click(object sender, EventArgs e)


        {
            if (txbName.Text == "kaua" && txbSenha.Text == "123456" && txbCpf.Text == "551 726 888 97")
            {
                txbName.Text = string.Empty; //Limpa o campo de usuario 
                txbSenha.Text = string.Empty; //Limpa o campo de senha
                txbName.Focus(); //Coloca o foco no campo de usuario

                FrmPousada2 principal = new FrmPousada2();
                this.Visible = false; // ESCONDER TELA 
                principal.ShowDialog();//ABRI A TELA 
                this.Visible = true; // VOLTA A MOSTRAR A TELA
            }
            else
            {
                MessageBox.Show("Usuario e/ou senha incorretos",
                    "ERRO NO LOGIN",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txbName.Text = string.Empty; //Limpa o campo de usuario 
                txbSenha.Text = string.Empty; //Limpa o campo de senha
                txbCpf.Text = string.Empty; //Limpar o campo do cepefu
                txbName.Focus(); //Coloca o foco no campo de usuario

            }

        }
    }
}
