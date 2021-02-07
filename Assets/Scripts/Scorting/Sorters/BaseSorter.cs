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
            Node _temp = nodes[indexA];
            nodes[indexA] = nodes[indexB];
            nodes[indexB] = _temp;
        }

        protected void SwapNodes(Node node1, Node node2)
        {
            Node _temp = node1;
            node1 = node2;
            node2 = _temp;
        }

        protected void HighlightNode(int _node, bool isHighlighted)
        {
            generator.HighlightNode(_node, isHighlighted);
            generator.SetNodes(nodes);
        }

        protected void UpdateNodes ()
        {
            generator.SetNodes(nodes);
        }
    }
}