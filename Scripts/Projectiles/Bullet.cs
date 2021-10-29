using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    [SerializeField]private GameObject _deathParticles;
    [SerializeField]private float _projectileSpeed;
    private ProjectileDamage _projectileDamage;

    void Start()
    {
        _projectileDamage = GetComponent<ProjectileDamage>();
    }


    
	void Update () 
    {
        transform.Translate(Vector2.right * _projectileSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("TakeDamage", _projectileDamage.Damage);
            ObjectPool.instance.PoolObject(this.gameObject);

        }
        else if (col.gameObject.tag != "Bullet")
        {
            ObjectPool.instance.PoolObject(this.gameObject);
        }
        
    }
}
