using UnityEngine;
using UnityEngine.UI;

//A node inbar
namespace Sorting
{
    [RequireComponent(typeof(LayoutElement), typeof(Image))]
    public class Node : MonoBehaviour
    {
        private int index = 0;
        private LayoutElement layout;
        private new Image renderer;

        private Color startColor;
        private Color selectedColor = Color.blue;

        //Index is the numer of the node
        public int Index => index;

        public void Setup(int _index, float _height, Color _color)
        {
            index = _index;

            layout = gameObject.GetComponent<LayoutElement>();
            layout.preferredHeight = _height;

            renderer = gameObject.GetComponent<Image>();
            renderer.color = _color;
            startColor = _color;
        }

        
        //Set the node to be the "active" or "highlighted" node.
        public void SetSelected(bool _isSelected)
        {
            renderer.color = _isSelected ? selectedColor : startColor;
        }
    }
}