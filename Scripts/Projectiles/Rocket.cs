using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    [SerializeField]private GameObject _rocketDeathParticles;
    [SerializeField]private GameObject _explosion;
    [SerializeField]private float _projectileSpeed;
    
    void Update()
    {
        transform.Translate(Vector2.right * _projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            DestroyRocket();
        }
        else if(col.gameObject.tag != "Bullet" || col.gameObject.tag != "Explosion")
        {
            DestroyRocket();
        }
       
    }

    void DestroyRocket()
    {
        GameObject deathParticles = ObjectPool.instance.GetObjectForType(_rocketDeathParticles.name, false);
        deathParticles.transform.position = transform.position;
        deathParticles.transform.rotation = transform.rotation;
        ObjectPool.instance.PoolObject(this.gameObject);

        GameObject explosion = ObjectPool.instance.GetObjectForType(_explosion.name, false);
        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
        ObjectPool.instance.PoolObject(this.gameObject);
    }
}