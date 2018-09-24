using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour {

    public GameObject chest;
    public int chanceToSpawn;
	// Use this for initialization
	void Start ()
    {
        System.Random rand = new System.Random();
        int spawnChance = rand.Next(0, 100);

        if(spawnChance > chanceToSpawn)
        {
            Instantiate(chest, transform);
        }
	}
}
