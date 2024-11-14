using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Player
    {
        private List<Pawn> m_PawnList;
        private PawnType m_Type;
        private string m_Name;
        private List<Movement> m_ValidMoves;
        private int m_Score;

        public Player(PawnType i_Type, string i_Name)
        {
            m_PawnList = new List<Pawn>();
            m_Type = i_Type;
            m_Name = i_Name;
            m_ValidMoves = new List<Movement>();
            m_Score = 0;
        }

        public void GetAllValidMovesForPlayer()
        {
            ValidMoves = new List<Movement>();
            m_PawnList.ForEach(pawn =>
            {
                ValidMoves.AddRange(getValidMoves(pawn));
            });
        }

        private List<Movement> getValidMoves(Pawn i_Pawn)
        {
            List<Movement> validMoves = new List<Movement>();

            if (i_Pawn.IsKing)
            {
                validMovesByDirection(i_Pawn, validMoves, 1, 1);
                validMovesByDirection(i_Pawn, validMoves, 1, -1);
                validMovesByDirection(i_Pawn, validMoves, -1, 1);
                validMovesByDirection(i_Pawn, validMoves, -1, -1);
            }
            else if (i_Pawn.Type == PawnType.X)
            {
                validMovesByDirection(i_Pawn, validMoves, 1, -1);
                validMovesByDirection(i_Pawn, validMoves, -1, -1);
            }
            else if (i_Pawn.Type == PawnType.O)
            {
                validMovesByDirection(i_Pawn, validMoves, 1, 1);
                validMovesByDirection(i_Pawn, validMoves, -1, 1);
            }

            return validMoves;
        }

        private void validMovesByDirection(Pawn i_Pawn, List<Movement> io_ValidMoves, int i_ColDirection, int i_RowDirection)
        {
            if (!(i_Pawn.Col + i_ColDirection > Game.s_Board.BoardSize - 1 || i_Pawn.Col + i_ColDirection < 0 ||
                i_Pawn.Row + i_RowDirection > Game.s_Board.BoardSize - 1 || i_Pawn.Row + i_RowDirection < 0))
            {
                if (Game.s_Board.BoardArray[i_Pawn.Col + i_ColDirection, i_Pawn.Row + i_RowDirection] == null)
                {
                    io_ValidMoves.Add(new Movement(i_Pawn.Col, i_Pawn.Row, i_Pawn.Col + i_ColDirection, i_Pawn.Row + i_RowDirection, false));
                }
                else if (Game.s_Board.BoardArray[i_Pawn.Col + i_ColDirection, i_Pawn.Row + i_RowDirection].Type != i_Pawn.Type)
                {
                    if (!(i_Pawn.Col + i_ColDirection * 2 > Game.s_Board.BoardSize - 1 || i_Pawn.Col + i_ColDirection * 2 < 0 ||
                        i_Pawn.Row + i_RowDirection * 2 > Game.s_Board.BoardSize - 1 || i_Pawn.Row + i_RowDirection * 2 < 0))
                    {
                        if (Game.s_Board.BoardArray[i_Pawn.Col + i_ColDirection * 2, i_Pawn.Row + i_RowDirection * 2] == null)
                        {
                            Game.s_CanEat = true;
                            io_ValidMoves.Add(new Movement(i_Pawn.Col, i_Pawn.Row, i_Pawn.Col + i_ColDirection * 2, i_Pawn.Row + i_RowDirection * 2, true));
                        }
                    }
                }
            }
        }

        public bool PerformMove(Movement i_PlayerMove)
        {
            bool isMoveValid = false;

            if (isValidPawnMove(i_PlayerMove))
            {
                isMoveValid = true;
                Pawn playerPawn = Game.s_Board.BoardArray[i_PlayerMove.SourceCol, i_PlayerMove.SourceRow];
                Game.s_Board.BoardArray[i_PlayerMove.SourceCol, i_PlayerMove.SourceRow] = null;
                Game.s_Board.BoardArray[i_PlayerMove.DestinationCol, i_PlayerMove.DestinationRow] = playerPawn;
                playerPawn.Col = i_PlayerMove.DestinationCol;
                playerPawn.Row = i_PlayerMove.DestinationRow;
                if (Game.s_CanEat)
                {
                    Game.DeleteEatenPawn(i_PlayerMove.SourceCol + (i_PlayerMove.DestinationCol - i_PlayerMove.SourceCol) / 2,
                        i_PlayerMove.SourceRow + (i_PlayerMove.DestinationRow - i_PlayerMove.SourceRow) / 2);
                }

                checkAndTurnToKing(playerPawn);
                Ex02.ConsoleUtils.Screen.Clear();
                Game.s_Board.PrintBoard();
                InputFromUser.PrintLastMovePreformed(this, i_PlayerMove);
                if (Game.s_CanEat)
                {
                    Game.s_CanEat = false;
                    ValidMoves = getValidMoves(playerPawn);
                    /*if (Game.s_CanEat)
                    {
                        while (!PerformMove(new Movement(InputFromUser.PlayerChooseMove(this))))
                        {
                            Console.WriteLine("Invalid move");
                        }
                    }*/
                }
            }

            return isMoveValid;
        }

        private void checkAndTurnToKing(Pawn i_PlayerPawn)
        {
            if (i_PlayerPawn.Type == PawnType.X && i_PlayerPawn.Row == 0)
            {
                i_PlayerPawn.IsKing = true;
            }

            if (i_PlayerPawn.Type == PawnType.O && i_PlayerPawn.Row == Game.s_Board.BoardSize - 1)
            {
                i_PlayerPawn.IsKing = true;
            }
        }

        public bool IsValidSquare(int i_Col, int i_Row)
        {
            return ValidMoves.Any(move =>
            {
                return move.SourceCol == i_Col && move.SourceRow == i_Row && (move.IsEatMove || !Game.s_CanEat);
            });
        }

        private bool isValidPawnMove(Movement i_PlayerMove)
        {
            return ValidMoves.Any(move =>
            {
                bool result = false;

                if (Game.s_CanEat && move.IsEatMove && move == i_PlayerMove)
                {
                    result = true;
                }
                else if (!Game.s_CanEat && move == i_PlayerMove)
                {
                    result = true;
                }

                return result;
            });
        }

        public bool IsNoMovements()
        {
            return ValidMoves.Count == 0;
        }

        public bool IsNoMorePawns()
        {
            return PawnList.Count == 0;
        }

        public List<Pawn> PawnList { get => m_PawnList; set => m_PawnList = value; }
        public PawnType Type { get => m_Type; set => m_Type = value; }
        public string Name { get => m_Name; set => m_Name = value; }
        public List<Movement> ValidMoves { get => m_ValidMoves; set => m_ValidMoves = value; }
        public int Score { get => m_Score; set => m_Score = value; }
    }
}
