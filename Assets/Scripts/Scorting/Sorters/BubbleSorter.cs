using System.Collections;
using UnityEngine;

namespace Sorting
{
    public class BubbleSorter : BaseSorter
    {
        //Need 2 loops
        //[5,2,4,3,1], first compare 5 and 2, if 5 is greater then swap the 2, then 5 again, and p
        //[2,3,1,4,5]
        //[1,2,3,4,5]


        protected override IEnumerator Sort()
        {
            int nodeCount = nodes.Length;

            Node tempNode;

            //-2 because we can't swap the final number out of the array.
            for (int i = 0; i <= nodeCount - 2; i++)
            {
                for (int j = 0; j <= nodeCount - 2; j++)
                {
                    //If the current is a number greater than the one after?
                    if (nodes[j].Index > nodes[j + 1].Index)
                    {
                        //Swap thye element
                        //Store the next element in a temp variable
                        tempNode = nodes[j + 1];

                        //Set the next element to the current one
                        nodes[j + 1] = nodes[j];

                        nodes[j] = tempNode;


                        //Simply visualization, not part of algorithm
                        StartFrame(j, j + 1);
                        yield return null;
                        EndFrame(j, j + 1);

                    }
                }
            }

            
        }
    }
}