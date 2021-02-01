using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sorting
{
    public class NodeFactory : MonoBehaviour
    {
        [SerializeField] private RectTransform canvasTransform;
        [SerializeField] private Node   prefab;
        [SerializeField] private Color  startColor   = Color.red;
        [SerializeField] private Color  endColor     = Color.green;

        private int     nodeCount;
        private float   scaleStep;

        public void Setup(int _nodeCount)
        {
            nodeCount = _nodeCount;
            scaleStep = canvasTransform.rect.height / _nodeCount;
        }

        public Node CreateNode(int _index)
        {
            Node node = Instantiate(prefab, transform);
            node.gameObject.name = string.Format("Node [{0}]", _index);

            Color nodeColor = Color.Lerp(startColor, endColor, Mathf.Clamp01((float)_index / nodeCount));
            float height = scaleStep * (_index + 1);

            node.Initialize(_index, height, nodeColor);
            return node;
        }

        public Node[] CreateNodes (int _nodeCount)
        {
            nodeCount = _nodeCount;
            scaleStep = canvasTransform.rect.height / _nodeCount;

            Node[] nodes = new Node[_nodeCount];
            for (int i = 0; i < _nodeCount; i++)
            {
                nodes[i] = CreateNode(i);
            }
            return nodes;
        }
    }
}