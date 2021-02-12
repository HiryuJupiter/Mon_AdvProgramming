using UnityEngine;
using System.Collections;

namespace Tests
{
    public class Test : MonoBehaviour
    {
        int[] arr1;
        int[] arr2;

        void Awake()
        {
            arr1 = new int[] { 0, 1, 2, 3, 4, 5, 11, 22, 10, 20 };
            arr2 = new int[arr1.Length];
            arr1.CopyTo(arr2, 0);

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = arr1[i] << 1;
            }
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

    }
}