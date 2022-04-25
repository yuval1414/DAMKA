using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    public class Board
    {
        private Pawn[,] m_BoardArray;
        private int m_BoardSize = 0;

        public Board(int i_BoardSize, List<Pawn> i_PlayerXList, List<Pawn> i_PlayerOList)
        {
            CreatBoard(i_BoardSize);
            InitializePieces(i_BoardSize, i_PlayerXList, i_PlayerOList);
        }

        public Pawn[,] BoardArray
        {
            get { return m_BoardArray; }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        public void CreatBoard(int i_BoardSize)
        {
            m_BoardArray = new Pawn[i_BoardSize, i_BoardSize];
            m_BoardSize = m_BoardArray.GetLength(0);

            for (int col = 0; col < i_BoardSize; col++)
            {
                for (int row = 0; row < i_BoardSize; row++)
                {
                    m_BoardArray[col, row] = null;
                }
            }
        }

        public void InitializePieces(int i_BoardSize, List<Pawn> i_PlayerXList, List<Pawn> i_PlayerOList)
        {
            int linesOfPawns = (i_BoardSize - 2) / 2;
            int currentRow = 1;
            i_PlayerXList.Clear();
            i_PlayerOList.Clear();

            for (int col = 0; col < i_BoardSize; col++)
            {
                if (col % 2 == 0)
                {
                    currentRow = 1;
                }
                else if (col % 2 == 1)
                {
                    currentRow = 0;
                }

                for (int row = currentRow; row < i_BoardSize; row += 2)
                {
                    if (row > linesOfPawns + 1)
                    {
                        m_BoardArray[col, row] = new Pawn(col, row, PawnType.X, false);
                        i_PlayerXList.Add(m_BoardArray[col, row]);
                    }
                    else if (row < linesOfPawns)
                    {
                        m_BoardArray[col, row] = new Pawn(col, row, PawnType.O, false);
                        i_PlayerOList.Add(m_BoardArray[col, row]);
                    }
                }
            }
        }

        public void PrintBoard()
        {
            int boardSize = m_BoardArray.GetLength(0);

            for (int i = 0; i < boardSize; i++)
            {
                Console.Write("   {0}  ", (char)('A' + i));
            }

            Console.Write("\n  ");
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write("======");
            }

            Console.Write("\n");
            for (int i = 0; i < boardSize; i++)
            {
                Console.Write("{0}| ", (char)('a' + i));
                for (int j = 0; j < boardSize; j++)
                {
                    if (m_BoardArray[j, i] != null)
                    {

                        if (m_BoardArray[j, i].IsKing && m_BoardArray[j, i].Type == PawnType.X)
                        {
                            Console.Write(" K  | ");
                        }
                        else if (m_BoardArray[j, i].IsKing && m_BoardArray[j, i].Type == PawnType.O)
                        {
                            Console.Write(" U  | ");
                        }
                        else
                        {
                            Console.Write(" {0}  | ", m_BoardArray[j, i].Type);
                        }
                    }
                    else
                    {
                        Console.Write("    | ");
                    }
                }

                Console.Write("\n  ");
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write("======");
                }

                Console.Write("\n");
            }
        }
    }
}
