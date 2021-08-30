using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int ItemID;
    public Text PriceText;
    public Text QuantityText;
    public GameObject ShopManager;
    ShopManager shopManager;

    void Start()
    {
        shopManager = ShopManager.GetComponent<ShopManager>();
    }
    void Update()
    {
        PriceText.text = "X " + shopManager.shopItems[2, ItemID].ToString();
        QuantityText.text = shopManager.shopItems[3, ItemID].ToString();   
    }
}
