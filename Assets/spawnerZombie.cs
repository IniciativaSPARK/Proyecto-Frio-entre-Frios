using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
public class spawnerZombie : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenSpawns = 5f;
    [SerializeField] private Zombies zombiesPrefab;
    private IObjectPool<Zombies> zombiesPool;
    private float timeSinceLastSpawn;

    private void Awake()
    {
        zombiesPool = new ObjectPool<Zombies>(CreateZombies, OnGet, OnRelease);

    }
    public void OnGet(Zombies zombies)
    {
        zombies.gameObject.SetActive(true);
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        zombies.transform.position = randomSpawnPoint.position;
    }
    public void OnRelease (Zombies zombies)
    {
        zombies.gameObject.SetActive(false);
    }

    private Zombies CreateZombies()
    {
        Zombies zombies = Instantiate(zombiesPrefab);
        zombies.SetPool(zombiesPool);
        return zombies;
    }
    void Update()
    {
        if(Time.time>timeSinceLastSpawn)
        {
            zombiesPool.Get();
            timeSinceLastSpawn = Time.time + timeBetweenSpawns;
        }
    }
}
