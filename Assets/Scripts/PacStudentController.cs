using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PacStudentController : MonoBehaviour
{
    public Grid mapGrid;
    public Tilemap mapTile;

    private Vector3Int StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = new Vector3Int(-17, 7, 0);
        transform.position = mapTile.GetCellCenterWorld(StartPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
