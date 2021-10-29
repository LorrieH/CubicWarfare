using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
    [SerializeField]private GameObject _gun;

    private float _reloadTime;
    [SerializeField]private float _shotgunReloadTime;
    [SerializeField]private float _machinegunReloadTime;
    [SerializeField]private float _rocketLauncherReloadTime;
    [SerializeField]private float _knockbackAmount;

    private bool _canShoot = true;

    private Rigidbody2D _playerRigidbody;
    private AudioSource _shootSound;
    private PlayerWeapon _playerWeapon;

    void OnEnable()
    {
        _canShoot = true;
    }

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _shootSound = _gun.GetComponent<AudioSource>();
        _playerWeapon = GetComponent<PlayerWeapon>();
        
        switch(_playerWeapon.WeaponIndex)
        {
            case 0:
                _reloadTime = _shotgunReloadTime;
                break;
            case 1:
                _reloadTime = _machinegunReloadTime;
                break;
            case 2:
                _reloadTime = _rocketLauncherReloadTime;
                break;
        }
    }

    public IEnumerator Shoot()
    {
        if (_canShoot)
        {
            _playerWeapon.CurrentWeapon.Shoot();

            _shootSound.pitch = Random.Range(.75f, 1.25f);
            _shootSound.Play();

            Knockback();
            _canShoot = false;
            yield return new WaitForSeconds(_reloadTime);
            _canShoot = true;
        }
    }

    private void Knockback()
    {
        Vector3 direction = transform.position - _gun.transform.position;
        _playerRigidbody.AddForce(direction * _knockbackAmount, ForceMode2D.Impulse);
    }

}
