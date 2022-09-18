using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    private Tween tween;
    private List<Tween> tweenList;
    private Vector3[] endPosArray;
    private int endPosCounter;
    private Animator anim;
    private AudioSource sound;
    
    // Start is called before the first frame update
    void Start()
    {
        tweenList = new List<Tween>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        endPosArray = new Vector3[] { new Vector3(-3.5f, 4f, 0f), new Vector3(-3.5f, 2.78f, 0f), new Vector3(-5.04f, 2.78f, 0f), new Vector3(-5.04f, 4f, 0f)};
        TweenSetup();
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
        if (Vector3.Distance(transform.position, endPosArray[endPosCounter]) > 0.01f)
        {
            //Debug.Log("Moving...");
            //Debug.Log(currentTween.EndPos);
            transform.position = Vector3.Lerp(transform.position, endPosArray[endPosCounter], Time.deltaTime / 0.25f);
        }
        else
        {
            transform.position = endPosArray[endPosCounter];
            endPosCounter++;
            if(endPosCounter == 4)
            {
                endPosCounter = 0;
            }
            
            //Debug.Log(endPosArray[endPosCounter]);
            //Debug.Log("Tween End!");
            //break;
        }
        anim.SetInteger("moveIndicator", endPosCounter);

    }

    /*private void Move()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(-3.5f, 4f), 1f);
    }*/

    private void TweenSetup()
    {
        tweenList.Add(new Tween(transform, transform.position, new Vector3(-3.5f, 4f, 0f), Time.time, 1f));
        tweenList.Add(new Tween(transform, transform.position, new Vector3(-3.5f, 2.78f, 0f), Time.time, 1f));
        tweenList.Add(new Tween(transform, transform.position, new Vector3(-5.04f, 2.78f, 0f), Time.time, 1f));
        tweenList.Add(new Tween(transform, transform.position, new Vector3(-5.04f, 4f, 0f), Time.time, 1f));
    }
}
