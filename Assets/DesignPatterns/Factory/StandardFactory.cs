using System.Collections;
using UnityEngine;

//In simple factory, you entrust the instantiation to a factory class, that is static and
//concrete.

//In standard factory, you entrust the instantiation to the subclass of a Factory class.
//The factory base class is abstract.

public abstract class StandardFactory
{
    public Article GetArticle ()
    {
        Article a = this.ConstructArticle();
        //Do things to a;
        return a;
    }
    
    protected abstract Article ConstructArticle();
}

public class ShoeFactory : StandardFactory
{
    protected override Article ConstructArticle()
    {
        Article a = Resources.Load<Article>("Shoe");
        //Article a = new ShoeArticle();
        //a.Produced();
        return a;
    }
}

class SuperMysteriousClient
{
    void Awake ()
    {
        StandardFactory factory = new ShoeFactory();
        Article a = factory.GetArticle();
    }
}