using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ListenerName : MonoBehaviour
{
    public TMP_InputField self;

    private void Start()
    {
        self.text = NameStore.Instance.PlayerName;
        self.onValueChanged.AddListener(delegate { SetName(); });
    }

    private void SetName()
    {
        NameStore.Instance.PlayerName = self.text.ToString();
    }
}
