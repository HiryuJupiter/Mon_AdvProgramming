using UnityEngine;
using System.Collections;

namespace Sorting
{
    public class QuickSort : BaseSorter
{
        protected override IEnumerator SortAscending()
        {
            int nodeCount = nodes.Length;

            for (int i = 0; i < nodeCount - 1; i++)
            {
                for (int j = i + 1; j < nodeCount; j++)
                {
                    //If the value in this node is smaller, then update smallest value
                    if (nodes[j].Value < nodes[i].Value)
                    {
                        SwapNodes(i, j);

                        //Simply visualization, not part of algorithm
                        HighlightNode(i, true);
                        HighlightNode(j, true);
                        UpdateNodes();
                        yield return null;
                        HighlightNode(i, false);
                        HighlightNode(j, false);
                    }
                }
            }
        }
    }
}