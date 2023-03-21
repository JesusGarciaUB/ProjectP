using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{
    Vector3 initialPosition;
    public float timeShake = 0;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeShake > 0)
        {
            timeShake -= Time.deltaTime;
            transform.position = initialPosition + Random.Range(-0.2f, 0.2f) * Vector3.right + Random.Range(-0.2f, 0.2f) * Vector3.up;
        }
        else
        {
            transform.position = initialPosition;
        }
    }
}
