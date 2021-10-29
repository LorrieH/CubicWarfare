using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private int _playerID;
    public int PlayerID
    {
        get { return _playerID; }
        set { _playerID = value; }
    }
    private float _speed = 10f;
    private Rigidbody2D _rb2d;
    
    private PlayerShoot _shoot;
    private AudioSource _source;
    [SerializeField]private AudioClip _clip;

    void Awake()
    {
        _shoot = GetComponent<PlayerShoot>();
        _rb2d = GetComponent<Rigidbody2D>();
        
        _source = GetComponent<AudioSource>();
    }
    void Update()
    {
        float x = Input.GetAxis("Xbox_JoystickLeft_X_" + _playerID);
        _rb2d.velocity = new Vector2(x * _speed, _rb2d.velocity.y);
    }

    public void Jump()
    {
        _rb2d.velocity = new Vector2(0, 25f);
        _source.pitch = Random.Range(.75f, 1.25f);
        _source.PlayOneShot(_clip);
    }

    public void Shoot()
    {
        StartCoroutine(_shoot.Shoot());
    }

    public void Jetpack()
    {
        _rb2d.AddForce(Vector2.up * Input.GetAxis("Xbox_LT_" + _playerID) * 100, ForceMode2D.Force);
    }
}
