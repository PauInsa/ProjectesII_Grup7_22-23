using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip fireSound, recargarSound;
    static AudioSource audioSrc;


    void Start()
    {
        fireSound = Resources.Load<AudioClip>("Bang");
        recargarSound = Resources.Load<AudioClip>("Recargar");

        audioSrc = GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Bang":
                audioSrc.PlayOneShot(fireSound);
                break;

            case "Recargar":
                audioSrc.PlayOneShot(recargarSound);   
                break;
            default:
                break;
        }
    }
}
