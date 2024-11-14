using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class BoardGame : Form
    {
        private Button m_SelectedSquare = null;
        private Button[,] m_ButtonBoard;
        private bool m_AiPlaying = false;
        public BoardGame(int i_BoardSize, int i_PlayersNumber, string i_Player1, string i_Player2)
        {
            InitializeComponent();
            this.FormClosing += form_Closing;
            Logic.InputFromUser.s_BoardSize = i_BoardSize;
            Logic.InputFromUser.s_NumberOfPlayers = i_PlayersNumber;
            Logic.InputFromUser.s_Player1Name = i_Player1;
            Logic.InputFromUser.s_Player2Name = i_Player2;
            Logic.Game.CreateNewGame();
            m_ButtonBoard = new Button[i_BoardSize, i_BoardSize];
            printBoard(i_BoardSize);
            Logic.Game.s_PlayerX.GetAllValidMovesForPlayer();
        }

        private void printBoard(int i_BoardSize)
        {
            int top = 50;
            int left = 3;
            bool enabled;

            for (int i = 0; i < i_BoardSize; i++)
            {
                enabled = i % 2 == 0 ? false : true;
                for (int j = 0; j < i_BoardSize; j++)
                {
                    Button button = new Button();
                    button.Name = ((char)(i + 65)).ToString() + ((char)(j + 65)).ToString();
                    button.Left = left;
                    button.Top = top;
                    button.Height = 40;
                    button.Width = 40;
                    button.Text = Logic.Game.s_Board.BoardArray[i, j] != null ? Logic.Game.s_Board.BoardArray[i, j].Type.ToString() : "";
                    button.Enabled = enabled;
                    this.Controls.Add(button);
                    top += 40 + 2;
                    enabled = !enabled;
                    button.MouseClick += new System.Windows.Forms.MouseEventHandler(buttonSquare_MouseClick);
                    m_ButtonBoard[i,j] = button;
                }

                left += 40 + 2;
                top = 50;
            }

            Player1Name.Text = Logic.Game.s_PlayerX.Name + ":";
            Player2Name.Text = Logic.Game.s_PlayerO.Name + ":";
        }

        private void updateBoard()
        {
            for (int i = 0; i < Logic.Game.s_Board.BoardSize; i++)
            {
                for (int j = 0; j < Logic.Game.s_Board.BoardSize; j++)
                {
                    m_ButtonBoard[i, j].Text = Logic.Game.s_Board.BoardArray[i, j] == null ? "" : Logic.Game.s_Board.BoardArray[i, j].Type.ToString();
                    if(m_ButtonBoard[i, j].Text == "O" && Logic.Game.s_Board.BoardArray[i, j].IsKing)
                    {
                        m_ButtonBoard[i, j].Text = "U";
                    }

                    if (m_ButtonBoard[i, j].Text == "X" && Logic.Game.s_Board.BoardArray[i, j].IsKing)
                    {
                        m_ButtonBoard[i, j].Text = "K";
                    }
                }
            }

            if(Logic.Game.s_PlayerX.PawnList.Count == 0)
            {
                Logic.Game.s_PlayerO.Score++;
                Player2Score.Text = Logic.Game.s_PlayerO.Score.ToString();
                printWinner(Logic.Game.s_PlayerO);
            }

            if (Logic.Game.s_PlayerO.PawnList.Count == 0)
            {
                Logic.Game.s_PlayerX.Score++;
                Player1Score.Text = Logic.Game.s_PlayerX.Score.ToString();
                printWinner(Logic.Game.s_PlayerX);
            }
        }

        private void printWinner(Logic.Player i_Player)
        {
            string message =
            i_Player.Name + " Won!\n" + "Another round?";
            const string caption = "Another round?";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Logic.Game.CreateNewGame();
                updateBoard();
                Logic.Game.s_PlayerX.GetAllValidMovesForPlayer();
            } 
            else
            {
                Application.Exit();
            }
        }

        private void printTie()
        {
            string message =
            "Tie!\n" + "Another round?";
            const string caption = "Another round?";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Logic.Game.CreateNewGame();
                updateBoard();
                Logic.Game.s_PlayerX.GetAllValidMovesForPlayer();
            }
            else
            {
                Application.Exit();
            }
        }

        private void buttonSquare_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
            Button square = sender as Button;
            if(m_AiPlaying)
            {
                return;
            }

            myTimer.Tick += new EventHandler(timerEventProcessor);
            myTimer.Interval = 3000;
            if (m_SelectedSquare == null)
            {
                if (Logic.Game.s_CurrentPlayer.IsValidSquare(
                    Logic.Movement.GetCol(square.Name),
                    Logic.Movement.GetRow(square.Name)
                    ))
                {
                    m_SelectedSquare = square;
                    square.BackColor = Color.Aqua;
                }
            }
            else
            {
                if(m_SelectedSquare == square)
                {
                    m_SelectedSquare = null;
                    square.BackColor = default(Color);
                }
                else
                {
                    if(Logic.Game.s_CurrentPlayer.PerformMove(new Logic.Movement(m_SelectedSquare.Name + ">" + square.Name)))
                    {
                        m_SelectedSquare.BackColor = default(Color);
                        m_SelectedSquare = null;
                        updateBoard();
                        if(!Logic.Game.s_CanEat)
                        {
                            Logic.Game.SwitchPlayer();
                            if(Logic.Game.IsATie())
                            {
                                printTie();
                                return;
                            }

                            if(Logic.Game.s_AIPlaying)
                            {
                                m_AiPlaying = true;
                                myTimer.Start();
                            }
                        }
                    }
                }
            }
        }

        private void timerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            (myObject as System.Windows.Forms.Timer).Stop();
            Logic.Game.AIPlay();
            updateBoard();
            Logic.Game.SwitchPlayer();
            m_AiPlaying = false;
            if (Logic.Game.IsATie())
            {
                printTie();
            }
        }

        private void form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }
    }
}
