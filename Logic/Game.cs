using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Game
    {
        public static Board s_Board = null;
        public static bool s_AIPlaying = true;
        public static Player s_PlayerX = new Player(PawnType.X, null);
        public static Player s_PlayerO = new Player(PawnType.O, "AI");
        public static Player s_CurrentPlayer = s_PlayerX;
        public static bool s_CanEat = false;
        private static bool s_NoMoves = false;

        public static void CreateNewGame()
        {
            s_PlayerX.Name = InputFromUser.NameOfPlayerFromUser(1);
            s_Board = new Board(InputFromUser.BoardSizeFromUser(), s_PlayerX.PawnList, s_PlayerO.PawnList);
            s_AIPlaying = InputFromUser.TypeOfgameFromUser();
            if (!s_AIPlaying)
            {
                s_PlayerO.Name = InputFromUser.NameOfPlayerFromUser(2);
            }
            s_CurrentPlayer = s_PlayerX;
        }

        private static void runGame()
        {
            bool gameRuning = true;
            string input = "";
            Random random = new Random();

            s_Board.PrintBoard();
            //each while loop is one move for both players
            while (gameRuning)
            {
                s_CanEat = false;
                s_CurrentPlayer.GetAllValidMovesForPlayer();

                if (s_NoMoves && s_CurrentPlayer.ValidMoves.Count > 0)
                {
                    if (s_CurrentPlayer.Type == PawnType.X)
                    {
                        s_PlayerX.Score += calculateScore(s_PlayerX, s_PlayerO);
                        InputFromUser.PrintWin(s_PlayerX, s_PlayerO);
                    }
                    else
                    {
                        s_PlayerO.Score += calculateScore(s_PlayerO, s_PlayerX);
                        InputFromUser.PrintWin(s_PlayerO, s_PlayerX);
                    }

                    break;
                }

                if (IsATie())
                {
                    InputFromUser.PrintTie(s_PlayerX, s_PlayerO);
                    break;
                }

                if (!s_NoMoves)
                {
                    if (s_CurrentPlayer.Type == PawnType.O && s_AIPlaying)
                    {
                        if (s_CanEat)
                        {
                            s_CurrentPlayer.ValidMoves = s_CurrentPlayer.ValidMoves.FindAll(move =>
                            {
                                return move.IsEatMove;
                            });
                        }

                        System.Threading.Thread.Sleep(3000);
                        s_CurrentPlayer.PerformMove(s_CurrentPlayer.ValidMoves[random.Next(s_CurrentPlayer.ValidMoves.Count)]);
                    }
                    else
                    {
                        input = InputFromUser.PlayerChooseMove(s_CurrentPlayer);
                        if (input == "Q")
                        {
                            if (s_CurrentPlayer.Type == PawnType.O)
                            {
                                s_PlayerX.Score += calculateScore(s_PlayerX, s_PlayerO);
                                InputFromUser.PrintWin(s_PlayerX, s_PlayerO);
                            }
                            else
                            {
                                s_PlayerO.Score += calculateScore(s_PlayerO, s_PlayerX);
                                InputFromUser.PrintWin(s_PlayerO, s_PlayerX);
                            }

                            break;
                        }

                        while (!s_CurrentPlayer.PerformMove(new Movement(input)))
                        {
                            Console.WriteLine("Invalid move");
                            input = InputFromUser.PlayerChooseMove(s_CurrentPlayer);
                        }
                    }
                }

                if (s_CurrentPlayer == s_PlayerX)
                {
                    if (s_PlayerO.PawnList.Count == 0)
                    {
                        s_PlayerX.Score += calculateScore(s_PlayerX, s_PlayerO);
                        InputFromUser.PrintWin(s_PlayerX, s_PlayerO);
                        break;
                    }

                    s_CurrentPlayer = s_PlayerO;
                }
                else
                {
                    if (s_PlayerX.PawnList.Count == 0)
                    {
                        s_PlayerO.Score += calculateScore(s_PlayerO, s_PlayerX);
                        InputFromUser.PrintWin(s_PlayerO, s_PlayerX);
                        break;
                    }

                    s_CurrentPlayer = s_PlayerX;
                }
            }
        }

        public static bool IsATie()
        {
            bool isTie = false;

            if (s_CurrentPlayer.IsNoMovements())
            {
                if (s_NoMoves)
                {
                    isTie = true;
                }

                s_NoMoves = true;
            }
            else
            {
                s_NoMoves = false;
            }

            return isTie;
        }

        public static void DeleteEatenPawn(int i_Col, int i_Row)
        {
            Pawn pawn = s_Board.BoardArray[i_Col, i_Row];

            s_Board.BoardArray[i_Col, i_Row] = null;
            if (pawn.Type == PawnType.X)
            {
                s_PlayerX.PawnList.Remove(pawn);
            }
            if (pawn.Type == PawnType.O)
            {
                s_PlayerO.PawnList.Remove(pawn);
            }
        }

        private static int calculateScore(Player i_WinningPlayer, Player i_LosingPlayer)
        {
            int score = 0;

            i_LosingPlayer.PawnList.ForEach(pawn =>
            {
                score -= pawn.IsKing ? 4 : 1;
            });

            i_WinningPlayer.PawnList.ForEach(pawn =>
            {
                score += pawn.IsKing ? 4 : 1;
            });

            return score;
        }

        public static void SwitchPlayer()
        {
            if(s_CurrentPlayer == s_PlayerX)
            {
                s_CurrentPlayer = s_PlayerO;
            } else
            {
                s_CurrentPlayer = s_PlayerX;
            }
            s_CurrentPlayer.GetAllValidMovesForPlayer();
        } 
        
        public static void AIPlay()
        {
            Random random = new Random();
            if (s_CanEat)
            {
                s_CurrentPlayer.ValidMoves = s_CurrentPlayer.ValidMoves.FindAll(move =>
                {
                    return move.IsEatMove;
                });
            }

            s_CurrentPlayer.PerformMove(s_CurrentPlayer.ValidMoves[random.Next(s_CurrentPlayer.ValidMoves.Count)]);
        }
    }
}
