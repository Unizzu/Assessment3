using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip gameStart;
    [SerializeField] private AudioClip ghostNormal;
    private AudioSource audioPlayer;
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.loop = false;
        StartCoroutine(playStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playStart()
    {
        audioPlayer.clip = gameStart;
        audioPlayer.Play();
        yield return new WaitForSeconds(audioPlayer.clip.length);
        audioPlayer.loop = true;
        audioPlayer.clip = ghostNormal;
        audioPlayer.Play();
    }
}
