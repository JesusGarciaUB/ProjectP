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
    //public TextMeshProUGUI tm;
    public SceneManagerScript sceneManager;

    public int Score
    {
        get { return score; }
        set
        {
            score += value;
            ChangeScore();
        }
    }

    private void Awake()
    {
        canScroll = true;
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

    public void ChangeScore()
    {
        //tm.text = score.ToString();
    }
}
