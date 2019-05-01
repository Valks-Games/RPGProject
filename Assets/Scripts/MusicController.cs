using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip soundtrackTown;
    private AudioClip soundtrackDungeon;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundtrackTown = Resources.Load<AudioClip>("Audio/TownTheme");
        soundtrackDungeon = Resources.Load<AudioClip>("Audio/Rise of spirit");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("TownArea")) {
            Debug.Log(soundtrackTown);
            audioSource.clip = soundtrackTown;
            audioSource.Play();
        }

        if (collision.gameObject.tag.Equals("DungeonArea")) {
            audioSource.clip = soundtrackDungeon;
            audioSource.Play();
        }
    }

    /*void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetInstanceID() == areaTown.GetInstanceID())
        {
            StartCoroutine(AudioFadeScript.FadeOut(audioSource, 1f));
        }
    }*/
}
