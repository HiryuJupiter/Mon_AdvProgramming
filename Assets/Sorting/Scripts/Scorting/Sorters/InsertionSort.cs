using UnityEngine;
using System.Collections;

//Logic: check if the current number (key) is smaller than the previous one (predacessor)
//if it is, then go further back to check the next predacessor, while moving the previous predacessor 1 space back

namespace Sorting
{
    public class InsertionSort : BaseSorter
    {
        //protected override IEnumerator SortAscending()
        //{
        //    for (int i = 1; i < nodes.Length; i++) 
        //    {
        //        Node currentNode = nodes[i]; 

        //        int leftMostIndex = i - 1; //Index of the left-most ancestor with a value greater than keyValue

        //        while (leftMostIndex >= 0 && nodes[leftMostIndex].Value > currentNode.Value)
        //        {
        //            //If ancestor is of higher value than current, then swap with t
        //            SwapNodes(leftMostIndex + 1, leftMostIndex);

        //            //...and decrement the leftMostIndex
        //            leftMostIndex--;
        //        }

        //        //Simply visualization, not part of algorithm
        //        HighlightNode(i, true);
        //        HighlightNode(leftMostIndex + 1, true);
        //        UpdateNodes();
        //        yield return null;
        //        HighlightNode(i, false);
        //        HighlightNode(leftMostIndex + 1, false);
        //    }
        //}

        protected override IEnumerator SortAscending()
        {
            for (int i = 1; i < nodes.Length; i++)
            {
                Node currentNode = nodes[i];

                int leftMostIndex = i - 1; //Index of the left-most ancestor with a value greater than keyValue

                while (leftMostIndex >= 0 && nodes[leftMostIndex].Value > currentNode.Value)
                {
                    //If ancestor is of higher value than current, then make ancester move up in index...
                    nodes[leftMostIndex + 1] = nodes[leftMostIndex];

                    //...and decrement the leftMostIndex
                    leftMostIndex--;
                }

                nodes[leftMostIndex + 1] = currentNode;
                //SwapNodes(currentNode, nodes[leftMostIndex + 1]);

                //Simply visualization, not part of algorithm
                HighlightNodeBlue(i, true);
                HighlightNodeBlue(leftMostIndex + 1, true);
                UpdateNodes();
                yield return null;
                HighlightNodeBlue(i, false);
                HighlightNodeBlue(leftMostIndex + 1, false);
            }
        }
    }
}

/*
 protected override IEnumerator SortAscending()
        {
            for (int i = 1; i < nodes.Length; i++) 
            {
                Node currentNode = nodes[i]; 

                int leftMostIndex = i - 1; //Index of the left-most ancestor with a value greater than keyValue

                while (leftMostIndex >= 0 && nodes[leftMostIndex].Value > currentNode.Value)
                {
                    //If ancestor is of higher value than current, then make ancester move up in index...
                    nodes[leftMostIndex + 1] = nodes[leftMostIndex];

                    //...and decrement the leftMostIndex
                    leftMostIndex--;
                }

                SwapNodes(currentNode, nodes[leftMostIndex + 1]);

                //Simply visualization, not part of algorithm
                HighlightNode(i, true);
                HighlightNode(leftMostIndex + 1, true);
                UpdateNodes();
                yield return null;
                HighlightNode(i, false);
                HighlightNode(leftMostIndex + 1, false);
            }
        }
 */