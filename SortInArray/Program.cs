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
            BubbleSort(theArray);
            PrintArray(theArray);
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out needle)) Console.WriteLine("Falsche Eingabe");
                ShowPosition(needle, BinarySearch(theArray, needle));
            }                                   
        }

        static int[] GetRandomArray(int NumOfElements)
        {
            Random random = new Random();
            int[] arr = new int[NumOfElements];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-100, 101);
            }
        
            return arr;
        }
        static void PrintArray(int[] arr)
        {
            foreach (int i in arr) Console.Write("{0,10}  ", i);
        }
        static void BubbleSort(int[] arr)
        {
            do
            {
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
            bool finish = false;

            while(!finish)
            {
                if (arr[arr.Length - 1] == needle) return arr.Length - 1;
                int i = arr.Length / 2;
                
                while (needle < i - i / 2)
                {
                    if (arr[i] == needle) return i;
                    finish = true;
                    i /= 2;
                }
                while (needle > i + i / 2)
                {
                    if (arr[i] == needle) return i;
                    finish = true;
                    i /= 2;
                }
            }
            return -1;
        }           
        static void ShowPosition(int needle, int i)
        {
            if (i == -1) Console.WriteLine("Deine Zahl ist nicht auf dem Array");
            else
            {
               

                Console.WriteLine("Die Zahl {0,-2} ist auf {1,2} Position", needle, i);
            }
        }
    }
}
