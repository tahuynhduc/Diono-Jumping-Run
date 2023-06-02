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
    SaveGame saveGame;
    [SerializeField] TextMeshProUGUI SelectedCharacterOne;
    [SerializeField] GameObject SelectCharacterOne;

    [SerializeField] TextMeshProUGUI priceCharacterTwo;
    [SerializeField] GameObject SelectCharacterTwo;
    int characterTwo;

    [SerializeField] TextMeshProUGUI priceCharacterThree;
    [SerializeField] GameObject SelectCharacterThree;
    int characterThree;

    [SerializeField] TextMeshProUGUI priceCharacterFour;
    [SerializeField] GameObject SelectCharacterFour;
    int characterFour;

    [SerializeField] TextMeshProUGUI priceCharacterFive;
    [SerializeField] GameObject SelectCharacterFive;
    int characterFive;

    [SerializeField] TextMeshProUGUI priceCharacterSix;
    [SerializeField] GameObject SelectCharacterSix;
    int characterSix;

    [SerializeField] TextMeshProUGUI priceCharacterSeven;
    [SerializeField] GameObject SelectCharacterSeven;
    int characterSeven;

    [SerializeField] GameObject BuyCharacterPanel;
    void Start()
    {
        check = PlayerPrefs.GetInt("checkCharacter", 1);
        characterTwo = PlayerPrefs.GetInt("characterTwo", 0);
        characterThree = PlayerPrefs.GetInt("characterThree", 0);
        characterFour = PlayerPrefs.GetInt("characterFour", 0);
        characterFive = PlayerPrefs.GetInt("characterFive", 0);
        characterSix = PlayerPrefs.GetInt("characterSix", 0);
        characterSeven = PlayerPrefs.GetInt("characterSeven", 0);
        chooseCharacter();
        if (characterTwo >= 2 )
        {
            priceCharacterTwo.text = "Select";
        }
        if (characterTwo == 0)
        {
            priceCharacterTwo.text = "1000";
        }
        if (characterThree >= 3)
        {
            priceCharacterThree.text = "Select";
        }
        if (characterThree == 0)
        {
            priceCharacterThree.text = "2000";
        }
        if (characterFour >= 4)
        {
            priceCharacterFour.text = "Select";
        }
        if (characterFour == 0)
        {
            priceCharacterFour.text = "3000";
        }
        if (characterFive >= 5)
        {
            priceCharacterFive.text = "Select";
        }
        if (characterFive == 0)
        {
            priceCharacterFive.text = "4000";
        }
        if (characterSix >= 6)
        {
            priceCharacterSix.text = "Select";
        }
        if (characterSix == 0)
        {
            priceCharacterSix.text = "5000";
        }
        if (characterSeven >= 7)
        {
            priceCharacterSeven.text = "Select";
        }
        if (characterSeven == 0)
        {
            priceCharacterSeven.text = "6000";
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
            PlayerPrefs.SetInt("checkCharacter", check);
            chooseCharacter();
        }
        if (check == 2)
        {
            if (characterTwo == check && priceCharacterTwo.text == "1000" && SaveGame.coinsGame >= 1000)
            {
                SaveGame.coinsGame -= 1000;
                chooseCharacter();
                priceCharacterTwo.text = "Select";
                PlayerPrefs.SetInt("characterTwo", characterTwo);
                PlayerPrefs.SetInt("checkCharacter", check);
            }
            if (characterSeven == check && priceCharacterTwo.text == "Select")
            {
                chooseCharacter();
                PlayerPrefs.SetInt("characterTwo", characterTwo);
                PlayerPrefs.SetInt("checkCharacter", check);
            }
        }
        if (check == 3)
        {
            if (characterThree == check && priceCharacterThree.text == "2000" && SaveGame.coinsGame >= 2000)
            {
                SaveGame.coinsGame -= 2000;
                chooseCharacter();
                priceCharacterThree.text = "Select";
                PlayerPrefs.SetInt("checkCharacter", check);
                PlayerPrefs.SetInt("characterThree", characterThree);
            }
            if (characterSeven == check && priceCharacterThree.text == "Select")
            {
                PlayerPrefs.SetInt("checkCharacter", check);
                PlayerPrefs.SetInt("characterThree", characterThree);
                chooseCharacter();
            }
        }
        if (check == 4)
        {
            if (characterFour == check && priceCharacterFour.text == "3000" && SaveGame.coinsGame >= 3000)
            {
                SaveGame.coinsGame -= 3000;
                chooseCharacter();
                priceCharacterFour.text = "Select";
                PlayerPrefs.SetInt("checkCharacter", check);
                PlayerPrefs.SetInt("characterFour", characterFour);
                PlayerPrefs.Save();
            }
            if (characterSeven == check && priceCharacterFour.text == "Select")
            {
                PlayerPrefs.SetInt("checkCharacter", check);
                PlayerPrefs.SetInt("characterFour", characterFour);
                chooseCharacter();
            }
        }
        if (check == 5)
        {
            if (characterFive == check && priceCharacterFive.text == "4000" && SaveGame.coinsGame >= 4000)
            {
                SaveGame.coinsGame -= 4000;
                chooseCharacter();
                priceCharacterFive.text = "Select";
                PlayerPrefs.SetInt("checkCharacter", check);
                PlayerPrefs.SetInt("characterFive", characterFive);
                PlayerPrefs.Save();
            }
            if (characterSeven == check && priceCharacterFive.text == "Select")
            {
                PlayerPrefs.SetInt("checkCharacter", check);
                PlayerPrefs.SetInt("characterFive", characterFive);
                chooseCharacter();
            }
        }
        if (check == 6)
        {
            if (characterSix == check && priceCharacterSix.text == "5000" && SaveGame.coinsGame >= 5000)
            {
                SaveGame.coinsGame -= 5000;
                chooseCharacter();
                priceCharacterSix.text = "Select";
                PlayerPrefs.SetInt("checkCharacter", check);
                PlayerPrefs.SetInt("characterSix", characterSix);
                PlayerPrefs.Save();
            }
            if (characterSeven == check && priceCharacterSix.text == "Select")
            {
                PlayerPrefs.SetInt("checkCharacter", check);
                PlayerPrefs.SetInt("characterSix", characterSix);
                chooseCharacter();
            }
        }
        if (check == 7)
        {
            if (characterSeven == check && priceCharacterSeven.text == "6000" && SaveGame.coinsGame >= 6000)
            {
                SaveGame.coinsGame -= 6000;
                chooseCharacter();
                priceCharacterSeven.text = "Select";
                PlayerPrefs.SetInt("checkCharacter", check);
                PlayerPrefs.SetInt("characterSeven", characterSeven);
                PlayerPrefs.Save();
            }
            if (characterSeven == check && priceCharacterSeven.text == "Select")
            {
                PlayerPrefs.SetInt("checkCharacter", check);
                PlayerPrefs.SetInt("characterSeven", characterSeven);
                chooseCharacter();
            }
        }
        BuyCharacterPanel.SetActive(false);
        PlayerPrefs.Save();
    }
    public void NoBtn()
    {
        BuyCharacterPanel.SetActive(false);
    }
    private void chooseCharacter()
    {
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
    }
    public void checkCharacter(int value)
    {
        check = value;
        characterTwo = value;
        characterThree = value;
        characterFour = value;
        characterFive = value;
        characterSix = value;
        characterSeven = value;
    }
}
