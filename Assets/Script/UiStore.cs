using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiStore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinsText;
    [SerializeField] TextMeshProUGUI CoinsViewText;
    [SerializeField] TextMeshProUGUI CharacterViewText;
    [SerializeField] GameObject CoinsView;
    [SerializeField] GameObject CharacterView;
    void Start()
    {
        CheckShowUi();
    }

    private void CheckShowUi()
    {
        if (SceneLoader.checkShop)
        {
            ShowCoinsView();
        }
        if (SceneLoader.checkShop == false)
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
    }
    public void ShowCharacterView()
    {
        CoinsViewText.fontStyle = FontStyles.Normal;
        CharacterViewText.fontStyle = FontStyles.Underline;
        CoinsView.SetActive(false);
        CharacterView.SetActive(true);
    }
}
