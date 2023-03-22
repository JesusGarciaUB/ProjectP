using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    public List<Transform> leftPath;
    public List<Transform> rightPath;
    public List<Transform> centerSpawners;
    public List<Transform> despawners;
    public Transform leftSpawner;
    public Transform rightSpawner;
    public List<GameObject> enemies;
    private bool canSpawn;
    public float speedOfSpawn;
    public bool canSpawnGlobal;
    public int sceneNum;
    public TextMeshProUGUI scoreboard;
    public TextMeshProUGUI middleText;
    public TextMeshProUGUI textHealth;
    private void Start()
    {
        GlobalVariables.Instance.SetLevel = sceneNum;
        GlobalVariables.Instance.player = GameObject.FindGameObjectWithTag("Player");
        GlobalVariables.Instance.mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        GlobalVariables.Instance.sceneManager = gameObject.GetComponent<SceneManagerScript>();
        canSpawnGlobal = true;
        canSpawn = true;
        GlobalVariables.Instance.canShoot = true;
        if (sceneNum == 1) { 
            GlobalVariables.Instance.ScoreReset = 0;
            GlobalVariables.Instance.playerHealth = 8;
        }
        GlobalVariables.Instance.player.GetComponent<Damageable>().HealthEqualizer = GlobalVariables.Instance.playerHealth;
        GlobalVariables.Instance.tm = scoreboard;
        if (sceneNum > 1) GlobalVariables.Instance.ScoreReset = GlobalVariables.Instance.Score;
        GlobalVariables.Instance.player.GetComponent<PlayerBase>().anim.SetBool("isParking", false);
        textHealth.text = "x" + GlobalVariables.Instance.playerHealth.ToString();
    }

    private void FixedUpdate()
    {
        if (canSpawnGlobal)
        {
            if (canSpawn && GlobalVariables.Instance.canScroll)
            {
                switch (Random.Range(0, 5))
                {
                    case 0:
                        SpawnFrag();
                        break;
                    case 1:
                        SpawnMine();
                        break;
                    default:
                        SpawnGol();
                        break;
                }
                StartCoroutine(StartCooldown());
            }
        }
    }

    private void SpawnMine()
    {
        int rand = Random.Range(0, 2);
        int side = Random.Range(0, 2);
        GameObject mine = Instantiate(enemies[2], rand == 0 ? centerSpawners[Random.Range(0, centerSpawners.Count)].position : side == 0 ? rightSpawner.position : leftSpawner.position, Quaternion.identity);
        if (rand == 0) mine.GetComponent<EnemyBase>().SetOnePoint = despawners[Random.Range(0, despawners.Count)];
        else
        {
            mine.GetComponent<EnemyBase>().SetRoute = side == 0 ? rightPath : leftPath;
        }
    }

    private void SpawnGol()
    {
        GameObject gol = Instantiate(enemies[1], centerSpawners[Random.Range(0, centerSpawners.Count)].position, Quaternion.identity);
        gol.GetComponent<EnemyBase>().SetOnePoint = despawners[Random.Range(0, despawners.Count)];
    }
    
    private void SpawnFrag()
    {
        int side = Random.Range(0, 2);
        GameObject frag = Instantiate(enemies[0], side == 0 ? rightSpawner.position : leftSpawner.position, Quaternion.identity);
        frag.GetComponent<EnemyBase>().SetRoute = side == 0 ? rightPath : leftPath;
    }

    private IEnumerator StartCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(speedOfSpawn);
        canSpawn = true;
    }
}
