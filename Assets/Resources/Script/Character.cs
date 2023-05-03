using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    int check;
    [SerializeField] GameObject SelectCharacterOne;
    [SerializeField] GameObject SelectedCharacterOne;
    [SerializeField] GameObject SelectCharacterTwo;
    [SerializeField] GameObject SelectedCharacterTwo;
    [SerializeField] GameObject SelectCharacterThree;
    [SerializeField] GameObject SelectedCharacterThree;
    [SerializeField] GameObject SelectCharacterFor;
    [SerializeField] GameObject SelectedCharacterFor;
    [SerializeField] GameObject SelectCharacterFive;
    [SerializeField] GameObject SelectedCharacterFive;
    [SerializeField] GameObject SelectCharacterSix;
    [SerializeField] GameObject SelectedCharacterSix;
    [SerializeField] GameObject SelectCharacterSeven;
    [SerializeField] GameObject SelectedCharacterSeven;
    void Start()
    {
        check = PlayerPrefs.GetInt("checkCharacter",1);
    }
    void Update()
    {
        if (check == 1)
        {
            SelectCharacterOne.SetActive(false);
            SelectedCharacterOne.SetActive(true);
            SelectCharacterTwo.SetActive(true);
            SelectedCharacterTwo.SetActive(false);
            SelectCharacterThree.SetActive(true);
            SelectedCharacterThree.SetActive(false);
            SelectCharacterFor.SetActive(true);
            SelectedCharacterFor.SetActive(false);
            SelectCharacterFive.SetActive(true);
            SelectedCharacterFive.SetActive(false);
            SelectCharacterSix.SetActive(true);
            SelectedCharacterSix.SetActive(false);
            SelectCharacterSeven.SetActive(true);
            SelectedCharacterSeven.SetActive(false);
        }
        if (check == 2)
        {
            SelectCharacterOne.SetActive(true);
            SelectedCharacterOne.SetActive(false);
            SelectCharacterTwo.SetActive(false);
            SelectedCharacterTwo.SetActive(true);
            SelectCharacterThree.SetActive(true);
            SelectedCharacterThree.SetActive(false);
            SelectCharacterFor.SetActive(true);
            SelectedCharacterFor.SetActive(false);
            SelectCharacterFive.SetActive(true);
            SelectedCharacterFive.SetActive(false);
            SelectCharacterSix.SetActive(true);
            SelectedCharacterSix.SetActive(false);
            SelectCharacterSeven.SetActive(true);
            SelectedCharacterSeven.SetActive(false);
        }
        if (check == 3)
        {
            SelectCharacterOne.SetActive(true);
            SelectedCharacterOne.SetActive(false);
            SelectCharacterTwo.SetActive(true);
            SelectedCharacterTwo.SetActive(false);
            SelectCharacterThree.SetActive(false);
            SelectedCharacterThree.SetActive(true);
            SelectCharacterFor.SetActive(true);
            SelectedCharacterFor.SetActive(false);
            SelectCharacterFive.SetActive(true);
            SelectedCharacterFive.SetActive(false);
            SelectCharacterSix.SetActive(true);
            SelectedCharacterSix.SetActive(false);
            SelectCharacterSeven.SetActive(true);
            SelectedCharacterSeven.SetActive(false);
        }
        if (check == 4)
        {
            SelectCharacterOne.SetActive(true);
            SelectedCharacterOne.SetActive(false);
            SelectCharacterTwo.SetActive(true);
            SelectedCharacterTwo.SetActive(false);
            SelectCharacterThree.SetActive(true);
            SelectedCharacterThree.SetActive(false);
            SelectCharacterFor.SetActive(false);
            SelectedCharacterFor.SetActive(true);
            SelectCharacterFive.SetActive(true);
            SelectedCharacterFive.SetActive(false);
            SelectCharacterSix.SetActive(true);
            SelectedCharacterSix.SetActive(false);
            SelectCharacterSeven.SetActive(true);
            SelectedCharacterSeven.SetActive(false);
        }
        if (check == 5)
        {
            SelectCharacterOne.SetActive(true);
            SelectedCharacterOne.SetActive(false);
            SelectCharacterTwo.SetActive(true);
            SelectedCharacterTwo.SetActive(false);
            SelectCharacterThree.SetActive(true);
            SelectedCharacterThree.SetActive(false);
            SelectCharacterFor.SetActive(true);
            SelectedCharacterFor.SetActive(false);
            SelectCharacterFive.SetActive(false);
            SelectedCharacterFive.SetActive(true);
            SelectCharacterSix.SetActive(true);
            SelectedCharacterSix.SetActive(false);
            SelectCharacterSeven.SetActive(true);
            SelectedCharacterSeven.SetActive(false);
        }
        if (check == 6)
        {
            SelectCharacterOne.SetActive(true);
            SelectedCharacterOne.SetActive(false);
            SelectCharacterTwo.SetActive(true);
            SelectedCharacterTwo.SetActive(false);
            SelectCharacterThree.SetActive(true);
            SelectedCharacterThree.SetActive(false);
            SelectCharacterFor.SetActive(true);
            SelectedCharacterFor.SetActive(false);
            SelectCharacterFive.SetActive(true);
            SelectedCharacterFive.SetActive(false);
            SelectCharacterSix.SetActive(false);
            SelectedCharacterSix.SetActive(true);
            SelectCharacterSeven.SetActive(true);
            SelectedCharacterSeven.SetActive(false);
        }
        if (check == 7)
        {
            SelectCharacterOne.SetActive(true);
            SelectedCharacterOne.SetActive(false);
            SelectCharacterTwo.SetActive(true);
            SelectedCharacterTwo.SetActive(false);
            SelectCharacterThree.SetActive(true);
            SelectedCharacterThree.SetActive(false);
            SelectCharacterFor.SetActive(true);
            SelectedCharacterFor.SetActive(false);
            SelectCharacterFive.SetActive(true);
            SelectedCharacterFive.SetActive(false);
            SelectCharacterSix.SetActive(true);
            SelectedCharacterSix.SetActive(false);
            SelectCharacterSeven.SetActive(false);
            SelectedCharacterSeven.SetActive(true);
        }
    }
    public void checkCharacter(int value)
    {
        check = value;
        PlayerPrefs.SetInt("checkCharacter",check);
        PlayerPrefs.Save();
    }
}
