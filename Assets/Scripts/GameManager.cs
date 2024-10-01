using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;

    private int coins = 0;
    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin()
    {
        coins++;
    }

    public int GetCoins()
    {
        return coins;
    }

    public void RemoveLife()
    {
        lives--;
    }

    public void AddLife()
    {
        lives++;
    }
}
