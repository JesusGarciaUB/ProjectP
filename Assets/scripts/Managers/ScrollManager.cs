using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public Transform spawner;
    public List<GameObject> maps;
    public float timeBetween;
    private bool canSpawn;
    public GameObject portmap;
    private int loops;
    public int numberOfLoops;
    private void Start()
    {
        canSpawn = true;
        loops = 0;
    }
    private void Update()
    {
        if (GlobalVariables.Instance.canScroll)
        {
            if (canSpawn && loops < numberOfLoops)
            {
                loops++;
                Instantiate(maps[Random.Range(0, maps.Count)], spawner.position, Quaternion.identity);
                StartCoroutine(Spawn());
            }
            if (canSpawn && loops == numberOfLoops)
            {
                loops++;
                Instantiate(portmap, spawner.position, Quaternion.identity);
                StartCoroutine(Spawn());
            }
            if (canSpawn && loops < (numberOfLoops + 2)) {
                loops++;
                Instantiate(maps[Random.Range(0, maps.Count)], spawner.position, Quaternion.identity);
                StartCoroutine(Spawn());
            }
            if (loops == numberOfLoops + 2) GlobalVariables.Instance.sceneManager.canSpawnGlobal = false;
            if (canSpawn && loops == (numberOfLoops + 2))
            {
                GlobalVariables.Instance.canScroll = false;
                StartCoroutine(changeTime());
            }
        }
    }

    private IEnumerator changeTime()
    {
        yield return new WaitForSeconds(2);
        GlobalVariables.Instance.CurrentLevel++;
    }

    private IEnumerator Spawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(timeBetween);
        canSpawn = true;
    }
}
