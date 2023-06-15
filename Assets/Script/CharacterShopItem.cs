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
            if (DatabaseManager.coinsGame >= data.price)
            {
                DatabaseManager.coinsGame -= data.price;
                data.price = 0;
                selectButton.SetActive(false);
                data.hasBought = true;
                text = "Selected";
            }

        }
        else if (data.hasBought)
        {
            selectButton.SetActive(true);
            text = "Select";
        }
        else
        {
            text = data.price.ToString();
            Debug.Log("price: " + text);
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