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
        //If the root isn't set, make the root nde the inserting one
        if (_root == null)
        {
            _root = _inserting;
            _root.Value = _inserting.Value;

            //Set the root as if it was a root node, even if it isn't
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

        return _root;
    }
}
