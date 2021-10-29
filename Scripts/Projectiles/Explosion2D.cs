using UnityEngine;
using System.Collections;

public class Explosion2D : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField]private AudioClip _clip;
    [SerializeField]private float _explosionDelay = .01f;
    [SerializeField]private float _explosionRate = 1;
    [SerializeField]private float _maxExplosionSize = 10;
    [SerializeField]private float _explosionModifier = 10;
    [SerializeField]private float _currentRadius = 0;
    [SerializeField]private float _directHit = 30;

    private Rigidbody2D _targetRigidBody2D;
    private CircleCollider2D _explosionRadius;

    private bool _isExploded = false;
    // Use this for initialization
    void Start()
    {
        _explosionRadius = GetComponent<CircleCollider2D>();
    }

    void OnEnable()
    {
        _source = GetComponent<AudioSource>();
        _source.PlayOneShot(_clip);
        _explosionDelay = .01f;
    }

    // Update() is called once per frame
    void FixedUpdate()
    {
        _explosionDelay -= Time.deltaTime;
        if (_explosionDelay < 0)
        {
            _isExploded = true;
        }

        if (_isExploded)
        {
            if (_currentRadius < _maxExplosionSize)
            {
                _currentRadius += _explosionRate;
            }

            _explosionRadius.radius = _currentRadius;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        _targetRigidBody2D = col.gameObject.GetComponent<Rigidbody2D>();
        if (_isExploded)
        {
            if (_targetRigidBody2D != null)
            {
                float damage;
                Vector2 target = col.gameObject.transform.position;
                Vector2 bomb = gameObject.transform.position;
                Vector2 direction = _explosionModifier * (bomb - target);
                float distanceToPlayer = Vector2.Distance(target, bomb);
                _targetRigidBody2D.AddForce(direction);
                if (distanceToPlayer < 0.9)
                {
                    damage = _directHit;
                }
                else
                {
                    damage = CalcDamage(distanceToPlayer);
                }
                col.gameObject.SendMessage("TakeDamage", damage);
            }
        }
    }

    float CalcDamage(float number)
    {
        return number * 10f;
    }
}