using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlAudio : MonoBehaviour
{

    [SerializeField] Image musicOn;
    [SerializeField] Image musicOff;
    [SerializeField] Image effectOn;
    [SerializeField] Image effectOff;
    [SerializeField] AudioSource audioSource;
    private bool musicMute = false;
    private bool effectMute = false;

    public void Start()
    {

        if (!PlayerPrefs.HasKey("music") && !PlayerPrefs.HasKey("effect"))
        {        
          PlayerPrefs.SetInt("music", 0);
            PlayerPrefs.SetInt("effect", 0);
            Load();
        }
        else
        {
            Load();
        }

        MusicIcon();
        EffectIcon();
        if (musicMute) 
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
       // AudioListener.pause = musicMute;

    }

    public void MusicToggle()
    {
        if (!musicMute)
        {
            musicMute = true;
            //AudioListener.pause = true;
            audioSource.Pause();
        }
        else
        {
            musicMute = false;
            // AudioListener.pause = false;
            audioSource.Play();
        }

        MusicIcon();
        SaveMusic();

    }

    public void EffectToggle()
    {
        if (!effectMute)
        {
            effectMute = true;
        }
        else
        {
            effectMute = false;
        }

        EffectIcon();
        SaveEffect();

    }

    private void MusicIcon()
    {
        if (!musicMute)
        {
            musicOn.enabled = true;
            musicOff.enabled = false;

        }
        else
        {
            musicOn.enabled = false;
            musicOff.enabled = true;
        }
    }

    private void EffectIcon()
    {
        if (!effectMute)
        {
            effectOn.enabled = true;
            effectOff.enabled = false;

        }
        else
        {
            effectOn.enabled = false;
            effectOff.enabled = true;
        }
    }

    private void Load()
    {
        musicMute = PlayerPrefs.GetInt("music") == 1;
        effectMute = PlayerPrefs.GetInt("effect") == 1;
    }

    private void SaveMusic()
    {
        PlayerPrefs.SetInt("music", musicMute ? 1 : 0);
    }

    private void SaveEffect()
    {
        PlayerPrefs.SetInt("effect", effectMute ? 1 : 0);
    }

}
