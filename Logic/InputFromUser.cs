using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class InputFromUser
    {
        public static int s_BoardSize;
        public static int s_NumberOfPlayers;
        public static string s_Player1Name;
        public static string s_Player2Name;

        public static string NameOfPlayerFromUser(int i_PlayersNumber)
        {
            if (i_PlayersNumber == 1)
            {
                return s_Player1Name;
            }
            else if (i_PlayersNumber == 2)
            {
                return s_Player2Name;
            }
            else
            {
                throw new ArgumentException("player number should be 1 or 2");
            }
        }

        public static int BoardSizeFromUser()
        {
            return s_BoardSize;
        }

        public static bool TypeOfgameFromUser()
        {
            if(s_NumberOfPlayers == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string PlayerChooseMove(Player i_CurrentPlayer)
        {
            bool invalidInput = true;
            string requestForMovement = null;

            Console.WriteLine("{0} your turn ({1}) :", i_CurrentPlayer.Name, i_CurrentPlayer.Type);
            while (invalidInput)
            {
                Console.WriteLine("choose a move by entering a COLrow>COLrow");
                requestForMovement = Console.ReadLine();
                if (invalidInput = !isValidInputForMovement(requestForMovement))
                {
                    Console.WriteLine("Invalid input please try again");
                }
            }

            return requestForMovement;
        }

        private static bool isValidInputForMovement(string i_RequestForMovement)
        {
            bool isValid = false;

            if (i_RequestForMovement == "Q")
            {
                isValid = true;
            }
            else
            {
                if (i_RequestForMovement.Length == 5)
                {
                    char sourceFirst = i_RequestForMovement[0];
                    char sourceLast = i_RequestForMovement[1];
                    char seperation = i_RequestForMovement[2];
                    char destFirst = i_RequestForMovement[3];
                    char destLast = i_RequestForMovement[4];

                    isValid = char.IsUpper(sourceFirst) && char.IsUpper(destFirst) && char.IsLower(sourceLast)
                    && char.IsLower(destLast) && seperation.Equals('>');
                }
            }

            return isValid;
        }

        public static void PrintLastMovePreformed(Player i_CurrentPlayer, Movement i_LastMove)
        {
            string lastMoveString = "";

            lastMoveString += (char)(i_LastMove.SourceCol + 'A');
            lastMoveString += (char)(i_LastMove.SourceRow + 'a');
            lastMoveString += ">";
            lastMoveString += (char)(i_LastMove.DestinationCol + 'A');
            lastMoveString += (char)(i_LastMove.DestinationRow + 'a');

            Console.WriteLine("{0}'s move was ({1}): {2}", i_CurrentPlayer.Name, i_CurrentPlayer.Type, lastMoveString);
        }

        public static void PrintWin(Player i_WinningPlayer, Player i_LosingPlayer)
        {

            Console.WriteLine("{0} WON! score: {0}:{1}, {2}:{3}",
                i_WinningPlayer.Name, i_WinningPlayer.Score, i_LosingPlayer.Name, i_LosingPlayer.Score);
        }

        public static void PrintTie(Player Player1, Player Player2)
        {
            Console.WriteLine("Its a tie!score: {0}:{1}, {2}:{3}",
                Player1.Name, Player1.Score, Player2.Name, Player2.Score);
        }
    }
}