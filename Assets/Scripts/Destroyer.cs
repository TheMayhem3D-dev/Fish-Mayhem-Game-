using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private enum ObjectType
    {
        Enemy,
        Coin
    }

    [Header("Components")]
    private Enemy enemy;
    private Movement movement;

    [SerializeField] private ObjectType objectType = ObjectType.Enemy;
    [Space]
    [SerializeField] private bool isRespawnTimeRnd;
    [SerializeField] private float respawnTime;

    [Header("Vertical Position Limit")]
    [SerializeField] private float minVerPosLimit;
    [SerializeField] private float maxVerPosLimit;

    void Awake()
    {
        if(objectType == ObjectType.Enemy)
        {
            enemy = GetComponent<Enemy>();
        }

        movement = GetComponent<Movement>();
    }

	public void ResetPositions()
    {
        StartCoroutine(ResetPos());
    }

    IEnumerator ResetPos()
    {
        float rndPos = Random.Range(minVerPosLimit, maxVerPosLimit);

        if (objectType == ObjectType.Enemy)
        {
            transform.position = GameController.instance.EnemySpawners[Random.Range(0, GameController.instance.EnemySpawners.Length)].position;
            transform.position = new Vector3(transform.position.x, rndPos, transform.position.z);
            enemy.ChangeDirection();
        }
        else if (objectType == ObjectType.Coin)
        {
            transform.position = GameController.instance.CoinSpawners[Random.Range(0, GameController.instance.CoinSpawners.Length)].position;
        }

        movement.CanMove = false;

        if (!isRespawnTimeRnd)
        {
            yield return new WaitForSeconds(respawnTime);
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(0, respawnTime));
        }

        movement.CanMove = true;
    }
}
