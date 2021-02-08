using UnityEngine;
using System.Collections;

namespace Sorting
{
    public class QuickSort : BaseSorter
{
        protected override IEnumerator SortAscending()
        {
            StartCoroutine(DoQuickSort(0, nodes.Length - 1));
            yield break;
        }

        IEnumerator DoQuickSort (int left, int right)
        {
            if (left >= right) //This occurs upon reaching the end of recurrsion.
                yield break;

            int pivotIndex = Partition(left, right);

            DoQuickSort(left, pivotIndex - 1); //Sort left side
            DoQuickSort(pivotIndex + 1, right); //Sort right side
        }

        //Partition a sequence into two groups, seperated by a pivot
        int Partition (int low, int high)
        {
            //Takes the last element as pivot
            int pivotIndex = high;
            int pivotValue = nodes[pivotIndex].Value;

            //Loop through the array from left bound to right bound.
            // J is the current element we're looking at, it's incremented automatically by the for loop.
            // I will point to the right-most number in the lower section.
            int i = low - 1; 
            for (int j = 0; j < high; j++)
            {
                if (nodes[j].Value < pivotValue)
                {
                    i++;

                    //If the current value is small than pivotValue, then move it to the left side, and increment the lower-section's marker
                    SwapNodes(i, j);

                    //HighlightNode(i, true);
                    //HighlightNode(j, true);
                    UpdateNodes();
                    //yield return null;
                    //HighlightNode(i, false);
                    //HighlightNode(j, false);
                }
            }

            //Since in the first step, the pivot selected was the last number, in order for it to now
            //seperate the low and high group, it need to swap with the number on the right side of i,
            //namely, swap with the first number of the high group.
            SwapNodes(i + 1, high);

            //Returns the pivot index.
            return i + 1;
        }
    }
}