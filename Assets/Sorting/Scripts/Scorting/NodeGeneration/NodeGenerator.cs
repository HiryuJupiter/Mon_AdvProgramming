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
        public static NodeGenerator Instance;

        [SerializeField, Range(1, 250)]
        private int nodeCount = 10;

        private NodeFactory factory;
        private Node[] perfectSequence;
        public Node[] Nodes { get; private set; } //Current sequence of nodes

        public void SetNodes(Node[] _sorted)
        {
            Nodes = _sorted;
            for (int i = Nodes.Length - 1; i >= 0; i--)
                Nodes[i].transform.SetAsFirstSibling();
        }

        public void HighlightNodeBlue(int index, bool isHighlighed)
        {
            Nodes[index].SetSelectedBlue(isHighlighed);
        }

        public void HighlightNodeRed(int index, bool isHighlighed)
        {
            Nodes[index].SetSelectedRed(isHighlighed);
        }

        public void ShuffleNodes()
        {
            StartCoroutine(Shuffle(perfectSequence));
        }

        private void Awake()
        {
            //Initialize and reference
            Instance = this;
            Nodes = new Node[nodeCount];
            factory = GetComponent<NodeFactory>();

            //Create a perfect sequence of nodes and set it to current
            perfectSequence = new Node[nodeCount];
            perfectSequence = factory.CreatePerfectSequence(nodeCount);
            for (int i = 0; i < perfectSequence.Length; i++)
            {
                Nodes[i] = perfectSequence[i];
            }
            //Note you cannot do Nodes = perfectSquence
        }

        private IEnumerator Shuffle(Node[] _nodes)
        {
            //Initialize unshuffled indexes
            List<int> unshuffledIndexes = new List<int>();
            for (int i = 0; i < Nodes.Length; i++)
            {
                unshuffledIndexes.Add(i);
            }

            for (int i = 0; i < nodeCount; i++)
            {
                //Select a random unshuffled node and move it to the front 
                int randonUnshuffledIndex = Random.Range(0, unshuffledIndexes.Count);
                Nodes[i] = _nodes[unshuffledIndexes[randonUnshuffledIndex]];
                Nodes[i].transform.SetSiblingIndex(i);

                unshuffledIndexes.RemoveAt(randonUnshuffledIndex);

                yield return null;
            }
        }

        //void OnGUI()
        //{
        //    for (int i = 0; i < Nodes.Length; i++)
        //    {
        //        GUI.Label(new Rect(20, 20 + 20 * i, 200, 20), i + ": " + Nodes[i].Value);
        //    }
        //}
    }
}

/*
         private IEnumerator Shuffle(Node[] _nodes)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < nodeCount; i++)
                indexes.Add(i);

            int indexer = 0;
            while (indexes.Count > 0)
            {
                int randIndex = Random.Range(0, indexes.Count);
                Nodes[indexer] = _nodes[indexes[randIndex]];

                Nodes[indexer].transform.SetSiblingIndex(indexer);

                indexer++;

                indexes.RemoveAt(randIndex);

                yield return null;
            }
        }

 */