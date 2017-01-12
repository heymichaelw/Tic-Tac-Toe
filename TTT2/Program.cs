using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT2
{
    class Program
    {


        //drawboard method
        static void DrawBoard(string[] board)
        {
            int counter = 0;
            foreach (string place in board)
            {
                Console.Write(" " + place);
                if (counter == 2)
                {
                    Console.WriteLine("");
                    counter = 0;
                }
                else
                {
                    counter++;
                }
            }
        }

        //checking space selection

        //I hate to submit an incomplete project, but this is the one part I could not figure out.  When a player chooses a space that has already been taken, it won't fill in the space
        //but it switches to the other player's turn.  I tried to put the whole method in a while loop and set the bool equal to false in the "else" and couldn't get it to work.  Perhaps there
        //is a way that I can send the player back to the beginning of their turn if their selection is invalid, or to have the program just redraw the board.  I will gladly resubmit this project
        //once I've read your comments.  
   
        
        static string[] CheckSpace(string space, string turn, string[] board)
        {
            
                int spaceint = int.Parse(space);
                if (space == board[spaceint])
                {
                    board[spaceint] = turn == "player1" ? "X" : "O";
                }
                else
                {
                Console.WriteLine("Sorry, that is not a valid location.");
                
                }
                return board;
            
        } 


        //checking game state

        static bool CheckGameState(string[] board, string player)
        {
            bool hasWon = false;

            

            if (board[0] != "0" && board[1] != "1" && board[2] != "2" && board[3] != "3" && board[4] != "4" && board[5] != "5" && board[6] != "6" && board[7] != "7" && board[8] != "8")
            {
                Console.WriteLine("This game was a draw!");
                hasWon = true;
                
            }
            else if ((board[0] == board[3]) && (board[3] == board[6]) || (board[1] == board[4]) && (board[4] == board[7]) || (board[2] == board[5]) && (board[5] == board[8]))
            {
                Console.WriteLine($"Congratulations! {player} has won!");
                 hasWon = true;
            }
            else if ((board[0] == board[1]) && (board[1] == board[2]) || (board[3] == board[4]) && (board[4] == board[5]) || (board[6] == board[7]) && (board[7] == board[8]))
            {
                Console.WriteLine($"Congratulations! {player} has won!");
                 hasWon = true;
            }
            else if ((board[0] == board[4]) && (board[4] == board[8]) || (board[2] == board[4]) && (board[4] == board[6]))
            {
                Console.WriteLine($"Congratulations! {player} has won!");
                 hasWon = true;
            }
            return hasWon;
            
        }           
        

        //changing player

        //I'm sure that my problem is either in here or in the check game state section.  If I could somehow request two arguments from the ChangeGameState method, I could set a variable
        //there and request it here to keep the player the same if the space is taken.  I attempted "out" modifiers and get, set but couldn't quite figure it out.  Or, maybe I could call 
        //an instance of ChangeGameState in itself to use its return to redefine turn?  
        static string PlayerChange(string turn)
        {
            if (turn == "player1")
            {
                turn = "player2";
            }
            else
            {
                turn = "player1";
            }
            return turn;           
        }

        //assigning player name

        //This section was so unnecessary after all.  I could've just set turn to "Player 1" instead and displayed that...
        static string playerName(string turn, string player)
        {
            if (turn == "player1")
            {
                player = "Player 1";
            }
            else
            {
                player = "Player 2";
            }
            return player;
        }

        //actual game
        static void Main(string[] args)
        {
            string turn = "player1";
            string[] board = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
            bool hasWon = false;
            string player = "Player 1";

            DrawBoard(board);
            while (hasWon == false)
            {
                player = playerName(turn, player);
                Console.WriteLine($"It is {player}'s turn" );
                Console.WriteLine("Please select a valid space (0-8) for your symbol");
                string space = Console.ReadLine();
                CheckSpace(space, turn, board);                         //or the problem lies here.  I need some type of check after this line, and if it comes out one way the user needs to be sent back to the beginning of the program.  But, I believe that would require ChangeGameState to return two arguments.
                DrawBoard(board);
                hasWon = CheckGameState(board, player);
                turn = PlayerChange(turn);
               
                



            }
        }
    }
}
