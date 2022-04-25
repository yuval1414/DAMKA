using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    public class InputFromUser
    {
        public static string NameOfPlayerFromUser(int i_PlayersNumber)
        {
            Console.WriteLine("Please enter player{0} name :", i_PlayersNumber);
            return Console.ReadLine();
        }

        public static int BoardSizeFromUser()
        {
            bool isInvalidInput = true;
            string usersInput = null;
            int boardSize = -1;

            while (boardSize == -1)
            {
                Console.WriteLine("Please choose size of the board :");
                Console.WriteLine("1. 10X10\n2. 8X8\n3.6X6");
                usersInput = Console.ReadLine();
                switch (usersInput)
                {
                    case "1":
                        boardSize = 10;
                        break;
                    case "2":
                        boardSize = 8;
                        break;
                    case "3":
                        boardSize = 6;
                        break;
                    default:
                        boardSize = -1;
                        break;
                }

                if (boardSize == -1)
                {
                    Console.WriteLine("Invalid input please try again");
                }
            }

            return boardSize;
        }

        public static bool DoYouWantAnotherGame()
        {
            string input = "";
            bool anotherGame = false;

            while (input != "y" && input != "n")
            {
                Console.WriteLine("Another game? (Y/N)");
                input = Console.ReadLine().ToLower();
            }

            if (input == "y")
            {
                anotherGame = true;
            }

            return anotherGame;
        }

        public static bool TypeOfgameFromUser()
        {
            string typeOfGame = null;
            bool isAIPlaying = true, isInvalidInput = true;

            while (isInvalidInput)
            {
                Console.WriteLine("Please choose type of game :");
                Console.WriteLine("1. one players game \n2. Two players game");
                typeOfGame = Console.ReadLine();
                isInvalidInput = !isValidGameType(typeOfGame);
            }

            if (int.Parse(typeOfGame) == 1)
            {
                isAIPlaying = true;
            }
            else if (int.Parse(typeOfGame) == 2)
            {
                isAIPlaying = false;
            }

            return isAIPlaying;
        }

        private static bool isValidGameType(string i_TypeOfGame)
        {
            bool isValidGameTypeChoice = true;

            if (i_TypeOfGame != "1" && i_TypeOfGame != "2")
            {
                isValidGameTypeChoice = false;
            }

            return isValidGameTypeChoice;
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