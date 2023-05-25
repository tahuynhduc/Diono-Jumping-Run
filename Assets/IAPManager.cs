using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;


public class IAPManager : MonoBehaviour
{
    SaveGame save;
    private string productone = "productone";
    private string producttwo = "producttwo";
    private string removeads = "removeads";

    private void Start()
    {
        save = FindAnyObjectByType<SaveGame>();
    }
    public void OnPurchaseClicked(Product product)
    {
        if (product.definition.id == productone)
        {
            BuyCoins(250);
        }
        if (product.definition.id == removeads)
        {

        }
    }
    public void FailPurchaseOnclick(Product product,PurchaseFailureReason purchaseFailureReason)
    {
        Debug.Log("fail:"+ purchaseFailureReason);
    }
    public void BuyCoins(int value)
    {
        SaveGame.BuyCoins(value);
    }
}
