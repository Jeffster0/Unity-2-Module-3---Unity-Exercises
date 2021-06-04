using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieSpawnerScript : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform target;

    public float spawnRange = 10;

    public UnityEvent ZombieDied;

    void Start()
    {
        StartCoroutine(ZombieSpawnerRepeater());
    }

    public Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-spawnRange,spawnRange), 1, Random.Range(-spawnRange,spawnRange));
    }

    public void SpawnZombie()
    {
        // ADD CODE HERE
        GameObject zombie = Instantiate(zombiePrefab);
        zombie.transform.position = RandomPosition();
        zombiePrefab.GetComponent<ZombieScript>().Init(target, this);
        // END OF CODE
    }

    public IEnumerator ZombieSpawnerRepeater()
    {
        yield return new WaitForSeconds(Random.Range(4,20));
        SpawnZombie();
        StartCoroutine(ZombieSpawnerRepeater());
    }

    public void ZombieHasDied()
    {
        ZombieDied?.Invoke();
    }
}
