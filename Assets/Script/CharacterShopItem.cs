using System;
using TMPro;
using UnityEngine;

public class CharacterShopItem : MonoBehaviour
{
    public ShopItemData data;
    public TextMeshProUGUI lable;
    public GameObject selectButton;
    private bool isSlected = false;


    private void Start()
    {
        UpdateUI();
    }
    public void SetData(ShopItemData shopItemData, bool isSlected)
    {
        data = shopItemData;
        this.isSlected = isSlected;
        // DatabaseManager.SaveData(DatabaseManager.DatabaseKey.characterListData, data);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (data == null)
            return;
        var text = string.Empty;
        if (isSlected)
        {

            DatabaseManager.coinsGame -= data.price;
            data.price = 0;
            data.hasBought = true;
            selectButton.SetActive(false);
            text = "Selected";

        }
        else if (data.hasBought)
        {
            text = "Select";
            selectButton.SetActive(true);
        }
        else if (data.hasBought == false)
        {
            print("check else:" + text);
            text = data.price.ToString();
            Debug.Log("price: " + text);
            selectButton.SetActive(true);
        }
        lable.text = text;
    }

}
[Serializable]
public class ShopItemData
{
    public int price;
    public bool hasBought;
}