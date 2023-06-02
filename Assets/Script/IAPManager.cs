using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine;


public class IAPManager : IAPButton
{
    private string productone = "productone";
    private string producttwo = "producttwo";
    private string removeads = "removeads";
    public void OnPurchaseClicked(Product product)
    {
        if (product.definition.id == productone)
        {
            BuyCoins(250);
        }
        if (product.definition.id == producttwo)
        {
            BuyCoins(500);
        }
        if (product.definition.id == removeads)
        {
            SaveGame.SaveRemoveAds();
            Debug.Log(SaveGame.removeAds);
            // Handle the non-consumable purchase completion
        }
        
    }
    public void FailPurchaseOnclick(Product product, PurchaseFailureReason purchaseFailureReason)
    {
        Debug.Log("fail:" + purchaseFailureReason);
        if (product.receipt != null)
        {
            SaveGame.SaveRemoveAds();
            Debug.Log(SaveGame.removeAds);
        }
    }
    public void BuyCoins(int value)
    {
        SaveGame.BuyCoins(value);
    }
}
