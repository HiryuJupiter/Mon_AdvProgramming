using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeFramework;

//When it reaches a null nude it'll set the logic in reverse back up

public class BinaryTree : MonoBehaviour
{
    public Node Root;

    public Node Insert(Node _root, Node _inserting)
    {
        //The root == null when we pass in the first node.
        if (_root == null)
        {
            _root = _inserting;
            _root.Value = _inserting.Value;

            _root.Setup(null, NodeType.Root);
        }
        //Should this be the left node?
        else if (_inserting < _root)
        {
            //It should, so insert it and setup the node
            _root.Left = Insert(_root.Left, _inserting);
            _root.Left.Setup(_root, NodeType.Left);
        }
        else
        {
            //Right node
            _root.Right = Insert(_root.Right, _inserting);
            _root.Right.Setup(_root, NodeType.Right);
        }

        //Connect the nodes here
        if (_root != null)
        {
            ConnectNodes(_root);
        }

        return _root;
    }

    public void Traverse(Node _root, Node _target)
    {
        if (_root == null)
            return;

        _root.Activate();

        if (_target < _root)
        {
            Traverse(_root.Left, _target);
        }
        else if (_target > _root)
        {
            Traverse(_root.Right, _target);
        }
    }

    //Some connect funcitons
    private void ConnectNodes(Node _root)
    {
        if (_root.Left != null)
        {
            _root.LeftConnector.positionCount = 2;
            _root.LeftConnector.SetPosition(0, _root.transform.position);
            _root.LeftConnector.SetPosition(1, _root.Left.transform.position);
        }
        else
        {
            _root.LeftConnector.positionCount = 0;
        }
        
        if (_root.Right != null)
        {
            _root.RightConnector.positionCount = 2;
            _root.RightConnector.SetPosition(0, _root.transform.position);
            _root.RightConnector.SetPosition(1, _root.Right.transform.position);
        }
        else
        {
            _root.RightConnector.positionCount = 0;
        }
    }

    //Node highlight
    public void HighLightNode (Node lookingFor, Node root)
    {

    }

    public void HighLightNode(string nodeName)
    {

    }

    //Node FindNode (string nodeName)
    //{
    //    //Traverse through node

    //}

    //bool TryFindNode (Node node)
    //{

    //    if (node.Left != null)
    //    {

    //    }
    //    else if (node.Right != null)
    //    {

    //    }

    //    return false;
    //}
}
