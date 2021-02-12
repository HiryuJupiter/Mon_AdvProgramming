using System.Collections;
using UnityEngine;

namespace Sorting
{
    public abstract class BaseSorter : MonoBehaviour
    {
        protected NodeGenerator generator;

        protected Node[] nodes;

        void Start()
        {
            generator = NodeGenerator.Instance;
        }

        public void RunSorter()
        {
            nodes = generator.Nodes;
            StartCoroutine(SortAscending());
        }

        protected abstract IEnumerator SortAscending();

        protected void SwapNodes(int indexA, int indexB)
        {
            try
            {
                Node _temp = nodes[indexA];
                nodes[indexA] = nodes[indexB];
                nodes[indexB] = _temp;
            }
            catch
            {

                Debug.Log("Failed to swap nodes of indexes :" + indexA + " and " + indexB);
            }
        }

        protected void SwapNodes(Node node1, Node node2)
        {
            Node _temp = node1;
            node1 = node2;
            node2 = _temp;
        }

        protected void HighlightNodeBlue(int _node, bool isHighlighted)
        {
            generator.HighlightNodeBlue(_node, isHighlighted);
            generator.SetNodes(nodes);
        }

        protected void HighlightNodeRed(int _node, bool isHighlighted)
        {
            generator.HighlightNodeRed(_node, isHighlighted);
            generator.SetNodes(nodes);
        }

        protected void UpdateNodes ()
        {
            generator.SetNodes(nodes);
        }

        protected void PrintNodes(int low, int high)
        {
            string log = "";
            for (int i = low; i <= high; i++)
            {
                log = log + "[" + i + "]  = " + nodes[i].Value + ", ";
            }
            Debug.Log(log);
        }
    }
}