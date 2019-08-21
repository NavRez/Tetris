//Author : Navid Reza

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tetris//namespace of the file
{
    public class Boardwork
    {

        public void fillboard() {//cretes the intial empty matrix

            for (int i = 0; i < MAX_ROW; i++)//for every row, insert the empty cols
            {
                List<int> temprow = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                boardmatrix.Add(temprow);//inserts the empty row for every value of the list boardmatrix

            }

        }

        public void genetateblock() {//generates a tetris block using the tetrisblock classes

            Random rand = new Random();//allows the creation of a Random number generator 

            if (generated == -1 && nextgenerated == -1)
            {

                generated = rand.Next(7);//generates a number between 0 and 7, this is used for all 7 tetris blocks
                nextgenerated = rand.Next(7);//generates a number between 0 and 7, this is used for all 7 tetris blocks


            }
            else {
                generated = nextgenerated;
                nextgenerated = rand.Next(7);//generates a number between 0 and 7, this is used for all 7 tetris blocks

            }
            //generated = rand.Next(7);




            //generated = 6;
            regenerate(rand);
            //test case for tetris block zero


            int dot = 4;//dot is an intger used to map out the initial point of a falling block to make sure it's not on the edge
            switch (generated) {

                case 0:

                    first = new TetrisBlock(0, dot, 0, dot - 1, 0, dot + 1, 1, dot);//maps out the falling tetris block

                    if (boardmatrix[0][dot] == 1 || boardmatrix[0][dot - 1] == 1 || boardmatrix[0][dot + 1] == 1 || boardmatrix[1][dot] == 1) {

                        setender(false);

                    }

                    break;
                case 1:
                    first = new TetrisBlock(1, dot, 0, dot - 1, 1, dot + 1, 0, dot);

                    if (boardmatrix[1][dot] == 1 || boardmatrix[0][dot - 1] == 1 || boardmatrix[1][dot + 1] == 1 || boardmatrix[0][dot] == 1){

                        setender(false);

                    }
                    break;
                case 2:
                    first = new TetrisBlock(1, dot, 1, dot - 1, 0, dot + 1, 0, dot);
                    if (boardmatrix[1][dot] == 1 || boardmatrix[1][dot - 1] == 1 || boardmatrix[0][dot + 1] == 1 || boardmatrix[0][dot] == 1)
                    {

                        setender(false);

                    }
                    break;
                case 3:
                    first = new TetrisBlock(0, dot, 0, dot - 1, 0, dot + 1, 1, dot -1);
                    if (boardmatrix[0][dot] == 1 || boardmatrix[0][dot - 1] == 1 || boardmatrix[0][dot + 1] == 1 || boardmatrix[1][dot -1] == 1)
                    {

                        setender(false);

                    }
                    break;
                case 4:
                    first = new TetrisBlock(0, dot, 0, dot - 1, 0, dot + 1, 1, dot + 1);
                    if (boardmatrix[0][dot] == 1 || boardmatrix[0][dot - 1] == 1 || boardmatrix[0][dot + 1] == 1 || boardmatrix[1][dot+1] == 1)
                    {

                        setender(false);

                    }
                    break;
                case 5:
                    first = new TetrisBlock(0, dot, 0, dot - 1, 0, dot + 1, 0, dot-2);
                    if (boardmatrix[0][dot] == 1 || boardmatrix[0][dot - 1] == 1 || boardmatrix[0][dot + 1] == 1 || boardmatrix[0][dot-2] == 1)
                    {

                        setender(false);

                    }
                    break;
                case 6:
                    first = new TetrisBlock(0, dot, 0, dot - 1, 1, dot, 1, dot - 1);
                    if (boardmatrix[0][dot] == 1 || boardmatrix[0][dot - 1] == 1 || boardmatrix[1][dot + 1] == 1 || boardmatrix[1][dot - 1] == 1)
                    {

                        setender(false);

                    }
                    first.setvalid(false);//prevents tetris block from rotating because it is the square block
                    break;
                default:
                    break;

            }


        }

        public void BlockFall() {//allows a falling block to fall down, if conditions are still missing, must edit after final exams

            try
            {
                if ((boardmatrix[first.getlrow() + 1][first.getlcol()] != 1 && boardmatrix[first.getrrow() + 1][first.getrcol()] != 1 && boardmatrix[first.getorow() + 1][first.getocol()] != 1 && boardmatrix[first.getcenterrow() + 1][first.getcentercol()] != 1) && (first.getcenterrow() < 20 && first.getorow() < 20 && first.getrrow() < 20 && first.getlrow() < 20))
                {
                    first.moveblock();

                }
                else
                {
                    boardmatrix[first.getlrow()][first.getlcol()] = 1;
                    boardmatrix[first.getrrow()][first.getrcol()] = 1;
                    boardmatrix[first.getorow()][first.getocol()] = 1;
                    boardmatrix[first.getcenterrow()][first.getcentercol()] = 1;


                    genetateblock();

                }
            }
            catch (Exception e) {

                boardmatrix[first.getlrow()][first.getlcol()] = 1;
                boardmatrix[first.getrrow()][first.getrcol()] = 1;
                boardmatrix[first.getorow()][first.getocol()] = 1;
                boardmatrix[first.getcenterrow()][first.getcentercol()] = 1;

                genetateblock();

            }


        }

        public void deleterow() {
            counter = 0;
            for (int i = 0; i < MAX_ROW; i++) {//loops through the rows
                int c = 0;//block counter
                for (int j = 0; j < MAX_COL; j++) {//loops through the cols

                    if (boardmatrix[i][j] == 1) {//checks to see if there is a block 
                        c++;//increase block counter
                    }
                }

                if (c == 10) {//if an entire row is full of blocks
                    boardmatrix.RemoveAt(i);//remove the entire row
                    List<int> temprow = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//create a new empty row and add it
                    boardmatrix.Insert(0,temprow);
                    counter++;//increment the counter of rows eliminated 

                }



            }

            switch (counter)
            {

                case 1:
                    score += 40 * multipler;//if one row is eliminated, add forty points and multiply by multiplyer
                    break;
                case 2:
                    score += 100 * multipler;//if one row is eliminated, add hundred points and multiply by multiplyer
                    break;
                case 3:
                    score += 300 * multipler;//if one row is eliminated, add three hundred points and multiply by multiplyer
                    break;
                case 4:
                    score += 1200 * multipler;//if one row is eliminated, add twelve hundred points and multiply by multiplyer
                    break;
                default:
                    break;
            }
            counter = 0;//reset counter to zero 


        }
        public void Blockrotate() {//allows the rotation of a block 

            first.rotate();//rotate block 
            try
            {
                if ((boardmatrix[first.getcenterrow() + 1][first.getcentercol()] == 1 || boardmatrix[first.getlrow()+1][first.getlcol()] == 1 || boardmatrix[first.getrrow()+1][first.getrcol()] == 1 || boardmatrix[first.getorow()+1][first.getocol()] == 1) || (boardmatrix[first.getlrow()][first.getlcol()] == 1 || boardmatrix[first.getrrow()][first.getrcol()] == 1 || boardmatrix[first.getorow()][first.getocol()] == 1) || (first.getcenterrow() > 20 && first.getorow() > 20 && first.getrrow() > 20 && first.getlrow() > 20))// if block rotation interferes with another block or is beyond the boundaries
                {

                    first.resetorgs();//restore the original coordinates 
                }
            }
            catch (Exception e) {

                first.resetorgs();//if an error was caught, restore the original block
            }
            
        }

        public void playermove(int time)
        {
            

            if (Console.KeyAvailable) {

                ConsoleKeyInfo cki = Console.ReadKey();


                switch (cki.Key) {


                    case ConsoleKey.LeftArrow:
                        if (cki.Key == ConsoleKey.LeftArrow && (first.getcentercol() != 0 && first.getlcol() != 0 && first.getrcol() != 0 && first.getocol() != 0) && boardmatrix[first.getlrow()][first.getlcol() - 1] != 1 && boardmatrix[first.getrrow()][first.getrcol() - 1] != 1 && boardmatrix[first.getorow()][first.getocol() - 1] != 1 && boardmatrix[first.getcenterrow()][first.getcentercol() - 1] != 1)
                        {
                            first.setlcol(first.getlcol() - 1);
                            first.setrcol(first.getrcol() - 1);
                            first.setocol(first.getocol() - 1);
                            first.setcentercol(first.getcentercol() - 1);
                            Console.Clear();
                            printboard();
                            System.Threading.Thread.Sleep(20);

                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (cki.Key == ConsoleKey.RightArrow && (first.getcentercol() != 9 && first.getlcol() != 9 && first.getrcol() != 9 && first.getocol() != 9) && boardmatrix[first.getlrow()][first.getlcol() + 1] != 1 && boardmatrix[first.getrrow()][first.getrcol() + 1] != 1 && boardmatrix[first.getorow()][first.getocol() + 1] != 1 && boardmatrix[first.getcenterrow()][first.getcentercol() + 1] != 1)
                        {
                            first.setlcol(first.getlcol() + 1);
                            first.setrcol(first.getrcol() + 1);
                            first.setocol(first.getocol() + 1);
                            first.setcentercol(first.getcentercol() + 1);
                            Console.Clear();
                            printboard();
                            System.Threading.Thread.Sleep(20);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        BlockFall();
                        Console.Clear();
                        printboard();
                        System.Threading.Thread.Sleep(50);
                        break;
                    case ConsoleKey.Spacebar:
                        Blockrotate();
                        Console.Clear();
                        printboard();
                        break;
                    case ConsoleKey.P:
                        Console.ReadKey();
                        break;
                    default:
                        ;//
                        break;

                }

                


            }


       

        }

        public void looper() {//the idea of looper is to loop and change output til the end of the game, it isn't working because there are still tests to do on rotate 
            while (true)
            {
                first.rotate();
                Console.Clear();
                printboard();
                System.Threading.Thread.Sleep(75);
            }
        }

        public void printboard() {

            deleterow();

            //BlockFall();
            for (int i = 0; i < MAX_ROW; i++)//loops through the total row size of board
            {

                if (i % 2 == 0)//if this is the beginning of the row and row is an even number, place a backslash
                {

                    Console.Write("/");

                }
                else {

                    Console.Write(@"\");//if this is the beginning of the row and row is an even odd, place a foreslash

                }

                Console.Write(" |");//sets the delimitation of each block
                for (int j = 0; j < MAX_COL; j++)
                {
                if ((first.getcenterrow() == i && first.getcentercol() == j) || (first.getlrow() == i && first.getlcol() == j) || (first.getrrow() == i && first.getrcol() == j) || (first.getorow() == i && first.getocol() == j) || boardmatrix[i][j] == 1)// checks to see if there is a falling tetris block in any of the ith rows and jth columns
                    {

                        Console.Write("[X]");//outputs block

                    }
                    else if (boardmatrix[i][j] == 0)//checks to see if the board has an empty space
                    {

                        Console.Write(" . ");//outputs a dot if it's the case
                    }

                }

                Console.Write("|");//sets delimitation of each block

                if (i % 2 == 0)//at the end of the row, checks to see if the row is odd or even
                {

                    Console.WriteLine(@" \");//outputs forslash if it's the case

                }
                else
                {

                    Console.WriteLine(" /");//outputs backslash otherwise

                }

            }

            String sco = "Score : ";

            Console.WriteLine("( [______________________________] )");//outputs the last layer of delimitation in the console's output
            Console.Write("{0}", sco);
            Console.WriteLine(score);

            if (ender)//if the game is not over
            {
                Console.WriteLine("\nNext Block");//print the next block that will appear 
                switch (nextgenerated)
                {

                    case 0:
                        Console.WriteLine("[X][X][X]\n   [X]");
                        break;
                    case 1:
                        Console.WriteLine("[X][X]\n   [X][X]");
                        break;
                    case 2:
                        Console.WriteLine("   [X][X]\n[X][X]");
                        break;
                    case 3:
                        Console.WriteLine("[X][X][X]\n[X]");
                        break;
                    case 4:
                        Console.WriteLine("[X]\n[X][X][X]");
                        break;
                    case 5:
                        Console.WriteLine("[X][X][X][X]");
                        break;
                    case 6:
                        Console.WriteLine("[X][X]\n[X][X]");
                        break;
                    default:
                        break;
                }
            }
            else {//if not print game over
                String cont = "Press any Key to continue...";
                Console.WriteLine("Game Over\n\n{0}",cont);
                
            }
           
        }


        public void regenerate(Random rand) {//generates a random block to fall

            if (gencheck == -1)//if the game has just began 
            {

                gencheck = nextgenerated;//set the next blockchecker to the generator check
            }
            else {

                while (gencheck == nextgenerated || (gencheck == 1 && nextgenerated ==2) || (gencheck == 1 && nextgenerated == 2) || (gencheck == 3 && nextgenerated == 4) || (gencheck == 4 && nextgenerated == 3)) {// if next block is the same as the one just generated or isomorphic
                    nextgenerated = rand.Next(7);//regenerate block
                }

                gencheck = nextgenerated;//set the falling block to the checker

            }

        }

        public bool getender() {//gets the key to check if game should end

            return ender;
        }

        public void setender(bool b) {//sets the bool value as to whether or not the game should continue

            ender = b;

        }

        public void setmultipler(int num) {//cretaes a multiplier of score based on difficulty

            switch (num) {

                case 1:
                    multipler = 1;//level 1
                    break;
                case 2:
                    multipler = 10;//level 2
                    break;
                case 3:
                    multipler = 30;//level 3
                    break;
                case 4:
                    multipler = 1000;//level 4
                    break;
                default:
                    break;

            }
        }

        


        protected const int MAX_ROW = 20;//total num of rows
        protected const int MAX_COL = 10;//total num of cols
        public List<List<int>> boardmatrix = new List<List<int>>();//the boardmatrix is the matrix that is used to map the game, a Listmatrix was chosen because of their dynamic nature to insert and delete columns and rows
        protected List<int> emptyrow = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//empty row holds a row of empty boxes
        protected List<int> fullrow = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };//full row golds a row of full boxes, the idea is to delete them if it's full 
        protected bool candrop = true;
        protected int generated = -1;
        protected int nextgenerated = -1;
        protected int gencheck = -1;
        protected bool ender = true;
        protected int counter = 0;
        protected int score = 0;
        protected int multipler;


        protected TetrisBlock first = new TetrisBlock();//this is used to generate a falling block
        protected TetrisBlock second = new TetrisBlock();// this is used to hold the next block that will be generated and to generate new blocks, it still isn't implemented in the cod yet
    }

   
}
