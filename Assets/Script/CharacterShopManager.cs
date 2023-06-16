using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterShopManager : MonoBehaviour
{
    int checkIndex;

    [SerializeField] GameObject BuyCharacterPanel;
    [SerializeField] GameObject CannotBuyPannel;
    [SerializeField] TextMeshProUGUI buyText;
    [SerializeField] ShopData shopData;
    [SerializeField] List<CharacterShopItem> shopItems;
    [SerializeField] String DefaultValue;
    private void Start()
    {
        shopData = DatabaseManager.LoadData<ShopData>(DatabaseManager.DatabaseKey.characterListData, DefaultValue);
        checkIndex = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.chooseCharacter);
        ShowShopItems();
    }
    private void ShowShopItems()
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            if (DatabaseManager.coinsGame >= shopData.shopItems[i].price)
            {
                var isSelected = checkIndex == i;
                shopItems[i].SetData(shopData.shopItems[i], isSelected);
                if (isSelected)
                {
                    DatabaseManager.SaveData(DatabaseManager.DatabaseKey.chooseCharacter, i);
                    DatabaseManager.SaveData(DatabaseManager.DatabaseKey.characterListData, shopData);
                }
            }
        }
    }

    public void ChooseCharacter(int value)
    {
        checkIndex = value;
        for (int i = 0; i < shopItems.Count; i++)
        {
            var isSelected = checkIndex == i;
            if (shopData.shopItems[i].price == 0 && isSelected)
            {
                buyText.text = "Do you want select character";
            }
            else if (DatabaseManager.coinsGame >= shopData.shopItems[i].price && shopData.shopItems[i].price != 0 && isSelected)
            {
                buyText.text = "Do you want Buy character";
            }
            else if (DatabaseManager.coinsGame < shopData.shopItems[i].price && isSelected)
            {
                buyText.text = "Do you want buy more coins";
                ShopController.checkShop = true;
                DatabaseManager.SaveData(DatabaseManager.DatabaseKey.CheckShop,ShopController.checkShop);
            }
            ShowBuyPopup();
        }
    }
    public void ShowBuyPopup()
    {
        BuyCharacterPanel.SetActive(true);
    }
    public void NoBtn()
    {
        BuyCharacterPanel.SetActive(false);
    }
    public void YesBtn()
    {
        NoBtn();
        ShowShopItems();
        if (ShopController.checkShop)
            SceneManager.LoadScene("StoreScene");
    }
}

[Serializable]
public class ShopData
{
    public List<ShopItemData> shopItems;

}