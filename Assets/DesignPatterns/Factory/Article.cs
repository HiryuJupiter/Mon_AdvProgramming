using System.Collections;
using UnityEngine;

//First you have a bunch of classes with a common interface or base class
public abstract class Article : MonoBehaviour { }
public class ClothesArticle : Article { }
public class ToysArticle : Article { }
public class ShoeArticle : Article { }

public enum ArticleTypes { Clothes, Toy, Shoe }

/*
 Alternatively , use IArticle. It's the same thing in this case
 */