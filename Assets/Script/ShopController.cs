using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Text CoinsText;
    public Text CoinsViewText;
    public Text CharacterViewText;
    public GameObject CoinsView;
    public GameObject CharacterView;
    SaveGame SaveGame;

    private bool checkBuy = false;

    private void Awake()
    {
        SaveGame = FindObjectOfType<SaveGame>();
    }
    void Start()
    {
        CoinsText.text = "Coins:" + SaveGame.coinsGame;
        if (SaveGame.checkShop == 1)
        {
            ShowCoinsView();
        }
        if (SaveGame.checkShop == 2)
        {
            ShowCharacterView();
        }
    }
    public void BuyCoins()
    {
        CoinsText.text = "Coins:" + SaveGame.coinsGame;
        SaveGame.BuyCoins();
        SaveGame.LoadCoins();
        checkBuy = true;
    }
    public void ShowCoinsView()
    {
        CoinsViewText.fontStyle = FontStyle.Bold;
        CharacterViewText.fontStyle = FontStyle.Normal;
        CoinsView.SetActive(true);
        CharacterView.SetActive(false);

    }
    public void ShowCharacterView()
    {
        CoinsViewText.fontStyle = FontStyle.Normal;
        CharacterViewText.fontStyle = FontStyle.Bold;
        CoinsView.SetActive(false);
        CharacterView.SetActive(true);
    }
}
