using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public TextMeshProUGUI CoinsText;
    public TextMeshProUGUI CoinsViewText;
    public TextMeshProUGUI CharacterViewText;
    public GameObject CoinsView;
    public GameObject CharacterView;
    public static bool checkShop;
    void Start()
    {
        checkShop = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.CheckShop);
        Debug.Log(checkShop);
        if (checkShop)
        {
            ShowCoinsView();
        }
        if (checkShop == false)
        {
            ShowCharacterView();
        }
    }
    private void Update()
    {
        CoinsText.fontStyle = FontStyles.Bold;
        CoinsText.text = DatabaseManager.coinsGame.ToString();
    }
    public void ShowCoinsView()
    {
        CoinsViewText.fontStyle = FontStyles.Underline;
        CharacterViewText.fontStyle = FontStyles.Normal;
        CoinsView.SetActive(true);
        CharacterView.SetActive(false);
        checkShop = true;
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.CheckShop, checkShop);
    }
    public void ShowCharacterView()
    {
        CoinsViewText.fontStyle = FontStyles.Normal;
        CharacterViewText.fontStyle = FontStyles.Underline;
        CoinsView.SetActive(false);
        CharacterView.SetActive(true);
        checkShop = false; 
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.CheckShop, checkShop);

    }
}
