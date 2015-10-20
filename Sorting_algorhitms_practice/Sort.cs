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

        private static int L(int x) //calculate Leonardo number L(x)
        {
            x = Math.Abs(x);
            if (x<2) { return 1; }
            else { int result = L(x - 1) + L(x - 2) + 1; return result; }
        }
        private static void SmoothHeapBuild(int[] array, int root, int size)
        {
            if (size < 2)
                return;
            int leoOne = root - L(size - 2) - 1;
            int leoTwo = root - 1;
            SmoothHeapBuild(array, leoOne, size - 1);
            SmoothHeapBuild(array, leoTwo, size - 2);
            if (array[root] < array[leoOne])
            {
                Swap(array, root, leoOne);
                SmoothHeapBuild(array, leoOne, size - 1);
            }
            if (array[root] < array[leoTwo])
            {
                Swap(array, root, leoTwo);
                SmoothHeapBuild(array, leoTwo, size - 2);
            }
        }
         private static void SmoothHeapDestroy(int[] array, List<int> forest)
        {
            for (int currentRoot = array.Length - 1; currentRoot>0; currentRoot--)
            {
                if (forest.Last()>1)//break current tree into subtrees
                {
                    int last = forest.Last();
                    forest.RemoveAt(forest.Count - 1);
                    forest.Add(--last);
                    forest.Add(--last);
                }
                else
                {
                    forest.RemoveAt(forest.Count()-1);
                }
                int rootIndex = -1; //variable to track root of each consequent tree in the forest
                foreach (int tree in forest) //swap the biggest root with the forest's root, then rebuild modified tree
                {
                    rootIndex += L(tree);
                    if (array[rootIndex] > array[currentRoot])
                    {
                        Swap(array, rootIndex, currentRoot);
                        SmoothHeapBuild(array, rootIndex, tree);
                    }
                }
            }
        }

        public static void Smoothsort(int[] array)
        {
            List<int> forest = new List<int>();
            int sequence = 0;
            for (int index = 0; index < array.Length; index++)
            {
                if (forest.Count < 2)
                {
                    forest.Add(sequence++);
                    continue;
                }
                int x = Math.Max(forest[forest.Count() - 2], forest.Last());
                if (L(forest[forest.Count - 2]) + L(forest.Last()) + 1 == L(x + 1))
                {
                    forest.RemoveAt(forest.Count() - 1);
                    forest.RemoveAt(forest.Count() - 1);
                    forest.Add(x + 1);
                    SmoothHeapBuild(array, index, forest.Last());
                    sequence = 0;
                }
                else
                {
                    forest.Add(sequence++);
                }
            }
            SmoothHeapDestroy(array, forest);
        }

        public static void MergeSortRun(int[] array)
        {
            mergesort(array, 0, array.Length - 1);
        }
        private static void mergesort(int[] array, int firstIndex, int lastIndex)
        {
            if (lastIndex - firstIndex < 1) return;
            mergesort(array, firstIndex, (firstIndex + lastIndex) / 2);
            mergesort(array, ((firstIndex+lastIndex)/ 2 ) + 1, lastIndex);
            merge(array, firstIndex, lastIndex);
        }

        private static void merge(int[] array, int firstIndex, int lastIndex)
        {
            int mid = (firstIndex + lastIndex) / 2;
            int left = firstIndex;
            int right = mid + 1;
            int[] aux = new int[lastIndex - firstIndex + 1];
            int index = 0;
            while (left <= mid && right <= lastIndex)
            {
                if (array[right] < array[left])
                {
                    aux[index++] = array[right++];
                }
                else
                {
                    aux[index++] = array[left++];
                }
            }
            while (left <= mid)
            {
                aux[index++] = array[left++];
            }
            while (right <= lastIndex)
            {
                aux[index++] = array[right++];
            }
            for (index = 0; firstIndex <= lastIndex; index++)
            {
                array[firstIndex++] = aux[index];
            }
        }
    }
}
