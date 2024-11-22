using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tic_Tac_Toe_Game
{
    public partial class FrmTic_Tac_Toe : Form
    {
        public FrmTic_Tac_Toe()
        {
            InitializeComponent();
        }

        private void FrmTic_Tac_Toe_Paint(object sender, PaintEventArgs e)
        {
            Color Color = Color.White;

            Pen Pen = new Pen(Color);
            Pen.Width = 15;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 500, 500, 500, 100);

            e.Graphics.DrawLine(Pen, 700, 500, 700, 100);


            e.Graphics.DrawLine(Pen, 350, 225, 850, 225);
            e.Graphics.DrawLine(Pen, 350, 375, 850, 375);
        }

        void ResetButton(Button button)
        {
            button.Text = "?";
            button.BackColor = Color.Black;
            button.ForeColor = Color.Red;
        }
        void RestartGame()
        {
            ResetButton(btn1);
            ResetButton(btn2);
            ResetButton(btn3);
            ResetButton(btn4);
            ResetButton(btn5);
            ResetButton(btn6);
            ResetButton(btn7);
            ResetButton(btn8);
            ResetButton(btn9);

            lblWinner.Text = "In Progress";
            lblPlayer.Text = "Player 1";
        }

        void ResultsWinner()
        {
            lblWinner.Text = lblPlayer.Text;
            lblPlayer.Text = "Game Over";

            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void ResultsDraw()
        {
            if ((btn1.Text != "?") && (btn2.Text != "?") && (btn3.Text != "?") && (btn4.Text != "?") &&
               (btn5.Text != "?") && (btn6.Text != "?") && (btn7.Text != "?") && (btn8.Text != "?") && (btn9.Text != "?"))
            {
                lblPlayer.Text = "Game Over";
                lblWinner.Text = "Draw";
                MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        bool CheckButton(Button button1, Button button2, Button button3)
        {
            if (((button1.Text == "X") && (button2.Text == "X") && (button3.Text == "X"))
               || ((button1.Text == "O") && (button2.Text == "O") && (button3.Text == "O")))
            {
                button1.BackColor = Color.GreenYellow;
                button2.BackColor = Color.GreenYellow;
                button3.BackColor = Color.GreenYellow;
                ResultsWinner();
                return true;
            }

            return false;
        }

        void WhoWin()
        {
            if (CheckButton(btn1, btn2, btn3))
            {
                ResultsWinner();
                return;
            }

            if (CheckButton(btn4, btn5, btn6))
            {
                ResultsWinner();
                return;
            }

            if (CheckButton(btn7, btn8, btn9))
            {
                ResultsWinner();
                return;
            }

            if (CheckButton(btn1, btn4, btn7))
            {
                ResultsWinner();
                return;
            }

            if (CheckButton(btn2, btn5, btn8))
            {
                ResultsWinner();
                return;
            }

            if (CheckButton(btn3, btn6, btn9))
            {
                ResultsWinner();
                return;
            }

            if (CheckButton(btn1, btn5, btn9))
            {
                ResultsWinner();
                return;
            }

            if (CheckButton(btn3, btn5, btn7))
            {
                ResultsWinner();
                return;
            }

            ResultsDraw();
        }

        void UpdateButton(Button button)
        {
            if (lblPlayer.Text == "Game Over")
            {
                MessageBox.Show("You Should Restart Game", "End Game", MessageBoxButtons.OK, MessageBoxIcon.Question);
                RestartGame();
                return;
            }

            if (button.Text != "?")
            {
                MessageBox.Show("Warning", "Wrong Choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lblPlayer.Text == "Player 1")
            {
                button.Text = "X";
                button.ForeColor = Color.LightBlue;
                lblPlayer.Text = "Player 2";
            }
            else
            {
                button.Text = "O";
                button.ForeColor = Color.LightBlue;
                lblPlayer.Text = "Player 1";
            }

            WhoWin();

        }

        private void button_click(object sender, EventArgs e)
        {
            UpdateButton((Button)sender);
        }


        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }  
}
