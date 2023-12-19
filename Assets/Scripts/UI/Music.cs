using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource music;

    public void MusicOn()
    {
        music.Play();
    }

    public void MusicOff()
    {
      music.Stop();
    }
}
