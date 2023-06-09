using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine;


public class IAPManager : MonoBehaviour
{
    private string productone = "productone";
    private string producttwo = "producttwo";
    private string removeads = "testnonconsumable";
    private void Start()
    {
    }
    public void OnPurchaseClicked(Product product)
    {
        Debug.Log($"on purchasing success: {product.definition.id}");
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
            Debug.Log("test function check non consumable" + SaveGame.removeAds);
            // Handle the non-consumable purchase completion
        }
    }

    public void OnRestoreRemoveAds(bool success,string error)
    {
            Debug.Log($"restore: {success}\n:error: {error}");
        if (success)
        {
            Debug.Log(removeads);
            SaveGame.SaveRemoveAds();
            // Handle the non-consumable purchase completion
        }
        else
        {
            Debug.LogError($"restore with error: {error}");
        }
    }
    public void FailPurchaseOnclick(Product product, PurchaseFailureReason purchaseFailureReason)
    {
        Debug.Log("fail:" + purchaseFailureReason);
    }
    public void BuyCoins(int value)
    {
        SaveGame.BuyCoins(value);
    }
}
