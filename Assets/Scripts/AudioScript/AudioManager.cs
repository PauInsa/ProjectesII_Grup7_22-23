using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public Slider volumenFX;
    public Slider volumenMusic;
    public AudioMixer mixer;
    private float lastVol;
    public Toggle muted;

    public void SetMute()
    {
        mixer.GetFloat("VolMaster", out lastVol);

        if (muted.isOn)
            mixer.SetFloat("VolMaster", -80);
        else
            mixer.SetFloat("VolMaster", lastVol);
    }

    private void Awake()
    {
        volumenFX.onValueChanged.AddListener(ChangeVolumenFX);
        volumenMusic.onValueChanged.AddListener(ChangeVolumenMaster);
    }

    public void ChangeVolumenMaster(float v)
    {
        mixer.SetFloat("VolMaster", v);
    }

    public void ChangeVolumenFX(float v)
    {
        mixer.SetFloat("VolFX", v);
    }
}
