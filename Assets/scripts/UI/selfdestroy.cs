using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class selfdestroy : MonoBehaviour
{
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(die());
    }

    private IEnumerator die()
    {
        yield return new WaitForSeconds(3);
        text.text = "";
    }

}
