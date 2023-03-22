using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;
    public Transform direction;
    public float timeOnScreen;

    private void Start()
    {
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        Destroy(gameObject, timeOnScreen);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction.position, speed * Time.deltaTime);
    }
}
