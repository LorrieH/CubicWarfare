using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    private PlayerGroundCollisionChecker2D _cc2d;
    private PlayerMovement _playerMovement;
    private JetpackFuel _jetpackFuel;
    private DrainFuel _drainFuel;
    private RechargeFuel _rechargeFuel;
	// Use this for initialization
	void Start()
	{
		_cc2d = GetComponent<PlayerGroundCollisionChecker2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _jetpackFuel = GetComponent<JetpackFuel>();
        _drainFuel = GetComponent<DrainFuel>();
        _rechargeFuel = GetComponent<RechargeFuel>();
	}
	
	// Update() is called once per frame
	void Update()
	{
        if (Input.GetButtonDown("Xbox_LB_" + _playerMovement.PlayerID) && _cc2d.CanJump)
        {
            _playerMovement.Jump();
        }

        if (Input.GetAxis("Xbox_RT_" + _playerMovement.PlayerID) > 0.25f)
        {
            _playerMovement.Shoot();
        }

        if (Input.GetAxis("Xbox_LT_" + _playerMovement.PlayerID) > 0.25f && _jetpackFuel.Fuel > 0 )
        {
            _playerMovement.Jetpack();
            _jetpackFuel.IsUsingJetpack = true;
            _rechargeFuel.IsRecharging = false;
        }
        else 
        {
            _drainFuel.IsDrainingFuel = false;
            _jetpackFuel.IsUsingJetpack = false;
        }
	}
}