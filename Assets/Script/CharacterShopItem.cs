using System;
using TMPro;
using UnityEngine;

public class CharacterShopItem : MonoBehaviour
{
    public ShopItemData data;
    public TextMeshProUGUI lable;
    public GameObject selectButton;
    private Action<ShopItemData> _onClickCallback;
    private void Start()
    {
        UpdateUI();
    }
    public void SetData(ShopItemData shopItemData, Action<ShopItemData> callback)
    {
        Debug.Log("Set Data function is running...");
        data = shopItemData;
        _onClickCallback = callback;
        UpdateUI();
    }

    private void UpdateUI()
    {
        Debug.Log("Update UI function is running...");
        if (data == null)
            return;
        var text = string.Empty;
        if (data.isSelected)
        {
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
            text = data.price.ToString();
        }
        lable.text = text;
    }
    public void OnClickButton()
    {
        _onClickCallback?.Invoke(data);
    }

}
[Serializable]
public class ShopItemData
{
    public int price;
    public bool hasBought;
    public bool isSelected;
}