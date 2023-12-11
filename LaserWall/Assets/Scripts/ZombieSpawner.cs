using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private Transform platformTransform;
    [SerializeField] private Transform[] spawners;
    [SerializeField] private float spawnDelay = 2.5f;

    private float countdown = 1f;

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnZombie();
        }

        countdown -= Time.deltaTime;
    }

    private void SpawnZombie()
    {
        countdown = spawnDelay;

        GameObject newZombie = Instantiate(zombie, spawners[UnityEngine.Random.Range(0, spawners.Length)]);
        newZombie.transform.parent = platformTransform;
    }
}
