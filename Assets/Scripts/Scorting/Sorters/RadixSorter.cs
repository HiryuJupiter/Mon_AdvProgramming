using System.Collections;
using UnityEngine;

using Array = System.Array;


namespace Sorting
{
    public class RadixSorter : BaseSorter
    {
        // [272, 45, 75, 81, 501, 2, 24, 66]
        // It sorts by the least significant digits
        // Sorts by 2, 5, 5, 1, 1, 2, 4, 6
        // The single digits. 
        // 81, 501, 272, 2, 24, 45, 75, 66
        // Next it looks at the second digits
        // 2 becomes 02
        // 501, 02, 24, 45, 66, 272, 75, 81, 
        //catch, ctreating a new array every time


        protected override IEnumerator Sort()
        {
            int nodeCount = nodes.Length;
            int i, j;
            Node[] temp = new Node[nodes.Length];

            //Integer cannot have more than 31 digits
            for (int shift = 31; shift > -1; --shift)
            {
                //Reset j to zero
                j = 0;

                //loop through the whole array
                //Why is removing -1 changes it
                //for (i = 0; i < nodeCount - 1; i++)
                //Why does this works??? for (i = 0; i < nodeCount; ++i)
                for (i = 0; i < nodeCount; ++i)
                {
                    //Determine if the bit shifted is above 0
                    //If it is above 0, it means there is a number
                    //e.g. shifting 2 << 1 = 0. Shifting 12 << 1 becaues we're in the next digit.
                    bool move = (nodes[i].Index << shift) >= 0; 

                    if (shift == 0 ? !move : move)
                    {
                        nodes[i - j] = nodes[i];
                    }
                    else
                    {
                        temp[j++] = nodes[i];
                    }

                }

                //Copy the data to the temp array
                Array.Copy(temp, 0, nodes, nodes.Length - j, j);

                //Simply visualization, not part of algorithm
                StartFrame(0, 1);
                yield return null;
                EndFrame(0, 1);
            }
        }
    }
}