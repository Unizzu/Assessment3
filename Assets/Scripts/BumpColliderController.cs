using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BumpColliderController : MonoBehaviour
{
    [SerializeField] private Transform particleSpawner;
    [SerializeField] private GameObject bumpParticle;
    [SerializeField] private Tilemap mapTile;

    private Collider2D col;
    private AudioSource bumpSound; 
    private bool bumped = false;
    private TileBase TileCheck;
    private Vector3Int CurrentTilePos;
    private Vector3[] PosArray = new Vector3[] { Vector3.zero, new Vector3(-0.25f, 0f, 0f), new Vector3(-0.25f, 0f, 0f), new Vector3(0f, 0.25f, 0f), new Vector3(0f, -0.25f, 0f)};
    
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        bumpSound = GetComponent<AudioSource>();
        transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = PosArray[(int)PacStudentController.lastDirection];
        CurrentTilePos = mapTile.LocalToCell(transform.localPosition);
        TileCheck = mapTile.GetTile(CurrentTilePos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Map")
        {
            if (TileCheck.name != "Tiles_0" || TileCheck.name != "Tiles_5" || TileCheck.name != "Tiles_6" 
                && PacStudentController.lastDirection == PacStudentController.Direction.None && !bumped)
            {
                StartCoroutine(Bump());
                bumped = true;
            }
        }
    }

    IEnumerator Bump()
    {
        yield return null;
        Instantiate(bumpParticle, transform.position, Quaternion.identity, particleSpawner);
        bumpSound.Play();
        //Debug.Log("Bumped! " + bumped);
        yield return new WaitForSeconds(0.5f);
        bumped = false;
    }
}
