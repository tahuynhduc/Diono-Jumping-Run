using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{
    // Start is called before the first frame update
    public void CheckMap(int value )
    {
        SaveGame.checkmap = value;
    }
}
