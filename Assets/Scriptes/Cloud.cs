using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{

    public SpriteRenderer[] possibleCloudsToShow;
    public float randomSizeRange = 0.5f;

    void Start()
    {
        int randomIndex = Random.Range(0, possibleCloudsToShow.Length);
        possibleCloudsToShow[randomIndex].enabled = true;
        possibleCloudsToShow[randomIndex].gameObject.transform.localScale *= 1 - Random.Range(-randomSizeRange, randomSizeRange);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(gameObject);
    }
}
