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
        transform.rotation = Random.rotation;
        Destroy(gameObject, timeOnScreen);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction.position, speed * Time.deltaTime);
    }
}
