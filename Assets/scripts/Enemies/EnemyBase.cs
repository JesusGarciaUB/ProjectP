using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //routing
    public List<Transform> routing;
    public Transform spawn;
    public Transform end;
    private int currentTarget;
    public float speed;
    public float entrySpeed;

    public int GetState
    {
        get { return currentTarget; }
    }
    private void Start()
    {
        currentTarget = 0;
        transform.position = spawn.position;
    }
    private void FixedUpdate()
    {
        //movement
        if (currentTarget == 0) transform.position = Vector3.MoveTowards(transform.position, routing[currentTarget].position, entrySpeed * Time.deltaTime); 
        else if (currentTarget < routing.Count) transform.position = Vector3.MoveTowards(transform.position, routing[currentTarget].position, speed * Time.deltaTime);
        else transform.position = Vector3.MoveTowards(transform.position, end.position, speed * Time.deltaTime);

        //routing changer
        if (currentTarget < routing.Count)
        if (transform.position == routing[currentTarget].position) currentTarget++;
    }
}
