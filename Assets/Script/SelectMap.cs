using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    int checkmap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Forest()
    {
        checkmap = 1;
        PlayerPrefs.SetInt("checkmap", checkmap);
        PlayerPrefs.Save();
    }
    public void Desert()
    {
        checkmap = 2;
        PlayerPrefs.SetInt("checkmap", checkmap);
        PlayerPrefs.Save();
    }
    public void Graveyard()
    {
        checkmap = 3;
        PlayerPrefs.SetInt("checkmap", checkmap);
        PlayerPrefs.Save();
    }
    public void Snow()
    {
        checkmap = 4;
        PlayerPrefs.SetInt("checkmap", checkmap);
        PlayerPrefs.Save();
    }

}
