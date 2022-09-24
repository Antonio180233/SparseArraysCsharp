using System;
using System.Collections.Generic;

class GFG
{

    // Binary Search in an array with blanks  
    static int binarySearch(string[] arr, int low,
                            int high, string x)
    {
        if (low > high)
            return -1;

        int mid = (low + high) / 2;

        // Modified Part 
        if (arr[mid] == "")
        {
            int left = mid - 1;
            int right = mid + 1;

            // Search for both side for 
            // a non empty string 
            while (true)
            {

                // No non-empty string on both sides  
                if (left < low && right > high)
                    return -1;

                if (left >= low && arr[left] != "")
                {
                    mid = left;
                    break;
                }

                else if (right <= high &&
                    arr[right] != "")
                {
                    mid = right;
                    break;
                }

                left--;
                right++;
            }
        }

        // Normal Binary Search 
        if (arr[mid] == x)
            return mid;

        else if (x.CompareTo(arr[mid]) < 0)
            return binarySearch(arr, low,
                                mid - 1, x);
        else
            return binarySearch(arr, mid + 1,
                               high, x);
    }

    static int sparseSearch(string[] arr,
                            string x, int n)
    {
        return binarySearch(arr, 0, n - 1, x);
    }

    // Driver Code 
    public static void Main(string[] args)
    {
        string[] arr = { "ab", "ab", "absz", "abs",
                     "al", "abs", "ide",  "practice",
                     "nada", "ide", "ide", "quiz"};

        string x;
        x = Console.ReadLine();
        int n = x.Length;

         
      
        int index = sparseSearch(arr, x, n);

        if (index!=-1)
            Console.Write(x + " Se encuentra en el indice" +
                          index);
        else
            Console.Write(x + " No se encuentra ");
    }
}