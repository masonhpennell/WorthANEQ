using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSound : MonoBehaviour
{
    public AudioClip SoundEffect;
    private AudioSource Audio;
    void Start()
    {
        Audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider c)
    {
        Audio.PlayOneShot(SoundEffect);
    }
}
