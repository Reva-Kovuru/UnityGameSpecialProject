using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject prefab;
    private float spawnCounter;

    public float cooldownTime = 5f; // Time in seconds between spawns
    public float duration = 3f; // Duration for which the prefab will be active
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = 5f; // Set the spawn interval to 0.5 seconds
            Instantiate(prefab, transform.position, Quaternion.identity,transform);
    }
}
}
