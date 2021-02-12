using UnityEngine;
using System.Collections;

namespace Sorting
{
    public class BinaryInsertionSort : BaseSorter
    {
        protected override IEnumerator SortAscending()
        {
            StartCoroutine( Sort(nodes));
            UpdateNodes();
            yield return null;
        }

        IEnumerator Sort (Node[] nodes)
        {
            for (int i = 1; i < nodes.Length; i++)
            {
                Node current = nodes[i];
                int left = 0;
                int right = i;

                //Find insertion location
                while (left < right)
                {
                    int middle = (left + right) / 2;
                    //If the current value is bigger than middle, then ...
                    //... the insertion point is on the right.
                    if (current.Value > nodes[middle].Value)
                        left = middle + 1;
                    else
                        right = middle;
                }

                //Option 1: Bubble the number to the left
                for (int j = i; j > left; --j)
                {
                    SwapNodes(j, j - 1);

                    HighlightNodeBlue(j, true);
                    HighlightNodeBlue(j - 1, true);

                    UpdateNodes();
                    yield return null;
                    HighlightNodeBlue(j, false);
                    HighlightNodeBlue(j - 1, false);
                }
                
                //Option 2: Shift the array to the right of the insertion point, this is faster
                //System.Array.Copy(nodes, left, nodes, left + 1, i - left);
                //nodes[left] = current;
            }
        }
    }
}

//Perfectly working before visualization:
//public class BinaryInsertionSort : BaseSorter
//{
//    protected override IEnumerator SortAscending()
//    {
//        Sort(nodes);
//        UpdateNodes();
//        yield return null;

//    }

//    void Sort(Node[] nodes)
//    {
//        for (int i = 1; i < nodes.Length; i++)
//        {
//            Node current = nodes[i];
//            int left = 0;
//            int right = i;

//            //Find insertion location
//            while (left < right)
//            {
//                int middle = (left + right) / 2;
//                //If the current value is bigger than middle, then ...
//                //... the insertion point is on the right.
//                if (current.Value > nodes[middle].Value)
//                    left = middle + 1;
//                else
//                    right = middle;
//            }

//            //Option 1: Bubble the number to the left
//            //for (int j = i; j > left; --j)
//            //{
//            //    SwapNodes(j, j - 1);
//            //}

//            //Option 2: Shift the array to the right of the insertion point
//            System.Array.Copy(nodes, left, nodes, left + 1, i - left);
//            nodes[left] = current;
//        }
//    }
//}

/*
        int BinarySearch (Node[] array, int left, int right, int target)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (array[target].Value == array[middle].Value)
                {
                    return middle;
                }
                else if (array[target].Value < array[middle].Value)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            //Target not found
            return -1;
        }
 */