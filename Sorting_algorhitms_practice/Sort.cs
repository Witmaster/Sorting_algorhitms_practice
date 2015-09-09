using System;
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

        public static void HeapSort(int[] array)
        {
            int end = array.Length-1;
            while (end > 0)
            {
                HeapBuild(array, end);
                Swap(array, 0, end);
                end--;
                Swap(array, 0, end);
            }
        }
        private static void HeapBuild(int[] array, int end)
        {
            bool sorted = false;
            while(!sorted)
            {
                sorted = true;
                for (int i = 0; ((2*i)+1) <= end; i++)
                {
                    if (array[i]<array[((2 * i) + 1)])
                    {
                        sorted = false;
                        Swap(array, i, ((2 * i) + 1));
                    }
                    if (array[i]<array[((2 * i) + 2)]&&((2* i)+2<= end))
                    {
                        sorted = false;
                        Swap(array, i, ((2 * i) + 2));
                    }
                }
            }
        }

        public static void Insertion(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i]>array[i+1])
                {
                    int temp = array[i + 1];
                    for (int j = i; j >=0 ; j--)
                    {
                        
                        if (array[j]>temp)
                        {
                            array[j + 1] = array[j]; if (j == 0) { array[j] = temp; break; }
                        }
                        else
                        {
                            array[j + 1] = temp;
                            break;
                        }
                    }
                }
            }
        }

        public static void Shellsort(int[] array)
        {
            const double diminishFactor = 1.247;
            int step = (int)(array.Length / diminishFactor);
            bool sorted = false;
            while (!sorted)
            {
                if (step==1) { sorted = true; }
                for (int i = 0; i < array.Length - step - 1; i++)
                {
                    if (array[i] > array[i + step])
                    {
                        sorted = false;
                        int temp = array[i + step];
                        for (int j = i+step-1; j >=i; j--)
                        {
                            if (temp < array[j])
                            {
                                array[j + 1] = array[j]; if (j == i) { array[j] = temp; break; }
                            }
                            else
                            {
                                array[j + 1] = temp; break;
                            }
                        }
                    }
                }
                if (step > 1)
                {
                    step = (int)((double)step / diminishFactor);
                }
                else
                {
                    Selection(array);
                }
            }
        }

        private int L(uint x)
        {
            if (x<2) { return 1; }
            else { int result = L(x - 1) + L(x - 2) + 1; return result; }
        }

        public static void Smoothsort(int[] array)
        {

        }
    }
}
