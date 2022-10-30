using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    private float cherrySpeed = 3.0f;
    private Renderer cherryRender;
    private float randomX1;
    private float randomX2;
    private float randomY1;
    private float randomY2;
    private int binaryChoice;
    private Vector3 Pos1;
    private Vector3 Pos2;
    private Vector3 StartPos;
    private Vector3 EndPos;
    
    // reference:
    // lowerBound = x: -12.95 y: -4.99
    // upperBound = x: 10.37 y: 4.99
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCherry());
        cherryRender = gameObject.GetComponent<Renderer>();
        cherryRender.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float step = cherrySpeed * Time.deltaTime;
        if(cherryRender.enabled)
        {
            if(Vector3.Distance(StartPos, EndPos) > 0.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, EndPos, step);
            }
            else if (Vector3.Distance(StartPos, EndPos) <= 0.5f)
            {
                transform.position = EndPos;
                cherryRender.enabled = false;
            }
        }
    }

    IEnumerator SpawnCherry()
    {
        yield return new WaitForSeconds(10f);
        Randomizer();
        //Debug.Log("here come da cherry");
        cherryRender.enabled = true;
        transform.position = StartPos;
        StartCoroutine(SpawnCherry());
    }

    private void Randomizer()
    {
        binaryChoice = Random.Range(0, 2);
        if (binaryChoice == 0)
        {
            randomX1 = Random.Range(-13.5f, 11f);
            randomX2 = Random.Range(-13.5f, 11f);
            Pos1 = new Vector3(randomX1, -5.5f, 0f);
            Pos2 = new Vector3(randomX2, 5.5f, 0f);
        }
        else
        {
            randomY1 = Random.Range(-5.5f, 5.5f);
            randomY2 = Random.Range(-5.5f, 5.5f);
            Pos1 = new Vector3(-13.5f, randomY1, 0f);
            Pos2 = new Vector3(11f, randomY2, 0f);
        }
        binaryChoice = Random.Range(0, 2);
        if (binaryChoice == 0)
        {
            StartPos = Pos1;
            EndPos = Pos2;
        }
        else
        {
            EndPos = Pos1;
            StartPos = Pos2;
        }
    }
}
