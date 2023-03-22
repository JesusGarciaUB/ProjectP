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
    public SceneManagerScript sm;
    private void Start()
    {
        canSpawn = true;
        loops = 0;
        sm.middleText.text = "";
        StartCoroutine(Stage());
    }

    private IEnumerator Stage()
    {
        sm.middleText.text = "stage " + sm.sceneNum.ToString();
        yield return new WaitForSeconds(1.5f);
        sm.middleText.text = "";
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
                GlobalVariables.Instance.canShoot = false;
                GlobalVariables.Instance.player.GetComponent<PlayerBase>().anim.SetBool("isParking", true);
                StartCoroutine(changeTime());
            }
        }
    }

    private IEnumerator changeTime()
    {
        sm.middleText.text = "LEVEL COMPLETE";
        yield return new WaitForSeconds(2);
        if (sm.sceneNum == 2) {
            sm.middleText.text = "FINAL SCORE: " + GlobalVariables.Instance.Score;
            GlobalVariables.Instance.DoCredits();
        }
        else
        {
            yield return new WaitForSeconds(3);
            GlobalVariables.Instance.CurrentLevel++;
        }
    }

    private IEnumerator Spawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(timeBetween);
        canSpawn = true;
    }
}
