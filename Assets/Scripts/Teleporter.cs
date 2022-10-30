using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3Int targetTilePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3Int getTargetTilePos()
    {
        return targetTilePos;
    }
}
