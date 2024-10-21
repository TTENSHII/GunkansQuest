using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHelper : MonoBehaviour
{
    public int GetGold()
    {
        return  PlayerPrefs.GetInt("Gold", 0);
    }
}
