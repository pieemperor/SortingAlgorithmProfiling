///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  DataStructuresProject3/DataStructuresProject3
//	File Name:         SortingDriver.cs
//	Description:       Demonstrates the efficiency of 9 different sorting algorithms
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Dakota Cowell, cowelld@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Tuesday, October 23, 2018
//	Copyright:         Dakota Cowell, 2018
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2210_002_CowellDakota_DataStructuresProject3
{
    /// <summary>
    /// Class to show functionality of different sort methods
    /// This class will sort data using different sort functions
    /// The main purpose of this class is to be able to analyze the speed of different sorts on different kinds of data
    /// </summary>
    class SortingDriver
    {
        /// <summary>
        /// Performs operations to generate data to put into lists
        /// Then, this method calls other methods to sort the data
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //Initialize the arrays for each sort type and create constant for array length
            const int ArrayLength = 100;
            List<int> sinkList = new List<int>();
            List<int> selectionList = new List<int>();
            List<int> insertList = new List<int>();
            List<int> mergeList = new List<int>();
            List<int> quickList = new List<int>();
            List<int> medianQuickList = new List<int>();
            List<int> shellList = new List<int>();
            List<int> countingList = new List<int>();
            List<int> radixList = new List<int>();

            Random rand = new Random();

            GenerateAlmostSortedData(ArrayLength, sinkList, selectionList, insertList, mergeList, quickList, medianQuickList, shellList, countingList, radixList, rand);

            //Sinking Sort
            SinkingSort(sinkList);

            //Selection Sort
            SelectionSort(selectionList, ArrayLength);

            //Insertion Sort
            InsertionSort(insertList);

            //Merge Sort
            mergeList = MergeSort(mergeList);

            //Quick Sort
            QuickSort(quickList, 0, quickList.Count - 1);

            //Median-Of-Three Quick Sort
            MedianQuickSort(medianQuickList, 0, medianQuickList.Count - 1);

            //Shell Sort
            ShellSort(shellList);

            //Counting Sort
            countingList = CountingSort(countingList);

            //Radix Sort
            radixList = RadixSort(radixList);
        }

        /// <summary>
        /// Generates random data and adds it to lists to be sorted later
        /// </summary>
        /// <param name="numberOfIntegers">Number of integers to be generated </param>
        /// <param name="sinkList">Empty list to be used for the sinking sort</param>
        /// <param name="selectionList">Empty list to be used for the selection sort</param>
        /// <param name="insertList">Empty list to be used for the insertion sort</param>
        /// <param name="mergeList">Empty list to be used for the merge sort</param>
        /// <param name="quickList">Empty list to be used for the quick sort</param>
        /// <param name="medianQuickList">Empty list to be used for the median-of-three quick sort</param>
        /// <param name="shellList">Empty list to be used for the shell sort</param>
        /// <param name="countingList">Empty list to be used for the counting sort</param>
        /// <param name="radixList">Empty list to be used for the radix sort</param>
        /// <param name="rand">Random object to be used for generating random integers</param>
        private static void GenerateRandomData(int numberOfIntegers, List<int> sinkList, List<int> selectionList, List<int> insertList, List<int> mergeList, List<int> quickList, List<int> medianQuickList, List<int> shellList, List<int> countingList, List<int> radixList, Random rand)
        {
            //Popuate the arrays with random data from 0 - 99
            for (int i = 0; i < numberOfIntegers; i++)
            {
                int tempRandomInt = rand.Next(100);
                sinkList.Add(tempRandomInt);
                selectionList.Add(tempRandomInt);
                insertList.Add(tempRandomInt);
                mergeList.Add(tempRandomInt);
                quickList.Add(tempRandomInt);
                medianQuickList.Add(tempRandomInt);
                shellList.Add(tempRandomInt);
                countingList.Add(tempRandomInt);
                radixList.Add(tempRandomInt);
            }
        }


        /// <summary>
        /// Generates Sorted data and adds that to the lists passed in to be sorted later
        /// </summary>
        /// <param name="numberOfIntegers">Number of integers to be generated </param>
        /// <param name="sinkList">Empty list to be used for the sinking sort</param>
        /// <param name="selectionList">Empty list to be used for the selection sort</param>
        /// <param name="insertList">Empty list to be used for the insertion sort</param>
        /// <param name="mergeList">Empty list to be used for the merge sort</param>
        /// <param name="quickList">Empty list to be used for the quick sort</param>
        /// <param name="medianQuickList">Empty list to be used for the median-of-three quick sort</param>
        /// <param name="shellList">Empty list to be used for the shell sort</param>
        /// <param name="countingList">Empty list to be used for the counting sort</param>
        /// <param name="radixList">Empty list to be used for the radix sort</param>
        /// <param name="rand">Random object to be used for generating random integers</param>
        private static void GenerateSortedData(int numberOfIntegers, List<int> sinkList, List<int> selectionList, List<int> insertList, List<int> mergeList, List<int> quickList, List<int> medianQuickList, List<int> shellList, List<int> countingList, List<int> radixList, Random rand)
        {
            //Create a temporary list to store randomly generated data
            List<int> tempList = new List<int>(numberOfIntegers);

            //Generate random integers from 0 - 99
            for (int i = 0; i < numberOfIntegers; i++)
            {
                tempList.Add(rand.Next(100));
            }

            //Sort the data in the temporary list
            tempList.Sort();

            //Give all the lists the same data
            sinkList.AddRange(tempList);
            selectionList.AddRange(tempList);
            insertList.AddRange(tempList);
            mergeList.AddRange(tempList);
            quickList.AddRange(tempList);
            medianQuickList.AddRange(tempList);
            shellList.AddRange(tempList);
            countingList.AddRange(tempList);
            radixList.AddRange(tempList);
        }

        /// <summary>
        /// Generates random data and puts it in reverse order
        /// Then, it puts that data in all of the lists
        /// </summary>
        /// <param name="numberOfIntegers">Number of integers to be generated </param>
        /// <param name="sinkList">Empty list to be used for the sinking sort</param>
        /// <param name="selectionList">Empty list to be used for the selection sort</param>
        /// <param name="insertList">Empty list to be used for the insertion sort</param>
        /// <param name="mergeList">Empty list to be used for the merge sort</param>
        /// <param name="quickList">Empty list to be used for the quick sort</param>
        /// <param name="medianQuickList">Empty list to be used for the median-of-three quick sort</param>
        /// <param name="shellList">Empty list to be used for the shell sort</param>
        /// <param name="countingList">Empty list to be used for the counting sort</param>
        /// <param name="radixList">Empty list to be used for the radix sort</param>
        /// <param name="rand">Random object to be used for generating random integers</param>
        private static void GenerateReverseSortedData(int numberOfIntegers, List<int> sinkList, List<int> selectionList, List<int> insertList, List<int> mergeList, List<int> quickList, List<int> medianQuickList, List<int> shellList, List<int> countingList, List<int> radixList, Random rand)
        {
            //Temporary list to hold random data
            List<int> tempList = new List<int>();

            //Generate random data from 0 - 99
            for (int i = 0; i < numberOfIntegers; i++)
            {
                tempList.Add(rand.Next(100));
            }

            //Put the list in reverse sorted order
            tempList.Sort();
            tempList.Reverse();

            //Add data to all the lists
            sinkList.AddRange(tempList);
            selectionList.AddRange(tempList);
            insertList.AddRange(tempList);
            mergeList.AddRange(tempList);
            quickList.AddRange(tempList);
            medianQuickList.AddRange(tempList);
            shellList.AddRange(tempList);
            countingList.AddRange(tempList);
            radixList.AddRange(tempList);
        }

        /// <summary>
        /// Generate random data and puts it in almost sorted order
        /// Then, adds that data to all of the lists
        /// </summary>
        /// <param name="numberOfIntegers">Number of integers to be generated </param>
        /// <param name="sinkList">Empty list to be used for the sinking sort</param>
        /// <param name="selectionList">Empty list to be used for the selection sort</param>
        /// <param name="insertList">Empty list to be used for the insertion sort</param>
        /// <param name="mergeList">Empty list to be used for the merge sort</param>
        /// <param name="quickList">Empty list to be used for the quick sort</param>
        /// <param name="medianQuickList">Empty list to be used for the median-of-three quick sort</param>
        /// <param name="shellList">Empty list to be used for the shell sort</param>
        /// <param name="countingList">Empty list to be used for the counting sort</param>
        /// <param name="radixList">Empty list to be used for the radix sort</param>
        /// <param name="rand">Random object to be used for generating random integers</param>
        private static void GenerateAlmostSortedData(int numberOfIntegers, List<int> sinkList, List<int> selectionList, List<int> insertList, List<int> mergeList, List<int> quickList, List<int> medianQuickList, List<int> shellList, List<int> countingList, List<int> radixList, Random rand)
        {
            //Temporary list to store random data
            List<int> tempList = new List<int>();

            //Generate random data from 0 - 99
            for (int i = 0; i < numberOfIntegers; i++)
            {
                tempList.Add(rand.Next(100));
            }

            //Sort the list
            tempList.Sort();

            //Swap the positions of 5% of the integers in the list
            //By switching 5% of the numbers, this will give a list that has about 10% of data unsorted
            for(int i = 0; i < numberOfIntegers * 0.05; i ++)
            {
                Swap(tempList, rand.Next(numberOfIntegers), rand.Next(numberOfIntegers));
            }

            //Add data to lists
            sinkList.AddRange(tempList);
            selectionList.AddRange(tempList);
            insertList.AddRange(tempList);
            mergeList.AddRange(tempList);
            quickList.AddRange(tempList);
            medianQuickList.AddRange(tempList);
            shellList.AddRange(tempList);
            countingList.AddRange(tempList);
            radixList.AddRange(tempList);
        }

        /// <summary>
        /// Method used to print a list to the console
        /// Used for testing purposes
        /// </summary>
        /// <param name="list">List to be printed</param>
        private static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Sinking sort algorithm - Sorts data in ascending order
        /// </summary>
        /// <param name="list">List to be sorted</param>
        private static void SinkingSort(List<int> list)
        {
            bool sorted = false;
            int pass = 0;

            while(!sorted && pass < list.Count)
            {
                pass++;
                sorted = true;

                for (int i = 0; i < list.Count - pass; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        Swap(list, i, i + 1);
                        sorted = false;
                    }
                }
            }
        }

        /// <summary>
        /// insertion sort algorithm - Sorts data in ascending order
        /// </summary>
        /// <param name="list">List to be sorted</param>
        private static void InsertionSort(List<int> list)
        {
            int temp, j;
            for (int i = 1; i < list.Count; i++)
            {
                temp = list[i];

                for(j = i;j > 0 && temp < list[j - 1]; j--)
                {
                    list[j] = list[j - 1];
                }
                list[j] = temp;
            }
        }

        /// <summary>
        /// Switches the places of 2 items in a list
        /// Helper method to other sort functions
        /// </summary>
        /// <param name="list">list where items need to be switched</param>
        /// <param name="n">First position to swap</param>
        /// <param name="m">Second position to swap</param>
        private static void Swap(List<int> list, int n, int m)
        {
            int temp = list[n];
            list[n] = list[m];
            list[m] = temp;
        }

        /// <summary>
        /// Selection sort algorithm - Sorts data in ascending order
        /// </summary>
        /// <param name="list">List to be sorted</param>
        private static void SelectionSort(List<int> list, int n)
        {
            if(n <= 1)
            {
                return;
            }

            int max = Max(list, n);
            if(list[max] != list [n - 1])
            {
                Swap(list, max, n - 1);
            }
            SelectionSort(list, n - 1);

        }

        /// <summary>
        /// Finds the max number in a list and returns its index
        /// </summary>
        /// <param name="list">List to find the max of</param>
        /// <param name="n">Number of items to loop through</param>
        /// <returns>index of the max number in the list</returns>
        private static int Max(List<int> list, int n)
        {
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                if(list[max] < list[i])
                {
                    max = i;
                }
            }
            return max;
        }

        /// <summary>
        /// Merge Sort Algorithm - Splits the List into many lists and sort those and then combines them
        /// </summary>
        /// <param name="list">List to be sorted</param>
        /// <returns>Returns a sorted list of integers</returns>
        private static List<int> MergeSort(List<int> list)
        {
            if(list.Count <= 1)
            {
                return list;
            }

            //Initialize new lists to keep track of the separate sides of the lists
            List<int> result = new List<int>();
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            //Find middle of list and then add everything to the left to the left list and right to the right list
            int middle = list.Count / 2;
            for(int i = 0;i < middle; i++)
            {
                left.Add(list[i]);
            }
            for(int i = middle; i < list.Count; i++)
            {
                right.Add(list[i]);
            }

            //Recursively call the function splitting the data into many lists
            left = MergeSort(left);
            right = MergeSort(right);

            //Add a list to the other list
            if(left[left.Count - 1] <= right[0])
            {
                return Append(left, right);
            }

            //Merge the lists
            result = Merge(left, right);
            return result;
        }

        /// <summary>
        /// Appends a list to another list
        /// Helper function for merge sorting
        /// </summary>
        /// <param name="left">Left lsit to be added to</param>
        /// <param name="right">List to add to other list</param>
        /// <returns>List that contains the data from both of the Lists passed in</returns>
        private static List<int> Append(List<int> left, List<int> right)
        {
            List<int> result = new List<int>(left);
            foreach(int x in right)
            {
                result.Add(x);
            }
            return result;
        }

        /// <summary>
        /// Merges 2 lists together - Puts the data in the correct order
        /// Helper function for the MergeSort
        /// </summary>
        /// <param name="left">List of integers that has been split on the left side</param>
        /// <param name="right">List of integers that has been split on the right side</param>
        /// <returns>Returns a sorted List that contains the data from the lists passed in</returns>
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 && right.Count > 0)
            {
                if(left[0] < right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            while(left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }

            while(right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
            return result;
        }

        /// <summary>
        /// Quick Sort Algorithm - Sorts the data in ascending order
        /// </summary>
        /// <param name="list">List to be sorted</param>
        /// <param name="start">Position to start sorting</param>
        /// <param name="end">Position to stop sorting</param>
        private static void QuickSort(List<int> list, int start, int end)
        {
            int left = start;
            int right = end;

            if(left >= right)
            {
                return;
            }

            while(left < right)
            {
                while(list[left] <= list[right] && left < right)
                {
                    right--;
                }
                if(left < right)
                {
                    Swap(list, left, right);
                }

                while(list[left] <= list[right] && left < right)
                {
                    left++;
                }
                if(left < right)
                {
                    Swap(list, left, right);
                }
            }
            QuickSort(list, start, left - 1); //Recursively calls itsself
            QuickSort(list, right + 1, end);
        }

        /// <summary>
        /// Median-Of-Three QuickSort method - Sorts data in ascending order
        /// </summary>
        /// <param name="list">List to be sorted</param>
        /// <param name="start">Where to start sorting</param>
        /// <param name="end">Where to finish sorting</param>
        private static void MedianQuickSort(List<int> list, int start, int end)
        {
            const int cutoff = 10;

            if(start + cutoff > end)
                InsertSort(list, start, end);

            else
            {
                int middle = (start + end) / 2;

                if(list[middle] < list[start])
                    Swap(list, start, middle);
                if(list[end] < list[start])
                    Swap(list, start, end);
                if(list[end] < list[middle])
                    Swap(list, middle, end);

                int pivot = list[middle];
                Swap(list, middle, end - 1);

                int left, right;
                for(left = start, right = end - 1; ;)
                {
                    while (list[++left] < pivot)
                        ;
                    while (pivot < list[--right])
                        ;
                    if(left < right)
                        Swap(list, left, right);
                    else
                        break;
                }

                Swap(list, left, end - 1);

                MedianQuickSort(list, start, left - 1);
                MedianQuickSort(list, left + 1, end);
            }
        }

        /// <summary>
        /// Insertion Sort algorithm that is used in the Median-Of-Three QuickSort method
        /// Uses a start and end instead of default values
        /// </summary>
        /// <param name="list">List to be sorted</param>
        /// <param name="start">Where to start sorting</param>
        /// <param name="end">Where to stop sorting</param>
        private static void InsertSort(List<int> list, int start, int end)
        {
            int temp, j;
            for(int i = start + 1; i <= end; i++)
            {
                temp = list[i];

                for (j = i; j > start && temp < list[j - 1]; j--)
                {
                    list[j] = list[j - 1];
                }
                list[j] = temp;
            }
        }

        /// <summary>
        /// Shell sort algorithm - Sorts data in ascending order
        /// Uses a gap divided by 2.2
        /// </summary>
        /// <param name="list">List to be sorted</param>
        private static void ShellSort(List<int> list)
        {
            for(int gap = list.Count / 2; gap > 0; gap = (gap == 2 ? 1 : (int)(gap/2.2)))
            {
                int temp, j;
                for(int i = gap; i < list.Count; i++)
                {
                    temp = list[i];
                    for(j = i; j >= gap && temp < list[j - gap]; j -= gap)
                    {
                        list[j] = list[j - gap];
                    }
                    list[j] = temp;
                }
            }
        }

        /// <summary>
        /// Counting sort algorithm - Sorts data in ascending order
        /// </summary>
        /// <param name="list">List to be sorted</param>
        /// <returns>Returns a sorted list of data</returns>
        private static List<int> CountingSort(List<int> list)
        {
            List<int> newList = new List<int>(list);

            int max = list.Max();
            int[] counts = new int[max + 1];

            for(int i = 0; i <=  max; i++)
            {
                counts[i] = 0;
            }

            for(int j = 0; j < list.Count; j++)
            {
                counts[list[j]]++;
            }

            for (int j = 1; j <= max; j++)
            {
                counts[j] += counts[j - 1];
            }

            for(int j = 0; j < newList.Count; j++)
            {
                newList[counts[list[j]] - 1] = list[j];
                counts[list[j]]--;
            }
            return newList;
        }

        /// <summary>
        /// Radix sort algorithm - Sorts data in ascending order
        /// Uses bins to sort data
        /// </summary>
        /// <param name="list">List to be sorted</param>
        /// <returns>Returns sorted list</returns>
        private static List<int> RadixSort(List<int> list)
        {
            List<List<int>> bin = new List<List<int>>(10);

            for (int i = 0; i < 10; i++)
            {
                bin.Add(new List<int>(list.Count));
            }

            int numDigits = list.Max().ToString().Length;

            for(int j = 0; j < numDigits; j++)
            {
                for(int n = 0; n < list.Count; n++)
                {
                    bin[Digit(list[n], j)].Add(list[n]);
                }

                CopyToResult(bin, list);

                for(int i = 0; i < 10; i++)
                {
                    bin[i].Clear();
                }
            }

            return list;
        }

        /// <summary>
        /// Copies the data from bins to a result list
        /// </summary>
        /// <param name="bin">Bin where data is stored for each integer number</param>
        /// <param name="result">Sorted list</param>
        private static void CopyToResult(List<List<int>> bin, List<int> result)
        {
            result.Clear();
            for(int i = 0;i < 10; i++)
            {
                foreach(int j in bin[i])
                {
                    result.Add(j);
                }
            }
        }

        /// <summary>
        /// Gets what digit position the number is
        /// </summary>
        /// <param name="value">Number to get the digit from</param>
        /// <param name="digitPosition">What position the number is in being passed in</param>
        /// <returns>Digit value of the value passed in</returns>
        private static int Digit(int value, int digitPosition)
        {
            return (value / (int)Math.Pow(10, digitPosition) % 10);
        }
    }
}
