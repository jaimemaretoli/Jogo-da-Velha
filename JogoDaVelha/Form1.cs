using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        public string atual = "X";
        Button[,] buttons;
        int contGannhador = 0, contGannhador2 = 0, contEmpate = 0;

        public Form1()
        {
            buttons = new Button[3, 3];
            InitializeComponent();

            buttons[0, 0] = btn00;
            buttons[0, 1] = btn01;
            buttons[0, 2] = btn02;
            buttons[1, 0] = btn10;
            buttons[1, 1] = btn11;
            buttons[1, 2] = btn12;
            buttons[2, 0] = btn20;
            buttons[2, 1] = btn21;
            buttons[2, 2] = btn22;
        }

        public void ZeraPlacar()
        {
            lblPlacarJogadorX.Text = "0";
            lblPlacarJogadorO.Text = "0";
            lblPlacarEmpate.Text = "0";
        }

        private void btnNovoJogo_Click(object sender, EventArgs e)
        {
            for (int n = 0; n < 3; n++)
            {
                for (int m = 0; m < 3; m++)
                {
                    buttons[n, m].Text = "";
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnZerarContador_Click(object sender, EventArgs e)
        {
            ZeraPlacar();
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            Button localButton = (Button)sender;

            if (localButton.Text.Length == 0)
            {
                localButton.Text = atual;

                if (atual.Equals("X"))
                {
                    atual = "O";
                }
                else
                {
                    atual = "X";
                }
            }

            String winner = Ganhador();

            if (winner.Length > 0)
            {
                MessageBox.Show("Vencedor: " + winner);

                if (winner == "X")
                {
                    contGannhador = contGannhador + 1;
                    lblPlacarJogadorX.Text = contGannhador.ToString();
                }
                else if (winner == "O")
                {
                    contGannhador2 = contGannhador2 + 1;
                    lblPlacarJogadorO.Text = contGannhador2.ToString();
                }

                for (int n = 0; n < 3; n++)
                {
                    for (int m = 0; m < 3; m++)
                    {
                        buttons[n, m].Text = "";
                    }
                }
            }
        }

        private String Ganhador()
        {

            // teste horizontal
            for (int n = 0; n < 3; n++)
            {
                if (buttons[n, 0].Text.Length > 0 &&
                    buttons[n, 0].Text.Equals(buttons[n, 1].Text) &&
                    buttons[n, 1].Text.Equals(buttons[n, 2].Text))
                {
                    return buttons[n, 0].Text;
                }
            }
            // teste vertical
            for (int n = 0; n < 3; n++)
            {
                if (buttons[0, n].Text.Length > 0 &&
                    buttons[0, n].Text.Equals(buttons[1, n].Text) &&
                    buttons[1, n].Text.Equals(buttons[2, n].Text))
                {
                    return buttons[0, n].Text;
                }
            }
            // diagonal esquerda
            if (buttons[0, 0].Text.Length > 0 &&
                    buttons[0, 0].Text.Equals(buttons[1, 1].Text) &&
                    buttons[1, 1].Text.Equals(buttons[2, 2].Text))
            {
                return buttons[0, 0].Text;
            }

            if (buttons[0, 2].Text.Length > 0 && // diagonal direita
                    buttons[0, 2].Text.Equals(buttons[1, 1].Text) &&
                    buttons[1, 1].Text.Equals(buttons[2, 0].Text))
            {
                return buttons[0, 2].Text;
            }
            
            // Empate
            if ((btn00.Text == "X" || btn00.Text == "O") &&
                (btn01.Text == "X" || btn01.Text == "O") &&
                (btn02.Text == "X" || btn02.Text == "O") &&
                (btn10.Text == "X" || btn10.Text == "O") &&
                (btn11.Text == "X" || btn11.Text == "O") &&
                (btn12.Text == "X" || btn12.Text == "O") &&
                (btn20.Text == "X" || btn20.Text == "O") &&
                (btn21.Text == "X" || btn21.Text == "O") &&
                (btn22.Text == "X" || btn22.Text == "O"))
            {
                contEmpate = contEmpate + 1;
                lblPlacarEmpate.Text = contEmpate.ToString();
            }

            return "";
        }

    private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
