using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SystemGameScript : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Congratulations;

    public AudioClip winAudio;
    public AudioClip loseAudio;

    private AudioSource audioManager;

    

    private void Start()
    {
       audioManager = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag == Statement.win)
        {
            Congratulations.SetActive(true);
  
            if(audioManager.clip != winAudio)
            {
                audioManager.clip = winAudio;
            }

            audioManager.Play();
        }

        if (target.gameObject.tag == Statement.lose || 
            target.gameObject.tag == GameState.enemy)
        {
            GameOver.SetActive(true);

            if (audioManager.clip != loseAudio)
            {
                audioManager.clip = loseAudio;
            }

            audioManager.Play();
        }

    }
}
