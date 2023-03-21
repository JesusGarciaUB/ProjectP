using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables Instance { get; private set; }
    public GameObject player;
    public int score;
    public Camera mainCamera;
    public Color ogColor;
    public int currentLevel;
    public bool canScroll;
    private void Awake()
    {
        currentLevel = 0;
        score = 0;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
