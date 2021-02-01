using System.Collections;
using UnityEngine;

namespace Sorting
{
    public class SelectionSorter : BaseSorter
    {
        //[5,2,4,3,1]
        //looks at the first element, number 5, at index 0. 
        //As it moves to the next number, it replaces 5 for the next smaller number
        //Then at the end, it flips the smallest number to the index 0
        //[1, 2, 4, 3, 1]
        // Next, it start the loop at index 1, because it knows index 0 is correct.


        protected override IEnumerator Sort()
        {
            int nodeCount = nodes.Length;
            int smallest; //This is actually the smallest item index, not the item value.
            int old; // not part of the algorithm, just for visualization

            Node tempNode;

            for (int i = 0; i < nodeCount - 1; i++)
            {
                //Assign the smallest number to the loop's iterator
                smallest = i;
                old = i;

                //loop this iteration to the end
                for (int j = i + 1; j < nodeCount; j++)
                {
                    //Compare this index to the current smallest index item
                    if (nodes[j].Index < nodes[smallest].Index)
                    {
                        //Swap thye element
                        //Store the next element in a temp variable
                        tempNode = nodes[smallest];

                        //Set the next element to the current one
                        nodes[smallest] = nodes[old];

                        nodes[old] = tempNode;


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