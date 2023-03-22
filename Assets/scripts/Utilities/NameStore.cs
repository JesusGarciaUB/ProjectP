using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameStore : MonoBehaviour
{
    public static NameStore Instance { get; private set; }
    private string playerName;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            playerName = "Player 1";
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);
    }

    public string PlayerName
    {
        get { return playerName; }
        set 
        { 
            if (value.ToString() != "") playerName = value;
            print(PlayerName);
        }
    }
}
