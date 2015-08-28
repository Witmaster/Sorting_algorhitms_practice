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
        }

        public static void Bubble(int[] array, int length)
        {
            for (int i = 0; i < length-1; i++)
            {
                bool flag = false;
                for (int j = 0; j < length-1-i; j++)
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
            bool flag= false; //flag to check if no swaps occured during iteration, if so - array is sorted, no further iterations required
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
            };
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
            while (i < array.Length);
        }

        public static void Quick(int[] array, int lowBoundary, int highBoundary)
        {
            int pivot = array[(lowBoundary+highBoundary)/2];
            int pivotPoint = (lowBoundary+highBoundary)/2;
            int lowIndex = lowBoundary;
            int highIndex = highBoundary-1;
            while (highIndex>lowIndex)
            {
                while (pivot>array[lowIndex])
                {
                    lowIndex++;
                    if (lowIndex == highIndex) break;
                }
                while (pivot<array[highIndex])
                {
                    highIndex--;
                    if (highIndex == lowIndex) break;
                }
                if (highIndex == lowIndex) break;
                if (pivotPoint == lowIndex) { pivotPoint = highIndex; }
                if (pivotPoint==highIndex) { pivotPoint = lowIndex; }
                Swap(array, lowIndex, highIndex);
            }
            Swap(array, pivotPoint, highIndex);
            if (lowBoundary < pivotPoint - 1) { Quick(array, lowBoundary, pivotPoint); }
            if (highBoundary > pivotPoint + 1) { Quick(array, pivotPoint + 1, highBoundary); }
        }


    }
}