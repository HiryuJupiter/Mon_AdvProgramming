using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple factory: client > concrete static factory

//Standard factory: client > abstract factory where you can select which subclass factor to create

//Abstract factory: clent > select a factory > then pass the factory or combine it with a 
//second layer of decion - an assembly-sequence-instruction, and you let the two layers combine

//In standard factory, the factory subclass decides what parts to construct
//In abstract factory, the factory can have layers of factory and assemblers that produce a 
//family of related objects. The result is a composite object that is composed of many different
//parts, assembled together.

//1. bstract class involves a factory and another seperate class, you can call it the "director" class 
// 2. creates many parts that combines into a composite 
//3. it is therefore 1 level higher in abstraction than factory. Factory pattern abstrcts the 
//way objects are created, abstract factory abstracts the way factories are created.
//final result 

//Example of Abstract factory: 
/*You are a shop managger who doesn't want to handle the backend stuff. There are countless 
 * factories in China that prints TShirts and Jeans, but you're not familiar with that side
 * of the business. So you contact an intermediary organization, they will contact the factories,
 * and receive the blank TShirt made from them, they will print your logo onto the TShirt, add the
 * name tags, put them in nice plastic wrappers, and ship them to your store for you to sell them. 
 * This entire time, you don't have to contact directly any factories.  
 */

public abstract class AbstractFactory : MonoBehaviour
{
    public abstract Article GetArticle();
}

public class ShoeAFactory : AbstractFactory
{
    public override Article GetArticle()
    {
        Article a = Resources.Load<Article>("Shoe");
        Article b = Resources.Load<Article>("Shoe2");
        //Usually abstract factor makes a whole bunch of things, rarely just 1 thing.
        return a;
    }
}

public class ClothesAFactory : AbstractFactory
{
    public override Article GetArticle()
    {
        Article a = Resources.Load<Article>("Clothes");
        Article b = Resources.Load<Article>("Clothes2");
        return a;
    }
}

public class IntermediaryCreatorAndAssembler
{
    AbstractFactory factory;
    List<Article> shopStock = new List<Article>();
    public IntermediaryCreatorAndAssembler(AbstractFactory factory)
    {
        this.factory = factory;
    }

    public void OrderAndProcessAndAssemble ()
    {
        Article a = factory.GetArticle();
        Article b = factory.GetArticle();
        Article c = factory.GetArticle();
        //do things, e.g. print logos, add price tags, 
        shopStock.Add(a);
        shopStock.Add(b);
        shopStock.Add(c);
    }
}

class VeryMysteriousClient
{
    void Awake()
    {
        AbstractFactory factory = new ShoeAFactory();
        Article a = factory.GetArticle();
    }
}