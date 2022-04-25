using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    public class Movement
    {
        private int m_SourceCol;
        private int m_SourceRow;
        private int m_DestinationCol;
        private int m_DestinationRow;
        private bool m_IsEatMove;

        public Movement(string i_RequestForMovement)
        {
            m_SourceCol = char.ToUpper(i_RequestForMovement[0]) - 65;
            m_SourceRow = char.ToUpper(i_RequestForMovement[1]) - 65;
            m_DestinationCol = char.ToUpper(i_RequestForMovement[3]) - 65;
            m_DestinationRow = char.ToUpper(i_RequestForMovement[4]) - 65;
            m_IsEatMove = false;
        }

        public Movement(int i_SourceCol, int i_SourceRow, int i_DestinationCol, int i_DestinationRow, bool i_isEatMove)
        {
            m_SourceCol = i_SourceCol;
            m_SourceRow = i_SourceRow;
            m_DestinationCol = i_DestinationCol;
            m_DestinationRow = i_DestinationRow;
            m_IsEatMove = i_isEatMove;
        }

        public static bool operator ==(Movement move1, Movement move2)
        {
            return move1.SourceCol == move2.SourceCol && move1.SourceRow == move2.SourceRow
                && move1.DestinationCol == move2.DestinationCol && move1.DestinationRow == move2.DestinationRow;
        }

        public static bool operator !=(Movement move1, Movement move2)
        {
            return !(move1.SourceCol == move2.SourceCol && move1.SourceRow == move2.SourceRow
                && move1.DestinationCol == move2.DestinationCol && move1.DestinationRow == move2.DestinationRow);
        }

        public int SourceCol
        {
            get { return m_SourceCol; }
            set { m_SourceCol = value; }
        }

        public int SourceRow
        {
            get { return m_SourceRow; }
            set { m_SourceRow = value; }
        }

        public int DestinationCol
        {
            get { return m_DestinationCol; }
            set { m_DestinationCol = value; }
        }

        public int DestinationRow
        {
            get { return m_DestinationRow; }
            set { m_DestinationRow = value; }
        }

        public bool IsEatMove
        {
            get { return m_IsEatMove; }
            set { m_IsEatMove = value; }
        }
    }
}
