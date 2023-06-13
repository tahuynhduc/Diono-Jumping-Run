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
    private string removeads = "testver2Name";
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
            bool checkBuy = true;
            DatabaseManager.SaveData(DatabaseManager.DatabaseKey.RemoveAds, checkBuy);
            Debug.Log(checkBuy);

            //SaveGame.SaveRemoveAds();
            //Debug.Log("test function check non consumable" + SaveGame.removeAds);
            // Handle the non-consumable purchase completion
        }
    }
    public void FailPurchaseOnclick(Product product, PurchaseFailureReason purchaseFailureReason)
    {
        Debug.Log("fail:" + purchaseFailureReason);
    }
    public void BuyCoins(int value)
    {
        DatabaseManager.CoinsGame(value);
    }
}
