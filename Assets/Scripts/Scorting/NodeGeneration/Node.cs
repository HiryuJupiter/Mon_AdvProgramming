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

        public void Initialize(int _index, float _height, Color _color)
        {
            //Cache
            index = _index;
            startColor = _color;

            //References
            layout = gameObject.GetComponent<LayoutElement>();
            renderer = gameObject.GetComponent<Image>();

            //Initialize attributes
            SetHeight(_height);
            SetColor(_color);
        }

        public void SetSelected(bool _isSelected)
        {
            SetColor(_isSelected ? selectedColor : startColor);
        }

        void SetHeight (float _height) => layout.preferredHeight = _height;
        void SetColor (Color _color) => renderer.color = _color;
    }
}