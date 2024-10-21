using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText = null;

    private void Start()
    {
        float gold = PlayerPrefs.GetInt("Gold", 0);
        scoreText.text = gold.ToString();
    }
}
