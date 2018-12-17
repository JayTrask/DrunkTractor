using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour {

    GameObject[] tiles;
    public GameObject GrassTile;
    public GameObject WineTile;

	// Use this for initialization
	void Start () {
        tiles = GameObject.FindGameObjectsWithTag("tile");
        // print("tiles count:" + tiles.Length.ToString());
        generateNewField();
        // tileGetDebug();
		
	}
	
    void generateNewField()
    {
        int randomNumber = 0;
        int RangeMax = 20;
        int rangeGrass = 18;
        for (int x = 0; x < tiles.Length; x++)
        {
            randomNumber = Random.Range(1, RangeMax);
            if(randomNumber < rangeGrass)
            {
                //generate a grass tile
                GameObject grass = Instantiate(GrassTile);
                grass.transform.parent = tiles[x].transform;
                grass.transform.Translate(tiles[x].GetComponent<Transform>().position);
                grass.SetActive(true);
            }
            else
            {
                //generate wine tile
                GameObject wine = Instantiate(WineTile);
                wine.transform.parent = tiles[x].transform;
                wine.transform.Translate(tiles[x].GetComponent<Transform>().position);
                wine.SetActive(true);
            }
        }
    }

    void tileGetDebug()
    {
        for(int x = 0; x < tiles.Length; x++)
        {
            print("tile: " + x.ToString());
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
