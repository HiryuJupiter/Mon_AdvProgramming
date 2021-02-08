using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeFramework;

public class NodeGenerator : MonoBehaviour
{
    public static NodeGenerator Instance;

    [SerializeField, Range(1, 10)]
    private int nodeCount = 5;
    [SerializeField]
    private Vector2Int nodeRange = new Vector2Int(10, 100);

    private BinaryTree tree = new BinaryTree();
    
    public static void HighLightNode (string nodeName)
    {
        Node lookingFor;
        Node root;


        //tree.HighLightNode()
    }

    private void OnValidate() //In Unity editor, this runs whenever you change the variable value.
    {
        //Prevent the x range from going above the y range
        nodeRange.x = Mathf.Clamp(nodeRange.x, 10, Mathf.Max(nodeRange.y - 1, 10));
        //Revent the y range from going below the x range
        nodeRange.y = Mathf.Clamp(nodeRange.y, Mathf.Max(nodeRange.x - 1, 11), 100);
        //nodeRange.x = Mathf.Clamp(nodeRange.x, 10, nodeRange.y - 1); //dragging too quickly causes problems
    }


    void Awake ()
    {
        Instance = this;
    }

    void Start()
    {
        NodeFactory.Setup(gameObject);
        List<int> numbers = GenerateNumbers();

        while (numbers.Count > 0)
        {
            //Create a new node using the last item in the list
            Node newNode = NodeFactory.Create(numbers[numbers.Count - 1]);
            //Insert the new node into the tree
            tree.Root = tree.Insert(tree.Root, newNode);

            numbers.RemoveAt(numbers.Count - 1);
        }
    }

    //Generates a list of numbers randomly select ffom all possibile range values.
    // [10, 11, 12, 13 ... ]
    // Never want to repeat after selecting
    //Involves iterating through a list as it changes
    private List<int> GenerateNumbers ()
    {
        List<int> allValues = new List<int>();
        List<int> generated = new List<int>(); //Of the randomly selected numbers

        //Populate the all values list with the numbers from the range
        for (int i = nodeRange.x; i < nodeRange.y; i++)
        {
            allValues.Add(i);
        }

        //Generate the nodeCounter amount of numbers
        for (int i = 0; i < nodeCount; i++)
        {
            //SElect an index within the whole size ofthe list
            int index = Random.Range(0, allValues.Count);
            //Copy the number of the index from allvaluyes into generated list
            generated.Add(allValues[index]);
            allValues.RemoveAt(index);
        }

        return generated;
    }
}
