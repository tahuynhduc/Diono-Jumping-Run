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
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (data == null)
            return;
        var text = string.Empty;
        if (isSlected)
        {
            selectButton.SetActive(true);
            data.hasBought = true;
        }
        else if (data.hasBought)
        {
            selectButton.SetActive(false);
            text = "Select";
        }
        else
        {
            text = data.price.ToString();
            Debug.Log("test fuction:" + text);
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