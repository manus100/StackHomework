using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackHomework
{
    class Program
    {
        static Queue<string> carQueue = new Queue<string>();
        static int carPassed =0;
        static void Main(string[] args)
        {
            string str;
            int nr;
           

            //Console.WriteLine("1. Reverse Strings");
            //str = ReadString();
            //Console.WriteLine("Reversed string: " + ReverseString(str));
            //Console.WriteLine();

            //Console.WriteLine("2. Simple calculator");
            //str = ReadString();
            //Console.WriteLine("Rezultatul este: " + SimpleCalculation(str));
            //Console.WriteLine();

            //Console.WriteLine("3. Decimal to binary");
            //Console.WriteLine("Introduceti numarul de convertit:");
            //nr = Convert.ToInt32(Console.ReadLine());
            //DecimalToBinary(nr);

            //Console.WriteLine("4. Matching Brackets");
            //str = "(2 + 3) - (2 + 3)";
            //MatchBrackets(str);
            ////Console.WriteLine($"Stringul initial: {str} " + "\n" + MatchBrackets(str));
            //Console.WriteLine();

            //str = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";
            //MatchBrackets(str);
            //// Console.WriteLine($"Stringul initial: {str} " + "\n" + MatchBrackets(str));
            //Console.WriteLine();

            //str = "Mimi Pepi Toshko";
            //nr = 2;
            //HotPotato(str, nr);
            //Console.WriteLine();

            //str = "Gosho Pesho Misho Stefan Krasi";
            //nr = 10;
            //HotPotato(str, nr);
            //Console.WriteLine();

            //str = "Gosho Pesho Misho Stefan Krasi";
            //nr = 1;
            //HotPotato(str, nr);
            //Console.WriteLine();


            Console.WriteLine("Nb of cars: ");
            nr = Convert.ToInt32(Console.ReadLine());

            str = "";

            while (true)
            {
                str = Console.ReadLine();
                TrafficLight(str, nr);
            }



            Console.ReadLine();

        }

        public static string ReadString()
        {
            Console.WriteLine("Introduceti stringul: ");
            return Console.ReadLine();
        }

        public static string ReverseString(string str)
        {
            string reversedString = "";
            Stack<string> myStack = new Stack<string>();

            for (int i = 0; i < str.Length; i++)
            {
                myStack.Push(str[i].ToString());
            }

            while (myStack.Count>0)
            {
                reversedString += myStack.Pop();
            }
            return reversedString;
        }

        public static int SimpleCalculation(string str)
        {
            Stack<string> myStack = new Stack<string>();
            string[] input = str.Split(' ');

            for (int i = input.Length-1; i >=0; i--)
            {
                myStack.Push(input[i]);
            }

            int result, numberToAdd;
            result = int.Parse(myStack.Pop());

 
            string oper = "";

            while (myStack.Count > 0)
            {
                oper = myStack.Pop();
                if (oper.Equals("+"))
                   
                {
                    numberToAdd = int.Parse(myStack.Pop());
                    result = AddNumbers(result, numberToAdd);
                }
                else
                {
                    numberToAdd = int.Parse(myStack.Pop());
                    result = SubstractNumbers(result, numberToAdd);
                }
            }

            return result;
        }

        public static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public static int SubstractNumbers(int a, int b)
        {
            return a - b;
        }

        public static void DecimalToBinary(int nb)
        {
            Stack<int> Digits = new Stack<int>();
            while (nb != 0)
            {
                Digits.Push((int)(nb % 2));
                nb /= 2;
            }

            while (Digits.Count > 0)
                Console.Write(Digits.Pop());
        }

        public static void MatchBrackets(string str)
        {
            Stack<int> stkChars = new Stack<int>();
            Queue<string> qBrackets = new Queue<string>();
            int idx;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Equals('('))
                {
                    stkChars.Push(i);
                }

                if (str[i].Equals(')'))
                {
                    idx = stkChars.Pop(); 
                    qBrackets.Enqueue(str.Substring(idx, i - idx + 1));
                }
            }

            while (qBrackets.Count > 0)
            {
                Console.WriteLine(qBrackets.Dequeue());
            }


            //StringBuilder sb = new StringBuilder();

            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (str[i].Equals('('))
            //    {
            //        stkChars.Push(i);
            //    }

            //    if (str[i].Equals(')'))
            //    {
            //        idx= stkChars.Pop();
            //        sb.Append(str.Substring(idx, i - idx + 1));
            //        sb.Append("\n");
            //    }

            //}

            //return sb.ToString();
        }

        public static void HotPotato(string str, int nb)
        {
            string[] arrPlayers = str.Split(' ');

            Queue<string> players = new Queue<string>(arrPlayers);
           

            while (players.Count > 1)
            {
                for (int i = 1; i < nb; i++)
                {
                    players.Enqueue(players.Dequeue());
                }
                Console.WriteLine($"Removed {players.Dequeue()}");
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }

     
        public static void TrafficLight(string str, int nb)
        {
            if (str.Equals("end"))
            {
                Console.WriteLine(carPassed + " cars passed the crossroads.");
                carPassed = 0;
            }
            if (str.Equals("green"))
            {
                RemoveCarFromQueue(nb);
            }
            else
            {
                AddCarToQueue(str);
            }

        }

        public static void AddCarToQueue(string car)
        {
            carQueue.Enqueue(car);
        }

        public static void RemoveCarFromQueue(int nb)
        {

            for (int i = 0; i < nb && i < carQueue.Count + i; i++)
            {
                Console.WriteLine($"{carQueue.Dequeue()} passed!");
                carPassed++;
            }

        }


       
    }

}
