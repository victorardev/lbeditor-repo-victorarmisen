using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyTransform;
    private void Start()
    {
        enemyTransform = GameObject.FindGameObjectWithTag("EnemySpawn").transform;
        InvokeRepeating("SpawnEnemies", 1.0f, 1.5f);
    }
    void SpawnEnemies()
    {
        Instantiate(enemyPrefab, enemyTransform.position, enemyPrefab.transform.rotation);
    }
}
