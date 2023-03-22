using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Socre : MonoBehaviour
{

    public GameObject text;

    [System.Serializable]
    public class SavePlayerData
    {
        public string playerName;
        public int playerScore;
    }

    private void Start()
    {
        var playerData = JsonUtility.FromJson<SavePlayerData>(PlayerPrefs.GetString("Scores"));
        Debug.Log("Name: " + playerData.playerName);
        Debug.Log("Score: " + playerData.playerScore);
        SetText(playerData.playerName, playerData.playerScore);
    }

    private void SetText(string name, int score)
    {
        GameObject textInstant = Instantiate(text);
        textInstant.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = name;
        textInstant.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
