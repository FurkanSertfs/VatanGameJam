using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Product ", menuName = "Crate  New Product")]

public class Product : ScriptableObject
{

    public GorevAnlatim.Taskenum productType;

    public OwnedProducts.Model model;
    
    public int ID;

    public float skor;

    public string productName;

    public int price,sellPrice;

    public GameObject prefabEnvanter,prefabProduct;

    public Sprite productImage;

    public int caseModelID;

}
