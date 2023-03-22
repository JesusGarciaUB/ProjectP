using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public List<GameObject> clouds;
    public List<Transform> despawners;
    private bool canSpawn;
    public float ratio;

    private void Start()
    {
        canSpawn = true;
    }
    private void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnCloud());
            GameObject cloud = Instantiate(clouds[Random.Range(0, clouds.Count)], transform.position, Quaternion.identity);
            cloud.GetComponent<Cloud>().direction = despawners[Random.Range(0, despawners.Count)];
        }
    }

    private IEnumerator SpawnCloud()
    {
        canSpawn = false;
        yield return new WaitForSeconds(ratio);
        canSpawn = true;
    }
}
