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
    SaveGame SaveGame;


    private void Awake()
    {
        SaveGame = FindObjectOfType<SaveGame>();
    }
    void Start()
    {
        SaveGame.LoadCoins();
        if (SaveGame.checkShop == 1)
        {
            ShowCoinsView();
        }
        if (SaveGame.checkShop == 2)
        {
            ShowCharacterView();
        }
    }
    private void Update()
    {
        CoinsText.fontStyle = FontStyles.Bold;
        CoinsText.text = SaveGame.coinsGame.ToString();
    }
    public void BuyCoins(int value)
    {
        SaveGame.BuyCoins(value);
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
}
