﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_algorhitms_practice
{
    class Sort
    {
        public Sort() { }

        private static void Swap(int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
            swapsDone++;
        }

        public static int swapsDone;
        public static void Bubble(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                bool flag = false;
                for (int j = 0; j < array.Length-1-i; j++)
                {
                    if (array[j]>array[j+1])
                    {
                        flag = true;
                        Swap(array , j, j + 1);
                    }
                }
                if (!flag) break;
            }
        }

        public static void Cocktail(int[] array)
        {
            int leftMargin = 0;
            int rightMargin = array.Length - 1;
            bool flag= true; //flag to check if no swaps occured during iteration, if so - array is sorted, no further iterations required
            while (flag) 
            {
                flag = false;
                //go through from first to last
                for (int i = leftMargin; i < rightMargin; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        flag = true;
                    }
                }
                //then go through right to left
                for (int i = rightMargin; i > leftMargin; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        Swap(array, i, i - 1);
                        flag = true;
                    }
                }
                //after an iteration leftmost value is the minimal value
                //and rightmost - the maximal, thus exclude them from further iterations
                rightMargin--;
                leftMargin++;
            }
        }

        public static void Gnomesort(int[] array)
        {
            int i = 0;
            do
            {
                if (array[i]>array[i+1])
                {
                    Swap(array, i, i + 1);
                    i--;
                }
                else { i++; }
                if (i<0) { i = 0; }
            }
            while (i < array.Length-1);
        }

        public static void Quick(int[] array, int lowBoundary, int highBoundary)
        {
            int lowPointer = lowBoundary;
            int highPointer = highBoundary;
            int pivotPoint = ((lowBoundary + highBoundary) / 2);
            while (lowPointer<highPointer)
            {
                while(array[lowPointer]<array[pivotPoint]||lowPointer==pivotPoint)
                {
                    if (lowPointer == highPointer) { break; }
                    lowPointer++;
                }
                while(array[highPointer]>array[pivotPoint]||highPointer==pivotPoint)
                {
                    if (highPointer==lowPointer) { break; }
                    highPointer--;
                }
                if(highPointer==lowPointer) { break; }
                Swap(array, lowPointer, highPointer);
            }
            if (array[lowPointer] < array[pivotPoint] && lowPointer < pivotPoint) { lowPointer++; }
            else
            {
                if (array[lowPointer] > array[pivotPoint] && lowPointer > pivotPoint) { lowPointer--; }
            }
            Swap(array, lowPointer, pivotPoint);

            if (lowPointer!=lowBoundary)
            {
                Quick(array, lowBoundary, lowPointer - 1);
            }
            if (lowPointer!=highBoundary)
            {
                Quick(array, lowPointer + 1, highBoundary);
            }
        }

        public static void Comb(int[] array)
        {
            const double diminishFactor = 1.247;
            int step = (int)(array.Length / diminishFactor);
            bool sorted = false;
            while (!sorted)
            {
                if (step == 1) { sorted = true; }
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (i + step < array.Length)
                    {
                        if (array[i] > array[i + step])
                        {
                            Swap(array, i, i + step); sorted = false;
                        }
                    }
                }
                if (step != 1)
                {
                    step = (int)(step / diminishFactor);
                }
            }
        }

        public static void OddEven(int[] array)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = (i%2==1)?0:1; j < array.Length-1; j+=2)
                    {
                        if (array[j]>array[j+1])
                        {
                            Swap(array, j, j + 1);
                            sorted = false;
                        }
                    }
                }
            }
        }
        
        public static void Selection(int[] array)
        {
            int minIndex=0;
            for (int i = 0; i < array.Length-1; i++)
            {
                minIndex = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[minIndex]>array[j]) { minIndex = j; }
                }
                Swap(array, minIndex, i);
            }
        }

    }
}
