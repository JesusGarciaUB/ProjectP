using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //routing
    public List<Transform> routing;
    private int currentTarget;
    public float speed;

    public List<Transform> SetRoute
    {
        set { routing = value; }
    }

    public Transform SetOnePoint
    {
        set { routing.Add(value); }
    }
    public int GetState
    {
        get { return currentTarget; }
    }
    private void Start()
    {
        currentTarget = 0;
    }
    private void FixedUpdate()
    {
        //movement
        if (currentTarget < routing.Count) transform.position = Vector3.MoveTowards(transform.position, routing[currentTarget].position, speed * Time.deltaTime);
        else Destroy(gameObject);

        //routing changer
        if (currentTarget < routing.Count)
        if (transform.position == routing[currentTarget].position) currentTarget++;
    }
}
