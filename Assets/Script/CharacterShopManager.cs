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
    int selectedCharacter;

    [SerializeField] GameObject BuyCharacterPanel;
    [SerializeField] TextMeshProUGUI buyText;
    [SerializeField] ShopData shopData;
    [SerializeField] List<CharacterShopItem> shopItems;
    [SerializeField] String DefaultValue;

    UiStore uiStore;

    private void Awake()
    {
        LoadData();
    }

    private void LoadData()
    {
        uiStore = FindAnyObjectByType<UiStore>();
        shopData = DatabaseManager.LoadData<ShopData>(DatabaseManager.DatabaseKey.characterListData, DefaultValue);
    }

    private void OnEnable()
    {
        ShowShopItems();
    }
    private void Start() {
    }
    private void ShowShopItems()
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            if (shopData.shopItems[i].isSelected)
                selectedItem = shopData.shopItems[i];
            shopItems[i].SetData(shopData.shopItems[i], HandleShopItemClick);
        }
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.chooseCharacter, selectedCharacter);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.characterListData, shopData);
    }
    ShopItemData selectedItem;
    public void ChooseCharacter(int value)
    {
        selectedCharacter = value;
    }

    private void HandleShopItemClick(ShopItemData shopItemData)
    {
        if (shopItemData.hasBought)
        {
            SelectCharacter(shopItemData);
        }
        else if (DatabaseManager.coinsGame >= shopItemData.price)
        {
            ShowBuyPopup("Do you want buy character", () => BuyCharacter(shopItemData));
        }
        else if (DatabaseManager.coinsGame <= shopItemData.price)
        {
            ShowBuyPopup("Do you want buy coins", () => BuyCoin(shopItemData));
        }
    }

    private void SelectCharacter(ShopItemData shopItemData)
    {
        selectedItem.isSelected = false;
        shopItemData.isSelected = true;
        ShowShopItems();
    }

    private void BuyCharacter(ShopItemData shopItemData)
    {
        DatabaseManager.coinsGame -= shopItemData.price;
        shopItemData.hasBought = true;
        HideBuyCharacterPanel();
        SelectCharacter(shopItemData);
        ShowShopItems();
    }

    private void BuyCoin(ShopItemData shopItemData)
    {
        HideBuyCharacterPanel();
        uiStore.ShowCoinsView();
    }
    private Action _confirmAction;
    public void ShowBuyPopup(string message, Action confirmAction)
    {
        _confirmAction = confirmAction;
        buyText.text = message;
        BuyCharacterPanel.SetActive(true);
    }
    public void NoBtn() => HideBuyCharacterPanel();

    private void HideBuyCharacterPanel() => BuyCharacterPanel.SetActive(false);

    public void YesBtn()
    {
        _confirmAction?.Invoke();
        _confirmAction = null;
    }
}

[Serializable]
public class ShopData
{
    public List<ShopItemData> shopItems;

}