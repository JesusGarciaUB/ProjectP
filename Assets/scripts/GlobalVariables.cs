using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables Instance { get; private set; }
    public GameObject player;
    private int score;
    public Camera mainCamera;
    public Color ogColor;
    private int currentLevel;
    public bool canScroll;
    //public TextMeshProUGUI tm;
    public SceneManagerScript sceneManager;
    public int playerHealth;

    public int CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            currentLevel = value;
            SceneManager.LoadScene(currentLevel);
            canScroll = true;
            sceneManager.canSpawnGlobal = true;
        }
    }

    public int SetLevel
    {
        set { currentLevel = value; }
    }
    public int Score
    {
        get { return score; }
        set
        {
            score += value;
            ChangeScore();
        }
    }

    public int ScoreReset
    {
        set { score = value; }
    }

    private void Awake()
    {
        canScroll = true;
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
