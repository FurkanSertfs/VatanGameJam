using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Product ", menuName = "Crate  New Product")]

public class Product : ScriptableObject
{

    public GorevAnlatim.Taskenum productType;

    public int ID;

    public string productName;

    public int price;

    public GameObject prefab;

    public Sprite productImage;

}