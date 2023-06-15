using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    int check;
    [SerializeField] TextMeshProUGUI SelectedCharacterOne;
    [SerializeField] GameObject SelectCharacterOne;

    [SerializeField] TextMeshProUGUI priceCharacterTwo;
    [SerializeField] GameObject SelectCharacterTwo;
    bool characterTwo;

    [SerializeField] TextMeshProUGUI priceCharacterThree;
    [SerializeField] GameObject SelectCharacterThree;
    bool characterThree;

    [SerializeField] TextMeshProUGUI priceCharacterFour;
    [SerializeField] GameObject SelectCharacterFour;
    bool characterFour;

    [SerializeField] TextMeshProUGUI priceCharacterFive;
    [SerializeField] GameObject SelectCharacterFive;
    bool characterFive;

    [SerializeField] TextMeshProUGUI priceCharacterSix;
    [SerializeField] GameObject SelectCharacterSix;
    bool characterSix;

    [SerializeField] TextMeshProUGUI priceCharacterSeven;
    [SerializeField] GameObject SelectCharacterSeven;
    bool characterSeven;

    [SerializeField] GameObject BuyCharacterPanel;
    int coinsGame;
    void Start()
    {
        check = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.chooseCharacter);
        characterTwo = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.CharacterTwo);
        characterThree = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.CharacterThree);
        characterFour = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.CharacterFour);
        characterFive = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.CharacterFive);
        characterSix = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.CharacterSix);
        characterSeven = DatabaseManager.LoadData<bool>(DatabaseManager.DatabaseKey.CharacterSeven);
        coinsGame = DatabaseManager.LoadData<int>(DatabaseManager.DatabaseKey.CoinsGame);
        chooseCharacter();
        BuyedCharacter();
    }
    private void BuyedCharacter()
    {
        if (characterTwo)
        {
            priceCharacterTwo.text = "Select";
        }
        if (characterThree)
        {
            priceCharacterThree.text = "Select";

        }
        if (characterFour)
        {
            priceCharacterFour.text = "Select";
        }
        if (characterFive)
        {
            priceCharacterFive.text = "Select";
        }
        if (characterSix)
        {
            priceCharacterSix.text = "Select";
        }
        if (characterSeven)
        {
            priceCharacterSeven.text = "Select";
        }
    }

    public void ShowCharacterPanel()
    {
        BuyCharacterPanel.SetActive(true);
    }
    public void YesBtn()
    {
        if (check == 1)
        {
            chooseCharacter();
        }
        if (check == 2)
        {
            if (characterTwo == false && coinsGame >= 2000)
            {
                coinsGame -= 2000;
                priceCharacterTwo.text = "Select";
                characterTwo = true;
            }
            if (characterTwo)
            {
                chooseCharacter();
            }
        }
        if (check == 3)
        {
            if (characterThree = false && coinsGame >= 3000)
            {
                coinsGame -= 3000;
                priceCharacterThree.text = "Select";
                characterThree = true;
            }
            if (characterThree)
            {
                chooseCharacter();
            }
        }
        if (check == 4)
        {
            if (characterFour = false && coinsGame >= 4000)
            {
                coinsGame -= 4000;
                priceCharacterFour.text = "Select";
                characterFour = true;
            }
            if (characterFour)
            {
                chooseCharacter();
            }
        }
        if (check == 5)
        {
            if (characterFive = false && coinsGame >= 5000)
            {
                coinsGame -= 5000;
                priceCharacterFive.text = "Select";
                characterFive = true;
            }
            if (characterFive)
            {
                chooseCharacter();
            }
        }
        if (check == 6)
        {
            if (characterSix = false && coinsGame >= 6000)
            {
                coinsGame -= 6000;
                priceCharacterSix.text = "Select";
                characterSix = true;
            }
            if (characterSix)
            {
                chooseCharacter();
            }
        }
        if (check == 7)
        {
            if (characterSeven = false && coinsGame >= 7000)
            {
                coinsGame -= 7000;
                priceCharacterSeven.text = "Select";
                characterSeven = true;
            }
            if (characterSeven)
            {
                chooseCharacter();
            }
        }
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.CoinsGame,coinsGame);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.CharacterTwo, characterTwo);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.CharacterThree, characterThree);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.CharacterFour, characterFour);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.CharacterFive, characterFive);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.CharacterSix, characterSix);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.CharacterSeven, characterSeven);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.chooseCharacter,check);
        BuyCharacterPanel.SetActive(false);
    }
    public void NoBtn()
    {
        BuyCharacterPanel.SetActive(false);
    }
    private void chooseCharacter()
    {
        if (check == 1)
        {
            SelectCharacterOne.SetActive(false);
            SelectCharacterTwo.SetActive(true);
            SelectCharacterThree.SetActive(true);
            SelectCharacterFour.SetActive(true);
            SelectCharacterFive.SetActive(true);
            SelectCharacterSix.SetActive(true);
            SelectCharacterSeven.SetActive(true);
        }
        if (check == 2)
        {
            SelectCharacterOne.SetActive(true);
            SelectCharacterTwo.SetActive(false);
            SelectCharacterThree.SetActive(true);
            SelectCharacterFour.SetActive(true);
            SelectCharacterFive.SetActive(true);
            SelectCharacterSix.SetActive(true);
            SelectCharacterSeven.SetActive(true);
        }
        if (check == 3)
        {
            SelectCharacterOne.SetActive(true);
            SelectCharacterTwo.SetActive(true);
            SelectCharacterThree.SetActive(false);
            SelectCharacterFour.SetActive(true);
            SelectCharacterFive.SetActive(true);
            SelectCharacterSix.SetActive(true);
            SelectCharacterSeven.SetActive(true);
        }
        if (check == 4)
        {
            SelectCharacterOne.SetActive(true);
            SelectCharacterTwo.SetActive(true);
            SelectCharacterThree.SetActive(true);
            SelectCharacterFour.SetActive(false);
            SelectCharacterFive.SetActive(true);
            SelectCharacterSix.SetActive(true);
            SelectCharacterSeven.SetActive(true);
        }
        if (check == 5)
        {
            SelectCharacterOne.SetActive(true);
            SelectCharacterTwo.SetActive(true);
            SelectCharacterThree.SetActive(true);
            SelectCharacterFour.SetActive(true);
            SelectCharacterFive.SetActive(false);
            SelectCharacterSix.SetActive(true);
            SelectCharacterSeven.SetActive(true);

        }
        if (check == 6)
        {
            SelectCharacterOne.SetActive(true);
            SelectCharacterTwo.SetActive(true);
            SelectCharacterThree.SetActive(true);
            SelectCharacterFour.SetActive(true);
            SelectCharacterFive.SetActive(true);
            SelectCharacterSix.SetActive(false);
            SelectCharacterSeven.SetActive(true);
        }
        if (check == 7)
        {
            SelectCharacterOne.SetActive(true);
            SelectCharacterTwo.SetActive(true);
            SelectCharacterThree.SetActive(true);
            SelectCharacterFour.SetActive(true);
            SelectCharacterFive.SetActive(true);
            SelectCharacterSix.SetActive(true);
            SelectCharacterSeven.SetActive(false);
        }
    }
    public void checkCharacter(int value)
    {
        check = value;
    }
}
