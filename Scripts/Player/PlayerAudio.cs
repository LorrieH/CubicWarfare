using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour {

    public delegate void PlaySound();
    PlaySound soundDelegate;
    private AudioSource _source;
    [SerializeField]private AudioClip[] _clips;

    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

}
