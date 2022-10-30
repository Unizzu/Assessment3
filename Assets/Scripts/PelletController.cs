using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletController : MonoBehaviour
{
    private AudioSource pelletAudio;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        pelletAudio = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pelletCollected()
    {
        StartCoroutine(Pellet());
    }

    IEnumerator Pellet()
    {
        pelletAudio.Play();
        rend.enabled = false;
        yield return new WaitForSeconds(pelletAudio.clip.length);
        Destroy(gameObject);
    }
}
