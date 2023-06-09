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
    


    private void Awake()
    {
        
    }
    void Start()
    {
        int checkShop = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.CheckShop);
        int checkCharacter = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.CheckCharacter);
        if (checkShop == 1)
        {
            ShowCoinsView();
        }
        if (checkCharacter == 1)
        {
            ShowCharacterView();
        }
    }
    private void Update()
    {
        CoinsText.fontStyle = FontStyles.Bold;
        CoinsText.text = SaveGame.coinsGame.ToString();
    }
    public void ShowCoinsView()
    {
        CoinsViewText.fontStyle = FontStyles.Underline;
        CharacterViewText.fontStyle = FontStyles.Normal;
        CoinsView.SetActive(true);
        CharacterView.SetActive(false);

    }
    public void ShowCharacterView()
    {
        CoinsViewText.fontStyle = FontStyles.Normal;
        CharacterViewText.fontStyle = FontStyles.Underline;
        CoinsView.SetActive(false);
        CharacterView.SetActive(true);
    }
    public void BuyCoins()
    {
        SaveGame.SaveCoins(1000);
    }
}
