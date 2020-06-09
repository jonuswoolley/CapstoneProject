using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource Sounds;

    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip hit3;

    public AudioClip miss1;
    public AudioClip miss2;

    public AudioClip Stab1;
    public AudioClip Smash1;
    public AudioClip WizHit1;

    public AudioClip PillarDestroy;
    public AudioClip Fireball1;
    public AudioClip Fireball2;
    public AudioClip Fireball3;

    private void Start()
    {
        Sounds = GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        int randRange = Random.Range(1, 3);
        if (randRange == 1)
            Sounds.PlayOneShot(hit1, 0.7f);
        else if (randRange == 2)
            Sounds.PlayOneShot(hit2, 0.7f);
        else if (randRange == 3)
            Sounds.PlayOneShot(hit3, 0.7f);
    }

    public void PlayMissHitSound()
    {
        int randRange = Random.Range(1, 2);
        if (randRange == 1)
            Sounds.PlayOneShot(miss1, 0.7f);
        else if (randRange == 2)
            Sounds.PlayOneShot(miss2, 0.7f);
    }

    public void PlayStabSound()
    {
        Sounds.PlayOneShot(Stab1, 0.7f);
    }
    public void PlaySmashSound()
    {
        Sounds.PlayOneShot(Smash1, 0.3f);
    }
    public void PlayWizHitSound()
    {
        Sounds.PlayOneShot(WizHit1, 0.6f);
    }

    public void PillarDestroySound()
    {
        Sounds.PlayOneShot(PillarDestroy, 0.7f);
    }

    public void FireballSound()
    {
        int randRange = Random.Range(1, 4);
        if (randRange == 1)
            Sounds.PlayOneShot(Fireball1, 0.2f);
        else if (randRange == 2)
            Sounds.PlayOneShot(Fireball2, 0.2f);
        else if (randRange == 3)
            Sounds.PlayOneShot(Fireball3, 0.2f);
    }
}