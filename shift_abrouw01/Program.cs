//Programmer:       Alex Brouwer
//Program:          Shift Algorithm
//Date:             Sept 30, 2016
//Desc:             removeShift() takes an index, removes the item, then shifts all the elements down so there are no empty spaces in the array

using System;
using System.Text;


namespace shift
{
    //Basic derived exception class that handles user input that is not in the range of the array
    public class NotInArrayRangeException : Exception
    {
        public NotInArrayRangeException() { }
        public NotInArrayRangeException(string message) : base(message) { }

    }
    class myList
    {

        static void Main(string[] args)
        {
            int number, remove = 0;
            string input;
            bool check = false;
            int[] listOfNumbers;
            Random rand = new Random();

            Console.WriteLine("Program is generating a random number to determine array size and creating array...");

            //generate random number for list size between 100-1000
            number = rand.Next(100, 1000);

            //create array and fill it with random numbers
            listOfNumbers = new int[number];

            //fill the array with values
            for (int i = 0; i < number; i++)
            {
                listOfNumbers[i] = i + 7;
            }

            //get input and catch errors
            do
            {
                try
                {
                    //this block will loop until the user enters a number that is within the range of the array
                    Console.WriteLine("Select an index between 0 and " + (number - 1) + " to remove.");
                    input = Console.ReadLine();

                    remove = Int32.Parse(input);

                    if (remove > number || remove < 0)
                    {
                        throw new NotInArrayRangeException();
                    }
                    check = true;               //flag is set when input passes both tests
                }
                catch (NotInArrayRangeException)
                {
                    Console.WriteLine("Error: Input not in array range.");
                    remove = 0;

                }
                catch (FormatException)
                {
                    Console.WriteLine("ERROR: Invalid format");
                    remove = 0;
                }
            } while (!check);

            //remove the value
            removeShift(remove, ref listOfNumbers);

            Console.WriteLine("Removal complete. Now printing list");

            //print the array
            for (int i = 0; i < listOfNumbers.Length; i++)
            {
                Console.WriteLine(listOfNumbers[i]);
            }

            Console.Read();
        }

        //PRECONDITION:     removeShift takes an integer as the index to remove in an array of integers.
        //                  It also takes an array by reference that it will manuipulate
        //POSTCONDITION:    When the function goes out of scope, the item will have been deleted and all the elements will shift down to take its place
        //PURPOSE:          To remove an item in the array and shift the elements after it over one position
        public static void removeShift(int index, ref int[] ary)
        {
            int size = ary.Length;
            ary[index] = -1;            //flag used to denote a deleted item
            int temp;

            for (int i = index; i < size; i++)
            {
                //if the shift is complete. The second evaluation allows for a more realistic implementation if we were going to delete from this list 
                //more than once
                if ((i + 1) == size || (i + 1) == -1)
                {
                    return;
                }

                temp = ary[i + 1];      //copy value of next postition into temp
                ary[i + 1] = ary[i];    //shift the removed value down one position
                ary[i] = temp;          //place value that was in next index into the current index
            }
        }


    }
}

