using System;
using System.Linq;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private Transform[] spawners;
    [SerializeField] private float spawnTime = 2.5f;

    private float countdown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        countdown = spawnTime;
    }

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
        countdown = spawnTime;

        GameObject newZombie = Instantiate(zombie, spawners[UnityEngine.Random.Range(0, spawners.Length)]);
    }
}
