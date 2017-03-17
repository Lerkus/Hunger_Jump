using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject cloudFast;
    public float cloudSpawnCycleTime = 0.1f;
    public GameObject cloudSlow;
    public float fallingObjectsSpawnCycleTime = 0.1f;

    public GameObject masterParent;

    public Vector2 spawnRangeLeftPoint = new Vector2();
    public Vector2 spawnRangeRightPoint = new Vector2();

    public GameObject[] fallingObjectsPrefabs;

    private Coroutine cloudSpawnRoutine;
    private Coroutine fallingObjectsRoutine;

    public void Start()
    {
        cloudSpawnRoutine = StartCoroutine(spawnClouds());
        fallingObjectsRoutine = StartCoroutine(spawnFallingObjects());
    }

    public IEnumerator spawnClouds()
    {
        while (true)
        {
            yield return new WaitForSeconds(cloudSpawnCycleTime);
            spawnObject(cloudFast);
            spawnObject(cloudSlow);
        }
    }

    public IEnumerator spawnFallingObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(fallingObjectsSpawnCycleTime);
            spawnObject(fallingObjectsPrefabs[Random.Range(0, fallingObjectsPrefabs.Length)]);
        }
    }

    private void spawnObject(GameObject prefabToSpawn)
    {
        GameObject spawned = (GameObject) Instantiate(prefabToSpawn, Vector2.Lerp(spawnRangeLeftPoint, spawnRangeRightPoint, Random.Range(0f,1f)) , new Quaternion());
        spawned.transform.parent = masterParent.transform;
    }
}
