using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private AudioClip _clip;
    private AudioSource _source;
    [SerializeField]private float _health = 100;
    public float PHealth
    {
        get
        {
            return _health;
        }
    }
    private PlayerLives _playerLives;

    void Start()
    {
        _playerLives = GetComponent<PlayerLives>();
        _source = GetComponent<AudioSource>();
    }

    /*void OnCollisonEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Bullet")
        {
            TakeDamage(coll.gameObject.GetComponent<ProjectileDamage>()._damage);
        }
    }*/

    void TakeDamage(float _dmg)
    {
        PlayHitSound();
        _health -= _dmg;

        if (_health <= 0)
        {
            _playerLives.RemoveLives();
           _health = 100;
        }
    }

    void PlayHitSound()
    {
        _source.PlayOneShot(_clip);
    }

}