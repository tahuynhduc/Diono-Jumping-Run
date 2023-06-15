using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterShopManager : MonoBehaviour
{
    int checkIndex;
    [SerializeField] GameObject BuyCharacterPanel;
    [SerializeField] GameObject CannotBuyPannel;
    [SerializeField] ShopData shopData;
    [SerializeField] List<CharacterShopItem> shopItems;
    private void Start()
    {
        shopData = DatabaseManager.LoadData<ShopData>(DatabaseManager.DatabaseKey.characterListData);
        checkIndex = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.chooseCharacter);
        Debug.Log("checkIndex:" + checkIndex);
        DatabaseManager.coinsGame = 7000;
        ShowShopItems();
    }
    private void ShowShopItems()
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            var isSelected = checkIndex == i;
            var data = shopData.shopItems[i];
            shopItems[i].SetData(shopData.shopItems[i], isSelected);
            Debug.Log("Data:" + shopData.shopItems[i]);
        }
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.chooseCharacter, checkIndex);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.characterListData,shopData);
    }

    public void ChooseCharacter(int value)
    {
        checkIndex = value;
        //ShowBuyPopup();

        ShowShopItems();
    }
    public void ShowBuyPopup()
    {
        BuyCharacterPanel.SetActive(true);
    }
    public void NoBtn()
    {
        BuyCharacterPanel.SetActive(false);
        CannotBuyPannel.SetActive(false);
    }
    public void YesBtn()
    {
        NoBtn();
    }

}

[Serializable]
public class ShopData{
    public List<ShopItemData> shopItems;

}