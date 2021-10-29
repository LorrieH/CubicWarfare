using UnityEngine;
using System.Collections;

public class ProjectileDamage : MonoBehaviour{

    [SerializeField]private float _damage;
    public float Damage
    {
        get { return _damage; }
    }
}
