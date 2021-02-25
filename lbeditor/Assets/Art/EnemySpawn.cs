using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        InvokeRepeating("Spawn",1.0f, 2.0f);
    }
    public void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
    }
}
