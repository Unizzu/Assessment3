using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PelletGenerator : MonoBehaviour
{
    [SerializeField] private GameObject pellet;
    [SerializeField] private GameObject powerPellet;
    [SerializeField] private Transform pelletGroup;
    [SerializeField] private TileBase newTile;

    private Tilemap tm;
    private Vector3Int StartPos = new Vector3Int(-18, 8, 0);
    private Vector3Int EndPos = new Vector3Int(9, -20, 0);
    private Vector3 SpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<Tilemap>();

        SpawnPellets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPellets()
    {
        for (int x = StartPos.x; x <= EndPos.x; x++) 
        {
            for (int y = StartPos.y; y >= EndPos.y; y--) 
            {
                TileBase tile = tm.GetTile(new Vector3Int(x, y, 0));
                if (tile != null) 
                {
                    if(tile.name == "Tiles_5")
                    {
                        //Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                        SpawnPos = tm.GetCellCenterWorld(new Vector3Int(x, y, 0));
                        Instantiate(pellet, SpawnPos, Quaternion.identity, pelletGroup);
                        tm.SetTile(new Vector3Int(x, y, 0), newTile);
                    }
                    if(tile.name == "Tiles_6")
                    {
                        SpawnPos = tm.GetCellCenterWorld(new Vector3Int(x, y, 0));
                        Instantiate(powerPellet, SpawnPos, Quaternion.identity, pelletGroup);
                        tm.SetTile(new Vector3Int(x, y, 0), newTile);
                    }
                }
            }
        }
    }
}
