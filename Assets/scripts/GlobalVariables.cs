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
    private void Awake()
    {
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
