using UnityEngine;
using System.Collections;

public class Machinegun : MonoBehaviour, IWeapon
{
    [SerializeField]private Transform _muzzle;
    [SerializeField]private GameObject _bullet;
    private string _weaponName = "Machinegun";
    public string WeaponName
    {
        get
        {
            return _weaponName;
        }
    }

    public void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetObjectForType(_bullet.name, false);
        bullet.transform.position = _muzzle.position;
        bullet.transform.rotation = _muzzle.rotation;
    }
}