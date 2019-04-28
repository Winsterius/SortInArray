using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortInArray
{
    class Program
    {
        static int count = 0;
        static int temp = 0;
        static bool finish = false;

        static void Main(string[] args)
        {
            int[] theArray;
            int length;
            int needle;
            Console.WriteLine("Gib die Länge des Arrays ein");
            while (!int.TryParse(Console.ReadLine(), out length)) Console.WriteLine("Falsche Eingabe");

            theArray = GetRandomArray(length);
            Array.Sort(theArray);
            //Console.WriteLine("ready");
            //BubbleSort(theArray);
            PrintArray(theArray);
            //Console.WriteLine("ready");
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out needle)) Console.WriteLine("Falsche Eingabe");
                Console.WriteLine("Die Zahl {0,-2} ist auf {1,2} Position", needle, BinarySearch(theArray, needle));
            }                       
        }

        static int[] GetRandomArray(int NumOfElements)
        {
            Random random = new Random();
            int[] arr = new int[NumOfElements];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(10001);
            }
        
            return arr;
        }
        static void PrintArray(int[] arr)
        {
            foreach (int i in arr) Console.Write("{0,10}  ", i);
        }
        static void BubbleSort(int[] arr)
        {
            //int i = 0;
            do
            {
                
                //if (arr[i] == arr[i + 1] && i < arr.Length - 1) i++;
                count = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        count++;
                    }
                }
                if (count == 0) finish = true;
            } while (!finish);
        }
        static int BinarySearch(int[] arr, int needle)
        {
            if (arr[arr.Length - 1] == needle) return arr.Length - 1;
            if (arr[0] == needle) return 0;
            int position = arr.Length / 2;
            int halfPosition = position / 2;
            bool toMuch = false;
            while (true)
            {
                
                if (toMuch) position--;
                toMuch = false;
                if (arr[position] != needle)
                {
                    if (needle < arr[position]) position = Math.Abs(position - halfPosition);
                    if (needle > arr[position]) position = Math.Abs(position + halfPosition);                    
                }
                if (arr[position] == needle) return position;
                
                halfPosition = halfPosition / 2;
                if (halfPosition % 2 != 0 && halfPosition != 1) { halfPosition++; toMuch = true; }
                if (halfPosition == 0) return -1;                                                                                                       
            }
        }
    }
}
