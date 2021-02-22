using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The factory is either pure static or a monoBehavior with static methods.
//You want a mono factory when you want to expose fields.

class SimpleFactory : MonoBehaviour
{
    static Article clothes;
    static Article toys;
    public static void Setup (GameObject gameObject)
    {
        clothes = Resources.Load<Article>("clothes");
        toys = Resources.Load<Article>("toys");
    }
    public static Article Create(ArticleTypes articleType)
    {
        switch (articleType)
        {
            case ArticleTypes.Clothes:
                return MonoBehaviour.Instantiate(clothes, Vector3.zero, Quaternion.identity);
            case ArticleTypes.Toy:
                return MonoBehaviour.Instantiate(toys, Vector3.zero, Quaternion.identity);
            default:
                return MonoBehaviour.Instantiate(toys, Vector3.zero, Quaternion.identity);
        }
    }
}

public class TheMysteriousClient : MonoBehaviour
{
    void Start()
    {
        Article a = SimpleFactory.Create(ArticleTypes.Clothes);
    }
}

