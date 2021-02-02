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
            StartCoroutine(Shuffle(Nodes));
        }

        private void Awake()
        {
            //Initialize and reference
            perfectSequence = new Node[nodeCount];
            Nodes = new Node[nodeCount];
            factory = GetComponent<NodeFactory>();

            //Create starting nodes
            perfectSequence = factory.CreateNodes(nodeCount);
            for (int i = 0; i < perfectSequence.Length; i++)
            {
                Nodes[i] = perfectSequence[i];
            }
            //Note you cannot do Nodes = perfectSquence
        }

        private IEnumerator Shuffle(Node[] _nodes)
        {

            Debug.Log(" ------ ");
            //Initialize unshuffled indexes
            List<int> unshuffledIndexes = new List<int>();
            for (int i = 0; i < Nodes.Length; i++)
            {
                unshuffledIndexes.Add(i);
            }

            for (int i = 0; i < nodeCount; i++)
            {
                //Select a random node from unshuffled nodes...
                int randUnshuffledIndex = Random.Range(0, unshuffledIndexes.Count); //Randomly selected unshuffled index
                Nodes[i] = _nodes[unshuffledIndexes[randUnshuffledIndex]];

                //...and move it to the front 
                Nodes[i].transform.SetSiblingIndex(i);

                unshuffledIndexes.RemoveAt(randUnshuffledIndex);
                yield return null;
            }
        }


        private IEnumerator Shuffle()
        {
            Debug.Log(" ------ ");
            //Initialize unshuffled indexes
            List<int> unshuffledIndexes = new List<int>();
            for (int i = 0; i < Nodes.Length; i++)
            {
                unshuffledIndexes.Add(i);

                Debug.Log(" unshuffledIndexes added " + i);
            }

            for (int i = 0; i < nodeCount; i++)
            {
                //Select a random node from unshuffled nodes...
                int randUnshuffledIndex = Random.Range(0, unshuffledIndexes.Count); //Randomly selected unshuffled index
                Nodes[i] = perfectSequence[unshuffledIndexes[randUnshuffledIndex]];

                //...and move it to the front 
                Nodes[i].transform.SetSiblingIndex(i);

                unshuffledIndexes.RemoveAt(randUnshuffledIndex);
                yield return null;
            }

            //int frontIndex = 0;
            //while (unshuffledIndexes.Count > 0)
            //{
            //    //Select a random node from unshuffled nodes...
            //    int random = Random.Range(0, unshuffledIndexes.Count); //Randomly selected unshuffled index
            //    int unshuffledIndex = unshuffledIndexes[random];
            //    Nodes[frontIndex] = perfectSequence[unshuffledIndex];

            //    //...and move it to the front 
            //    Nodes[frontIndex].transform.SetSiblingIndex(frontIndex);

            //    frontIndex++;

            //    unshuffledIndexes.RemoveAt(random);

            //    yield return null;
            //}
        }

        void OnGUI()
        {
            for (int i = 0; i < Nodes.Length; i++)
            {
                GUI.Label(new Rect(20, 20 + 20 * i, 200, 20), i + ": " + Nodes[i].Value);
            }

            for (int i = 0; i < Nodes.Length; i++)
            {
                GUI.Label(new Rect(220, 20 + 20 * i, 200, 20), i + ": " + perfectSequence[i].Value);
            }
        }
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