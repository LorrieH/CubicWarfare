using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    private int _playerAmount;
    public int PlayerAmount
    {
        get { return _playerAmount; }
        set { _playerAmount = value; }
    }

    [SerializeField]private int _player1WeaponID;
    public int Player1WeaponID
    {
        get { return _player1WeaponID; }
    }

    [SerializeField]private int _player2WeaponID;
    public int Player2WeaponID
    {
        get { return _player2WeaponID; }
    }

    [SerializeField]private int _player3WeaponID;
    public int Player3WeaponID
    {
        get { return _player3WeaponID; }
    }
   
    [SerializeField]private int _player4WeaponID;
    public int Player4WeaponID
    {
        get { return _player4WeaponID; }
    }

	void Start () 
    {
        DontDestroyOnLoad(gameObject);
	}

    public void SetData(int playerID, int weaponID)
    {
        switch (playerID)
        {
            case 1:
                _player1WeaponID = weaponID;
                break;
            case 2:
                _player2WeaponID = weaponID;
                break;
            case 3:
                _player3WeaponID = weaponID;
                break;
            case 4:
                _player4WeaponID = weaponID;
                break;
        }

    }
}
