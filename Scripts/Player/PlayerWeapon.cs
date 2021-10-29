using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour
{
    private IWeapon _currentWeapon;
    public IWeapon CurrentWeapon
    {
        get { return _currentWeapon; }
    }

    private int _currentWeaponIndex;
    public int WeaponIndex
    {
        get { return _currentWeaponIndex; }
        set { _currentWeaponIndex = value; }
    }
    private IWeapon[] _weapons;
	// Use this for initialization
	void Start()
	{
        _weapons = GetComponents<IWeapon>();
    }

    void Update()
    {
        CheckWhichWeapon();
    }

    void CheckWhichWeapon()
    {
        switch (_currentWeaponIndex)
        {
            case 0:
                _currentWeapon = _weapons[0];
                //shotgun
                break;
            case 1:
                _currentWeapon = _weapons[1];
                //machinegun
                break;
            case 2:
                _currentWeapon = _weapons[2];
                //rocketlauncher
                break;
        }
    }
}