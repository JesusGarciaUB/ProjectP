using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables Instance { get; private set; }
    public GameObject player;
    private int score;
    public Camera mainCamera;
    public Color ogColor;
    public int currentLevel;
    public bool canScroll;
    public TextMesh tm;

    public int Score
    {
        get { return score; }
        set
        {
            score += value;
        }
    }

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
