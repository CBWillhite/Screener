//FindObjectOfType<AudioManager>().Play("soundName");
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    [Range(0f, 1f)]
    public float SFXVolume = 1f;

    [Range(0f, 1f)]
    public float musicVolume = 1f;

    [Range(0f, 1f)]
    public float masterVolume = 1f;

    private float vol;
    
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            if(s.category=="SFX") {
                vol = s.volume * masterVolume * SFXVolume;
            } else if(s.category=="Music") {
                vol = s.volume * masterVolume * musicVolume;
            } else {
                vol = s.volume * masterVolume;
            }
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = vol;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning(name + " was not found. Check that it was spelled correctly.");
            return;
        }
        s.source.PlayOneShot(s.source.clip);
    }

    public void PlayLooped(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning(name + " was not found. Check that it was spelled correctly.");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning(name + " was not found. Check that it was spelled correctly.");
            return;
        }
        s.source.Stop();
    }

    public void updMaster(Slider val)
    {
        masterVolume = val.value/100;
        foreach (Sound s in sounds)
        {
            if(s.category=="SFX") {
                vol = s.volume * masterVolume * SFXVolume;
            } else if(s.category=="Music") {
                vol = s.volume * masterVolume * musicVolume;
            } else {
                vol = s.volume * masterVolume;
            }
            s.source.volume = vol;
        }
    }

    public void updMusic(Slider val)
    {
        musicVolume = val.value/100;
        foreach (Sound s in sounds)
        {
            if(s.category=="Music") {
                vol = s.volume * masterVolume * musicVolume;
                s.source.volume = vol;
            }
        }
    }

    public void updSFX(Slider val)
    {
        SFXVolume = val.value/100;
        foreach (Sound s in sounds)
        {
            if(s.category=="SFX") {
                vol = s.volume * masterVolume * SFXVolume;
                s.source.volume = vol;
            }
        }
    }

    
}
