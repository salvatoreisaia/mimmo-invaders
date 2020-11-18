using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance = null;

    public AudioClip alienBuzz1;
    public AudioClip alienBuzz2;
    public AudioClip alienDies;
    public AudioClip bulletFire;
    public AudioClip shipExplosion;
    public AudioClip tobiaInitial;
    public AudioClip tobiaLoop;
    public AudioClip tobiashoot;
    public AudioClip gameover;
    public AudioClip laughter;
    public AudioClip ua;
    public AudioClip winning;
    public AudioClip martinDisco;
    public AudioClip cat;
    public AudioClip bong;
    public AudioClip gallina;
    public AudioClip hot;
    public AudioClip proposta;
    public AudioClip brokenCrystals;
    private AudioSource soundEffectAudio;

    // Use this for initialization
    void Start () {
        if (Instance == null) {
            Instance = this;

        } else if (Instance != this)
        {
            Destroy(gameObject);

        }
        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;

	}
    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);

    }
    public void PlayInLoop(AudioClip clip)
    {
        soundEffectAudio.loop = true;
        soundEffectAudio.PlayOneShot(clip);

    }

}
