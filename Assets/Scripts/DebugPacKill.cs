using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPacKill : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.Play("PacStudentDead");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
