using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    private Vector3[] endPosArray;
    private Vector3[] speedArray;
    private Vector3 originPoint = new Vector3(-5.21f, 4.1f, 0f);
    private Vector3 point1;
    private Vector3 point2;
    private Vector3 point3;
    [SerializeField] private float pacSpeed = 1f;
    private int PosCounter;
    private Animator anim;
    private AudioSource sound;
    
    // Start is called before the first frame update
    void Start()
    {
        SetPoints();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        transform.position = originPoint;
        anim.Play("PacStudentRight");
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(transform.position != new Vector3(-3.5f, 4f, 0f))
        {
            Move();
        }*/
        if (Vector3.Distance(transform.position, endPosArray[PosCounter]) > 0.05f)
        {
            //Previous attempt to lerp the motion, unfortunately it eases motion so it's no good...
            //
            //Debug.Log("Moving..."); <- Debug statement to check if Pacstudent was moving
            //Debug.Log(currentTween.EndPos);
            //transform.position = Vector3.Lerp(transform.position, endPosArray[PosCounter], Time.deltaTime / 0.25f);


            transform.Translate(speedArray[PosCounter] * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, endPosArray[PosCounter]) <= 0.05f)
        {
            transform.position = endPosArray[PosCounter];
            PosCounter++;
            if(PosCounter == 4)
            {
                PosCounter = 0;
            }
            
            //Debug.Log(endPosArray[endPosCounter]);
            //Debug.Log("Tween End!");
            //break;
        }
        anim.SetInteger("moveIndicator", PosCounter);

    }

    private void SetPoints()
    {
        point1 = originPoint + new Vector3(1.59f, 0f, 0f);
        point2 = originPoint + new Vector3(1.59f, -1.3f, 0f);
        point3 = originPoint + new Vector3(0f, -1.3f, 0f);
        //Debug.Log(point1);
        //Debug.Log(point2);
        //Debug.Log(point3);
        endPosArray = new Vector3[] { point1, point2, point3, originPoint };
        speedArray = new Vector3[] { new Vector3(pacSpeed, 0f, 0f), new Vector3(0f, -(pacSpeed), 0f), new Vector3(-(pacSpeed), 0f, 0f), new Vector3(0f, pacSpeed, 0f) };
    }
    /*private void Move()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(-3.5f, 4f), 1f);
    }*/

    //Used the Tween script from week 7 labs. It becomes unused as the lerp tweening solution did not work,
    //but the fields gave insight on how to make PacStudent move.
    //
    /*private void TweenSetup()
    {
        tweenList.Add(new Tween(transform, transform.position, new Vector3(-3.5f, 4f, 0f), Time.time, 1f));
        tweenList.Add(new Tween(transform, transform.position, new Vector3(-3.5f, 2.78f, 0f), Time.time, 1f));
        tweenList.Add(new Tween(transform, transform.position, new Vector3(-5.04f, 2.78f, 0f), Time.time, 1f));
        tweenList.Add(new Tween(transform, transform.position, new Vector3(-5.04f, 4f, 0f), Time.time, 1f));
    }*/
}
