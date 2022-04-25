using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    public class Pawn
    {
        private int m_Row;
        private int m_Col;
        private PawnType m_Type;
        private bool m_IsKing;

        public Pawn(int i_Col, int i_Row, PawnType i_Type, bool i_IsKing)
        {
            m_Col = i_Col;
            m_Row = i_Row;
            m_Type = i_Type;
            m_IsKing = i_IsKing;
        }

        public int Col { get => m_Col; set => m_Col = value; }
        public int Row { get => m_Row; set => m_Row = value; }
        public PawnType Type { get => m_Type; set => m_Type = value; }
        public bool IsKing { get => m_IsKing; set => m_IsKing = value; }
    }
}
