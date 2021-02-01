using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Node factory is the class that does the actual spawning
Node generator gives the command to factory on when to start building and how many nodes to build.
 */

namespace Sorting
{
    [RequireComponent(typeof(NodeFactory))]
    public class NodeGenerator : MonoBehaviour
    {
        [SerializeField, Range(1, 250)]
        private int nodeCount = 10;

        private Node[] perfectSequence;

        private NodeFactory factory;
        public Node[] Nodes { get; private set; } //Current sequence of nodes

        public void SetNodes(Node[] _sorted)
        {
            Nodes = _sorted;
            for (int i = Nodes.Length - 1; i >= 0; i--)
                Nodes[i].transform.SetAsFirstSibling();
        }

        public void SetSelectedNodes(int _first, int _second, bool _selectedState)
        {
            Nodes[_first].SetSelected(_selectedState);
            Nodes[_second].SetSelected(_selectedState);
        }

        public void ShuffleNodes()
        {
            StartCoroutine(Shuffle());
        }

        private void Awake()
        {
            //Initialize and reference
            perfectSequence = new Node[nodeCount];
            Nodes = new Node[nodeCount];
            factory = GetComponent<NodeFactory>();

            //Create starting nodes
            perfectSequence = factory.CreateNodes(nodeCount);
            Nodes = perfectSequence;
        }

        private IEnumerator Shuffle()
        {
            List<int> unshuffledIndexes = new List<int>();
            for (int i = 0; i < nodeCount; i++)
            {
                unshuffledIndexes.Add(i);
            }
                

            //for (int i = 0; i < nodeCount; i++)
            //{
            //    int randIndex = Random.Range(0, tempIndexes.Count);
            //    nodes[i] = generatedNodes[tempIndexes[randIndex]];

            //    nodes[i].transform.SetSiblingIndex(i);

            //    tempIndexes.RemoveAt(randIndex);

            //    yield return null;
            //}

            int frontIndex = 0;
            while (unshuffledIndexes.Count > 0)
            {
                //Select a random node from the perfect sequence and move it to the front 
                int randomUnshuffledIndex = Random.Range(0, unshuffledIndexes.Count);
                Nodes[frontIndex] = perfectSequence[unshuffledIndexes[randomUnshuffledIndex]];

                Nodes[frontIndex].transform.SetSiblingIndex(frontIndex);

                frontIndex++;

                unshuffledIndexes.RemoveAt(randomUnshuffledIndex);

                yield return null;
            }
        }
    }
}