using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableProducts : MonoBehaviour
{
    public static TableProducts tableProducts;

    public PCCaseElement.ProductType[] tableMustHave;

    public List<ProductManager> productTableHave = new List<ProductManager>();

    private void Awake()
    {
        tableProducts = this;
    }
}
