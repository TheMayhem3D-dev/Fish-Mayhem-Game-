using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [Header("General")]
    [SerializeField] private GameObject[] spawnObject = null;
    [SerializeField] private float spawnTime = 1f;
    [Space]
    [SerializeField] private int spawnCount = 0;
    [SerializeField] private bool randomPositionSpawn = true;
    [SerializeField] private bool randomObjectSpawn = true;

    [Header("Positions")]
    [SerializeField] private Transform[] spawnPositions = new Transform[0];

    [Header("Other")]
    [SerializeField] private bool randomChance = false;
    [SerializeField] private int chance = 0;
    private int curentChance = 100;

    public int SpawnCount { set { spawnCount = value; } }

    // Start is called before the first frame update
    void Start()
    {
        if (spawnCount > 0)
        {
            spawnCount--;
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnTime);

        if (randomChance)
        {
            curentChance = Random.Range(0, 100);
            if (curentChance <= chance)
            {
                ObjectForSpawn();
            }
        }
        else
        {
            ObjectForSpawn();
        }

        if (spawnCount > 0)
        {
            spawnCount--;
            StartCoroutine(Spawn());
        }
    }

    void ObjectForSpawn()
    {
        if (randomObjectSpawn)
        {
            int i = Random.Range(0, spawnObject.Length);
            PositionForSpawn(i);
        }
        else
        {
            PositionForSpawn(0);
        }
    }

    void PositionForSpawn(int value)
    {
        if (randomPositionSpawn)
        {
            int i = Random.Range(0, spawnPositions.Length);
            Instantiate(spawnObject[value], spawnPositions[i].position, spawnPositions[i].rotation);
        }
        else
        {
            Instantiate(spawnObject[value], transform.position, transform.rotation);
        }
    }
}
