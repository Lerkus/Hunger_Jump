using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject Camera;
    public GameObject cloudFast;
    public float cloudSpawnCycleTime = 0.5f;
    public GameObject cloudSlow;
    public float fallingObjectsSpawnCycleTime = 0.5f;
    public bool shouldSpawnObjects = true;

	public float AdditionHorizontalSpawnratio = 5f;

    public GameObject masterParent;

    Vector2 spawnRangeLeftPoint;
    Vector2 spawnRangeRightPoint;

    public GameObject[] fallingObjectsPrefabs;
    public GameObject finishLinePrefab;

    private Coroutine cloudSpawnRoutine;
    private Coroutine fallingObjectsRoutine;

    public void Start()
    {
        RecalculateSpawnPosition();
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
        if (shouldSpawnObjects)
        {
            GameObject spawned = (GameObject)Instantiate(prefabToSpawn, Vector2.Lerp(spawnRangeLeftPoint, spawnRangeRightPoint, Random.Range(0f, 1f)), new Quaternion());
            spawned.transform.parent = masterParent.transform;
        }
    }

    public Bounds OrthographicBounds()
    {
        Camera camera = Camera.GetComponent<Camera>();
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }

    public void RecalculateSpawnPosition()
    {
		spawnRangeLeftPoint = new Vector2(OrthographicBounds().min.x - AdditionHorizontalSpawnratio, OrthographicBounds().min.y-5f);
		spawnRangeRightPoint = new Vector2(OrthographicBounds().max.x + AdditionHorizontalSpawnratio, OrthographicBounds().min.y-5f);
    }

    public void spawnFinishLine()
    {
        Instantiate(finishLinePrefab, Vector2.Lerp(spawnRangeLeftPoint, spawnRangeRightPoint, 0.5f), new Quaternion());
    }
}
