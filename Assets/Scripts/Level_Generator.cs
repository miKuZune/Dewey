using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Generator : MonoBehaviour 
{

	//Grid Information
	public List<GameObject> obj_Grid_Corners = new List<GameObject>();
	public List<GameObject> obj_Grid_Side = new List<GameObject>();
	public List<GameObject> obj_Grid_Middle = new List<GameObject>();

	string[] grid_Corners;
	string[] grid_Side;
	string[] grid_Middle;

	//Tile Sets
	public List<GameObject> tile_Grid_Corners = new List<GameObject>();
	public List<GameObject> tile_Grid_Side = new List<GameObject>();
	public List<GameObject> tile_Grid_Middle = new List<GameObject>();

	public bool isMapGenerated = false;

	public void GetGridInfo()
	{

		grid_Corners = new string[4]
		{

			"Grid_0_0", "Grid_0_3", "Grid_2_0", "Grid_2_3"

		};

		grid_Side = new string[6]
		{
			
			"Grid_0_1", "Grid_0_2", "Grid_1_0", "Grid_1_3", "Grid_2_1", "Grid_2_2"

		};

		grid_Middle = new string[2]
		{
			
			"Grid_1_1", "Grid_1_2"

		};

		for (int i = 0; i < grid_Corners.Length; i++) 
		{

			string name = grid_Corners[i];
			//Debug.Log(name);
			obj_Grid_Corners.Add(GameObject.Find(name));

		}


		for (int i = 0; i < grid_Side.Length; i++) 
		{

			string name = grid_Side[i];
			//Debug.Log(name);
			obj_Grid_Side.Add(GameObject.Find(name));

		}

		for (int i = 0; i < grid_Middle.Length; i++) 
		{

			string name = grid_Middle[i];
			//Debug.Log(name);
			obj_Grid_Middle.Add(GameObject.Find(name));

		}

		tile_Grid_Corners = new List<GameObject>(Resources.LoadAll<GameObject>("Tiles/Corners"));
		tile_Grid_Side = new List<GameObject>(Resources.LoadAll<GameObject>("Tiles/Side"));
		tile_Grid_Middle = new List<GameObject>(Resources.LoadAll<GameObject>("Tiles/Middle"));

        GenerateMap();


    }

    public void ClearMap()
    {
        Destroy(GameObject.Find("Grid"));
        isMapGenerated = false;
    }

	public void GenerateMap()
	{

		if (isMapGenerated == false)
		{
		GameObject gameObjSpawned = new GameObject("Map_Generated");

		for (int i = 0; i < obj_Grid_Corners.Count; i++) 
		{

			int maxId = tile_Grid_Corners.Count;
			int id = Random.Range(0, maxId);

			GameObject tileToSpawn = tile_Grid_Corners[id];

			//Instantiate Our Object
			GameObject gridSpriteCorner = (GameObject)Instantiate(tileToSpawn, obj_Grid_Corners[i].transform.position, 
				obj_Grid_Corners[i].transform.rotation) as GameObject;

                gridSpriteCorner.transform.SetParent(obj_Grid_Corners[i].transform, false);


                if (gridSpriteCorner.transform.parent.name == "Grid_0_0")
                {

                    gridSpriteCorner.transform.Rotate(new Vector3(0f, 270f, 0f));

                }

                gridSpriteCorner.transform.SetParent(obj_Grid_Corners[i].transform, false);


                if (gridSpriteCorner.transform.parent.name == "Grid_2_3")
                {

                    gridSpriteCorner.transform.Rotate(new Vector3(0f, 90f, 0f));

                }

                gridSpriteCorner.transform.SetParent(obj_Grid_Corners[i].transform, false);


                if (gridSpriteCorner.transform.parent.name == "Grid_2_0")
                {

                    gridSpriteCorner.transform.Rotate(new Vector3(0f, 180f, 0f));

                }

            }

		for (int i = 0; i < obj_Grid_Side.Count; i++) 
		{

			int maxId = tile_Grid_Side.Count;
			int id = Random.Range(0, maxId);

			GameObject tileToSpawn = tile_Grid_Side[id];

			//Instantiate Our Object
			GameObject gridSpriteSide = (GameObject)Instantiate(tileToSpawn, obj_Grid_Side[i].transform.position, 
				obj_Grid_Side[i].transform.rotation) as GameObject;

                gridSpriteSide.transform.SetParent(obj_Grid_Side[i].transform, false);


                if (gridSpriteSide.transform.parent.name == "Grid_1_0")
                {

                    gridSpriteSide.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + -90f, 0);

                }


                if (gridSpriteSide.transform.parent.name == "Grid_1_3")
                {

                    gridSpriteSide.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90f, 0);

                }

                if (gridSpriteSide.transform.parent.name == "Grid_2_2")
                {

                    gridSpriteSide.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180f, 0);

                }

                if (gridSpriteSide.transform.parent.name == "Grid_2_1")
                {

                    gridSpriteSide.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180f, 0);

                }

            }

		for (int i = 0; i < obj_Grid_Middle.Count; i++) 
		{

			int maxId = tile_Grid_Middle.Count;
			int id = Random.Range(0, maxId);

			GameObject tileToSpawn = tile_Grid_Middle[id];

			//Instantiate Our Object
			GameObject gridMiddleSprite = (GameObject)Instantiate(tileToSpawn, obj_Grid_Middle[i].transform.position, 
				obj_Grid_Middle[i].transform.rotation) as GameObject;

                gridMiddleSprite.transform.SetParent(obj_Grid_Middle[i].transform, false);


		}

		isMapGenerated = true;

            GameObject.Find("Grid").transform.localScale = new Vector3(0.1f, 1f, 0.1f);

		}

		else
		{

			isMapGenerated = false;
			GameObject destroyI = GameObject.Find("Map_Generated");
			GameObject.Destroy(destroyI);

					GameObject gameObjSpawned = new GameObject("Map_Generated");

		for (int i = 0; i < obj_Grid_Corners.Count; i++) 
		{

			int maxId = tile_Grid_Corners.Count;
			int id = Random.Range(0, maxId);

			GameObject tileToSpawn = tile_Grid_Corners[id];

			//Instantiate Our Object
			GameObject gridSpriteCorner = (GameObject)Instantiate(tileToSpawn, obj_Grid_Corners[i].transform.position, 
				obj_Grid_Corners[i].transform.rotation) as GameObject;

                gridSpriteCorner.transform.SetParent(obj_Grid_Corners[i].transform, false);

                if (gridSpriteCorner.transform.parent.name == "Grid_0_0")
                {

                    gridSpriteCorner.transform.Rotate(new Vector3(0f, 270f, 0f));

                }

                gridSpriteCorner.transform.SetParent(obj_Grid_Corners[i].transform, false);


                if (gridSpriteCorner.transform.parent.name == "Grid_2_3")
                {

                    gridSpriteCorner.transform.Rotate(new Vector3(0f, 90f, 0f));

                }

                gridSpriteCorner.transform.SetParent(obj_Grid_Corners[i].transform, false);


                if (gridSpriteCorner.transform.parent.name == "Grid_2_0")
                {

                    gridSpriteCorner.transform.Rotate(new Vector3(0f, 180f, 0f));

                }

            }

		for (int i = 0; i < obj_Grid_Side.Count; i++) 
		{

			int maxId = tile_Grid_Side.Count;
			int id = Random.Range(0, maxId);

			GameObject tileToSpawn = tile_Grid_Side[id];

			//Instantiate Our Object
			GameObject gridSpriteSide = (GameObject)Instantiate(tileToSpawn, obj_Grid_Side[i].transform.position, 
				obj_Grid_Side[i].transform.rotation) as GameObject;

                gridSpriteSide.transform.SetParent(obj_Grid_Side[i].transform, false);

                if (gridSpriteSide.transform.parent.name == "Grid_1_0")
                {

                    gridSpriteSide.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + -90f, 0);

                }


                if (gridSpriteSide.transform.parent.name == "Grid_1_3")
                {

                    gridSpriteSide.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90f, 0);

                }

                if (gridSpriteSide.transform.parent.name == "Grid_2_2")
                {

                    gridSpriteSide.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180f, 0);

                }

                if (gridSpriteSide.transform.parent.name == "Grid_2_1")
                {

                    gridSpriteSide.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180f, 0);

                }



            }

            for (int i = 0; i < obj_Grid_Middle.Count; i++) 
		{

			int maxId = tile_Grid_Middle.Count;
			int id = Random.Range(0, maxId);

			GameObject tileToSpawn = tile_Grid_Middle[id];

			//Instantiate Our Object
			GameObject hexAISprite = (GameObject)Instantiate(tileToSpawn, obj_Grid_Middle[i].transform.position, 
				obj_Grid_Middle[i].transform.rotation) as GameObject;

				hexAISprite.transform.SetParent(obj_Grid_Middle[i].transform, false);


		}

		isMapGenerated = true;
            GameObject.Find("Grid").transform.localScale = new Vector3(0.1f, 1f, 0.1f);

        }

	}
}
