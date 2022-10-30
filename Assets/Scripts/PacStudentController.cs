using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] public Grid mapGrid;
    [SerializeField] private Tilemap mapTile;
    [SerializeField] private Transform particleSpawner;
    [SerializeField] private GameObject dustParticle;

    private Animator anim;
    private AudioSource pacSound;
    private Vector3Int[] NextPosArray = new Vector3Int[] { Vector3Int.zero, new Vector3Int(-1, 0, 0), new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(0, -1, 0) };
    private Quaternion[] DustRotation = new Quaternion[] { new Quaternion(0, 0, 0, 1), new Quaternion(0, 90, 0, 1), new Quaternion(0, -90, 0, 1), new Quaternion(90, 0, 0, 1), new Quaternion(-90, 0, 0, 1)};
    public enum Direction {None, Left, Right, Up, Down};
    public static Direction lastDirection = Direction.None;
    private KeyCode lastInput;
    private KeyCode currentInput;
    private TileBase NextTile;
    private Vector3Int StartPos = new Vector3Int(-17, 7, 0);
    private Vector3Int CurrentPos;
    private Vector3Int TargetPos;
    private Vector3Int NextPos;
    private float pacSpeed = 1.5f;
    private bool isLerping;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pacSound = GetComponent<AudioSource>();

        CurrentPos = StartPos;
        
        //Debug.Log(CurrentPos);
        //Debug.Log(TargetPos);
        transform.position = mapTile.GetCellCenterWorld(CurrentPos);
        StartCoroutine(dustBehavior());
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        PlayWalk();
        float step = pacSpeed * Time.deltaTime;
        if(!isLerping)
        {
            TargetPos = CurrentPos + NextPosArray[(int)lastDirection];
            NextPos = TargetPos + NextPosArray[(int)lastDirection];
            anim.speed = 0;
        }
        NextTile = mapTile.GetTile(TargetPos);
        if (NextTile.name == "Tiles_0" || NextTile.name == "Tiles_5" || NextTile.name == "Tiles_6")
        {
            if (Vector3.Distance(transform.position, mapTile.GetCellCenterWorld(TargetPos)) > 0.01f)
            {
                anim.speed = 1;
                anim.SetInteger("Direction", (int)lastDirection);
                transform.position = Vector3.MoveTowards(transform.position, mapTile.GetCellCenterWorld(TargetPos), step);
                isLerping = true;
            }
            else if (Vector3.Distance(transform.position, mapTile.GetCellCenterWorld(TargetPos)) <= 0.01f)
            {
                transform.position = mapTile.GetCellCenterWorld(TargetPos);
                currentInput = lastInput;
                CurrentPos = TargetPos;
                TargetPos = NextPos;
                anim.speed = 0;
                isLerping = false;
            }
        }
        else
        {
            lastDirection = Direction.None;
        }
        
    }

    private void PlayWalk()
    {
        if(lastDirection != Direction.None)
        {
            if (!pacSound.isPlaying)
            {
                pacSound.Play();
            }
        }
        else
        {
            pacSound.Stop();
        }
    }
    private void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            lastInput = KeyCode.A;
            lastDirection = Direction.Left;
            //Debug.Log(NextTile.name);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = KeyCode.D;
            lastDirection = Direction.Right;
            //Debug.Log(NextTile.name);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = KeyCode.W;
            lastDirection = Direction.Up;
            //Debug.Log(NextTile.name);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = KeyCode.S;
            lastDirection = Direction.Down;
            //Debug.Log(NextTile.name);
        }
    }

    IEnumerator dustBehavior()
    {
        yield return new WaitForSeconds(0.5f);
        if(isLerping)
        {
            Instantiate(dustParticle, transform.position, DustRotation[(int)lastDirection], particleSpawner);
        }
        StartCoroutine(dustBehavior());
    }
}
