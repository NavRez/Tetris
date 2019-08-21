//Author : Navid Reza
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Tetris {

    class TetrisGame {

        public static void Main(String[] args) {

            Console.WriteLine("Hello There, this is my very own adaptation of tetris. Which difficulty would you like to play ? ");//outputs a screen of options for the player
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.WriteLine("4. Impossible");
            String number = Console.ReadLine();
            int truenumber;
           

            while (!Int32.TryParse(number, out truenumber) || Int32.Parse(number) > 4 || Int32.Parse(number) < 1) {//loops until a correct input is chosen

                Console.WriteLine("Error Invalid Input, Enter a correct number :");
                number = Console.ReadLine();

            }
            int difficulty = 0;
            int caserdeal = 0;
            switch (truenumber) {//using the truenumber, it defines the speed of the game in miliseconds, each case represents the time it will take for the screen to blink, the slower, the easier

                case 1:
                    difficulty = 800;
                    caserdeal = 1;
                    break;
                case 2:
                    difficulty = 500;
                    caserdeal = 2;
                    break;
                case 3:
                    difficulty = 200;
                    caserdeal = 3;
                    break;
                case 4:
                    difficulty = 20;
                    caserdeal = 4;
                    break;
                default:
                    //It should never come here
                    break;


            }
        
            
            MusicPlayer.MusicList box = new MusicPlayer.MusicList();//creates a visual basic class called music player, this is because of the MusicPlayer.dll imported from VB.net
            Console.Clear();//clears the option screen
            box.PlayMusicBackground();//plays the music
            int na = 0;//creates an integer "not ahead" to make sure the game continues to loop, see while loop below
            Boardwork board = new Boardwork();// the boardwork class is invoked to create a new board
            board.setmultipler(caserdeal);
            board.fillboard();// board is filled
            board.genetateblock();//generates a tetris block
            System.Threading.Thread.Sleep(1150);// delays output for 1150 ms to allow music to kick in 
            while (board.getender())//loops until na is not -1, the minus 1 is still not implemented and will be later
            {
                
                board.printboard();//prints board
                                   //System.Threading.Thread.Sleep(difficulty);//delay the clearscrin resolution

                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

                stopwatch.Start();
                while (stopwatch.Elapsed < TimeSpan.FromMilliseconds(difficulty))
                {
      
                        board.playermove(difficulty);
                  

                }
                
                stopwatch.Stop();
                Console.Clear();
                //board.Blockrotate();//the rotate option is put here to test the rotation, the validation of movements , rotation, and falls aren't done yet and should be done ASAP 


                board.BlockFall();
               


            }
            box.EndMusic();//ends music upon end of game
            board.printboard();
            Console.ReadKey();//prompts user to enter a random key

        }

    }

}
