using UnityEngine;
using System.Collections;

namespace Tests
{
    public class Test : MonoBehaviour
    {
        int[] arr1;
        int[] arr2;

        void Start()
        {
            arr1 = new int[] { 0, 1, 2, 3, 4 };
            arr2 = arr1;
            arr2[0] = 4;
        }

        void OnGUI()
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                GUI.Label(new Rect(20, 20 + 20 * i, 200, 20), "i: " + arr1[i]);
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                GUI.Label(new Rect(220, 20 + 20 * i, 200, 20), "i: " + arr2[i]);
            }
        }

        void Update()
        {

        }
    }
}