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
    [SerializeField] List<ShopItemData> shopItemDatas;
    [SerializeField] List<CharacterShopItem> shopItems;
    private void Start()
    {
        checkIndex = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.chooseCharacter);
        DatabaseManager.coinsGame = 7000;
        ShowShopItems();
    }

    private void ShowShopItems()
    {
        for(int i = 0; i < shopItems.Count; i++)
        {
            var isSelected = checkIndex == i;
            var data = shopItemDatas[i];
            shopItems[i].SetData(data, isSelected);
            DatabaseManager.SaveData(DatabaseManager.DatabaseKey.chooseCharacter,checkIndex);
        }
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
