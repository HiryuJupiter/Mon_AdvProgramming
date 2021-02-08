using System.Collections;
using UnityEngine;

//Bubble sort pushes bigger numbers back to the end, but it does not swap just once as a final step, but instead flips 2 adjacent ones every frame
//[5,2,4,3,1], Compare 5 and 2, if 5 is greater then swap the 2
//[2,3,1,4,5]

namespace Sorting
{
    public class BubbleSorter : BaseSorter
    {
        protected override IEnumerator SortAscending()
        {
            int nodeCount = nodes.Length;

            //-1 because we can't swap the final number out of the array.
            for (int i = 0; i < nodeCount - 1; i++)
            {
                for (int j = 0; j < nodeCount - 1; j++)
                {
                    //If the current number is bigger than the next, then swap them
                    if (nodes[j].Value > nodes[j + 1].Value)
                    {
                        SwapNodes(j, j + 1);
                        //Node _current = nodes[j];
                        //nodes[j] = nodes[j + 1];
                        //nodes[j + 1] = _current;

                        //Visualization
                        HighlightNode(j, true);
                        HighlightNode(j + 1, true);
                        UpdateNodes();
                        yield return null;
                        HighlightNode(j, false);
                        HighlightNode(j + 1, false);
                    }
                }
            }


        }
    }
}