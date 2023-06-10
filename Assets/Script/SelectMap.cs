using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    // Start is called before the first frame update
    public void Forest()
    {
        SaveGame.checkmap = 1;
        SaveGame.SaveMap();
    }
    public void Desert()
    {
        SaveGame.checkmap = 2;
        SaveGame.SaveMap();
    }
    public void City()
    {
        SaveGame.checkmap = 3;
        SaveGame.SaveMap();
    }
    public void Mars()
    {
        SaveGame.checkmap = 4;
        SaveGame.SaveMap();
    }
    public void Snow()
    {
        SaveGame.checkmap = 5;
        SaveGame.SaveMap();
    }
}
