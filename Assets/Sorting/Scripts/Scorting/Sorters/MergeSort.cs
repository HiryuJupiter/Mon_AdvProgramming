using System.Collections;
using UnityEngine;

//Bubble sort pushes bigger numbers back to the end, but it does not swap just once as a final step, but instead flips 2 adjacent ones every frame
//[5,2,4,3,1], Compare 5 and 2, if 5 is greater then swap the 2
//[2,3,1,4,5]

namespace Sorting
{
    public class MergeSort : BaseSorter
    {
        protected override IEnumerator SortAscending()
        {
            int nodeCount = nodes.Length;

            int left = 0;
            Sort(0, nodeCount - 1);

            for (int i = 0; i < nodeCount - 1; i++)
            {

            }

            //Visualization
            HighlightNodeBlue(j, true);
            HighlightNodeBlue(j + 1, true);
            UpdateNodes();
            yield return null;
            HighlightNodeBlue(j, false);
            HighlightNodeBlue(j + 1, false);
        }

        void Sort(int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                Sort(left, middle);
                Sort(middle + 1, right);

                Merge(left, middle, right);
            }
        }

        void Merge(int left, int middle, int right)
        {
            //Find size of two subarrays to be merged
            int n1 = middle - left + 1;
            int n2 = right = middle;

            //Temp arrays
            Node[] L = new Node[n1];
            Node[] R = new Node[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
            {
                L[i] = nodes[left + i];
            }
            for (int j; j < n2; ++j)
                R[j] = nodes[middle + 1 + j];

        }
    }
}