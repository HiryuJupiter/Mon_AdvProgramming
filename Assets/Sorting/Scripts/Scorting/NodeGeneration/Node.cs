using UnityEngine;
using UnityEngine.UI;

//A node inbar
namespace Sorting
{
    [RequireComponent(typeof(LayoutElement), typeof(Image))]
    public class Node : MonoBehaviour
    {
        private LayoutElement layout;
        private new Image renderer;

        private Color startColor;
        private Color selectedColor = Color.blue;

        //Index is the position of the node in the perfect sequence 
        public int Value { get; private set; }

        public void Initialize(int _index, float _height, Color _color)
        {
            //Cache
            Value = _index;
            startColor = _color;

            //References
            layout = gameObject.GetComponent<LayoutElement>();
            renderer = gameObject.GetComponent<Image>();

            //Initialize attributes
            SetHeight(_height);
            SetColor(_color);
        }

        public void SetSelectedBlue(bool _isSelected)
        {
            SetColor(_isSelected ? selectedColor : startColor);
        }

        public void SetSelectedRed (bool isSelected)
        {
            SetColor(isSelected ? Color.red : startColor);
        }

        void SetHeight (float _height) => layout.preferredHeight = _height;
        void SetColor (Color _color) => renderer.color = _color;
    }
}