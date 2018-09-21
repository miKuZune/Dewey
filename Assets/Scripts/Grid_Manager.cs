using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Manager : MonoBehaviour
{

	public GameObject gridObj;

	public int gridWidth = 3;
	public int gridLength = 3;

	Vector3 gridBounds = new Vector3();

	Level_Generator level_Generator;

	void Start() 
	{

		level_Generator = GameObject.Find("MapManager").GetComponent<Level_Generator>();

		GetGridRendererSize(gridObj);
		InstantiateGrid();
	}


    public void InstantiateGrid()
    {

		GameObject objToSpawn;

		objToSpawn = new GameObject("Grid");


        for (int x = 0; x < gridWidth; x++) 
		{

			for (int y = 0; y < gridLength; y++) 
			{

				//Instantiate our grid
				GameObject grid = (GameObject)Instantiate (gridObj, new Vector3(x * gridBounds.x, 0, y * gridBounds.x),
					transform.rotation = Quaternion.identity) as GameObject;

				grid.name = "Grid_" + x + "_" + y;
				grid.transform.SetParent(objToSpawn.transform, false);
				//grid.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

			}
		}

		level_Generator.GetGridInfo();
	}


	void GetGridRendererSize(GameObject obj)
	{

		Renderer grRenderer = obj.GetComponent<Renderer>();
		gridBounds = grRenderer.bounds.size;

	}

}
