//Author : Navid Reza
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisBlock
    {



        protected int centerrow;// holds the row of the central block
        protected int centercol;// holds the col of the central block

        protected int lcol;//holds the col of a block designed as left
        protected int lrow;//holds the row of a block designed as left

        protected int rcol;//holds the col of a block designed as right
        protected int rrow;//holds the row of a block designed as left

        protected int ocol;//holds the col of a block designed as other
        protected int orow;//holds the row of a block designed as other


        protected int copycenterrow;// holds the row of the central block
        protected int copycentercol;// holds the col of the central block

        protected int copylcol;//holds the col of a block designed as left
        protected int copylrow;//holds the row of a block designed as left

        protected int copyrcol;//holds the col of a block designed as right
        protected int copyrrow;//holds the row of a block designed as left

        protected int copyocol;//holds the col of a block designed as other
        protected int copyorow;//holds the row of a block designed as other

        bool valid;

        public TetrisBlock() {//when creating a tetris block, sets all the potential blocks as negative 1

            lcol = rcol = rrow = lrow = orow = ocol = centerrow = centercol =-1;
        }
        public TetrisBlock(int cl, int cr, int ll, int lr, int rl, int rr, int ol, int or) {//

           centerrow = cl;
           centercol = cr;

           lrow = ll;
           lcol = lr;

           rrow = rl;
           rcol = rr;

           orow = ol;
           ocol = or;
           valid = true;

    }


        protected int[,] rotationmatrix = { { 0, -1 }, { 1, 0 } };//creates a 2 by 2 matrix called the rotation matrix, it is used in the rotation algorithm 

        public void setvalid(bool v) {

            valid = v;
        }

        public void setcenterrow(int num) {

            centerrow = num;

        }

        public int getcenterrow()
        {

            return centerrow;

        }

        public void moveblock() {

            centerrow++;
            orow++;
            lrow++;
            rrow++;

        }


        public void setcopys() {

            copycenterrow = centerrow;
            copycentercol = centercol;

            copylcol = lcol;
            copylrow = lrow;

            copyrcol = rcol;
            copyrrow = rrow;

            copyocol = ocol;
            copyorow = orow;
        }

        public void resetorgs() {

                centerrow = copycenterrow;
                centercol = copycentercol;

                lcol = copylcol;
                lrow = copylrow;

                rcol = copyrcol;
                rrow = copyrrow;

                ocol = copyocol;
                orow = copyorow;
            
        }

        public void setcentercol(int num)
        {

            centercol = num;

        }

        public int getcentercol()
        {

            return centercol;

        }







        public void setlcol(int num)
        {

            lcol = num;

        }

        public int getlcol()
        {

            return lcol;

        }








        public void setlrow(int num)
        {

            lrow = num;

        }

        public int getlrow()
        {

            return lrow;

        }









        public void setrcol(int num)
        {

            rcol = num;

        }

        public int getrcol()
        {

            return rcol;

        }




        public void setrrow(int num)
        {

            rrow = num;

        }

        public int getrrow()
        {

            return rrow;

        }







        public void setocol(int num)
        {

            ocol = num;

        }

        public int getocol()
        {

            return ocol;

        }




        public void setorow(int num)
        {

            orow = num;

        }

        public int getorow()
        {

            return orow;
            
        }

        public void playermove(Boardwork board) {

            ConsoleKeyInfo Info = Console.ReadKey();
            if (Info.Key == ConsoleKey.LeftArrow && (centercol != 0 && lcol != 0 && rcol != 0 && ocol != 0) && board.boardmatrix[getlrow()][getlcol() - 1] != 1 && board.boardmatrix[getrrow() ][getrcol() - 1] != 1 && board.boardmatrix[getorow()][getocol() - 1] != 1 && board.boardmatrix[getcenterrow()][getcentercol()-1] != 1)
            {
                lcol = lcol - 1;
                rcol = rcol - 1;
                ocol = ocol - 1;
                centercol = centercol - 1;
                Console.Clear();
                board.printboard();
                System.Threading.Thread.Sleep(50);
            }
            else if (Info.Key == ConsoleKey.RightArrow && (centercol != 9 && lcol != 9 && rcol != 9 && ocol != 9) && board.boardmatrix[getlrow()][getlcol() + 1] != 1 && board.boardmatrix[getrrow()][getrcol() + 1] != 1 && board.boardmatrix[getorow()][getocol() + 1] != 1 && board.boardmatrix[getcenterrow()][getcentercol() + 1] != 1)
            {
                lcol = lcol + 1;
                rcol = rcol + 1;
                ocol = ocol + 1;
                centercol = centercol + 1;
                Console.Clear();
                board.printboard();
                System.Threading.Thread.Sleep(50);
            }
            else {
                ;
            }


        }


        public int[,] multiplyer(int[,] vector, int[,] matrix) {//takes in a vecor and a matrix, multiplies them and returns a vecotr

            int[,] newvector = new int[2, 1];

            newvector[0, 0] = vector[1, 0] * matrix[0, 1];
            newvector[1, 0] = vector[0, 0] * matrix[1, 0];



            return newvector;
        }


        protected int [,] suber(int[,] first, int[,] scenter) {//takes in a vector called first and the center vector which upon subtraction returns the result

            int[,] third = new int[2, 1];//creates a third vector, to hold the subtraction

            third[0, 0] = first[0, 0] - scenter[0, 0];// subtracts the first vector's 0 0 with the center's 0 0 

            third[1, 0] = first[1, 0] - scenter[1, 0];// subtracts the first vector's 1 0 with the center's 1 0 

            //assings both results to the third vector

            return third;//returns the third vector

        }

        public void rotate() {

            if (valid)
            {
                setcopys();

                int[,] centervector = { { centerrow }, { centercol } };//creates a center vector to hold center coordinates

                int[,] lvector = { { lrow }, { lcol } };//generates left vector to hold left coordinates

                int[,] rvector = { { rrow }, { rcol } };//generates right vector to hold right coordinates

                int[,] ovector = { { orow }, { ocol } };//generates other vector to hold other coordinates


                int[,] subvec = suber(lvector, centervector);//subtracts the center from the left and assigns it to subvec
                int[,] holdvector = multiplyer(subvec, rotationmatrix);//multiplies subvec and the rotational matrix and assigns that vector to holdvec

                lrow = centervector[0, 0] + holdvector[0, 0];//sets the row of the left to the addition of holdvector and centervector's 0 0 
                lcol = centervector[1, 0] + holdvector[1, 0];//sets the row of the left to the addition of holdvector and centervector's 1 0 

                subvec = suber(rvector, centervector);//subtracts the center from the right and assigns it to subvec
                holdvector = multiplyer(subvec, rotationmatrix);//multiplies subvec and the rotational matrix and assigns that vector to holdvec

                rrow = centervector[0, 0] + holdvector[0, 0];//sets the row of the right to the addition of holdvector and centervector's 0 0 
                rcol = centervector[1, 0] + holdvector[1, 0];//sets the row of the right to the addition of holdvector and centervector's 1 0 

                subvec = suber(ovector, centervector);//subtracts the center from the other and assigns it to subvec
                holdvector = multiplyer(subvec, rotationmatrix);//multiplies subvec and the rotational matrix and assigns that vector to holdvec

                orow = centervector[0, 0] + holdvector[0, 0];//sets the row of the other to the addition of holdvector and centervector's 0 0 
                ocol = centervector[1, 0] + holdvector[1, 0];//sets the row of the other to the addition of holdvector and centervector's 1 0 
            }
        }

    }
}
