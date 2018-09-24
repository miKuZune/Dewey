using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;

    public int numToSpawn;

	// Use this for initialization
	void Start ()
    {
        SpawnEnemies(numToSpawn);
	}
	
	void SpawnEnemies(int enemiesToSpawn)
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            Instantiate(enemy,transform);
        }
    }
}
