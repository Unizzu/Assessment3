using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleBehaviourScript : MonoBehaviour
{
    private ParticleSystem partSys;
    // Start is called before the first frame update
    void Start()
    {
        partSys = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!partSys.isPlaying)
        {
            Destroy(gameObject, 2f);
        }
    }
}
