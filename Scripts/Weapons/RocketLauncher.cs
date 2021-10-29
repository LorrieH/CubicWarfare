using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour, IWeapon
{
    [SerializeField]private Transform _muzzle;
    [SerializeField]private GameObject _rocket;
    private string _weaponName = "Rocket Launcher";
    public string WeaponName
    {
        get
        {
            return _weaponName;
        }
    }

    public void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetObjectForType(_rocket.name, false);
        bullet.transform.position = _muzzle.position;
        bullet.transform.rotation = _muzzle.rotation;
    }
}