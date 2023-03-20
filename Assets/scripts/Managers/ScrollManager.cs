using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public Transform spawner;
    public List<GameObject> maps;
    public float timeBetween;
    private bool canSpawn = true;

    private void FixedUpdate()
    {
        if (canSpawn) {
            Instantiate(maps[Random.Range(0, maps.Count)], spawner.position, Quaternion.identity);
            StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(timeBetween);
        canSpawn = true;
    }
}
