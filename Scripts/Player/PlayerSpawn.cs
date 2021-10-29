using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSpawn : MonoBehaviour {

    private PlayerData _playerData;
    [SerializeField]private GameObject _playerPrefab;
    [SerializeField]private Transform[] _playerSpawns;
    [SerializeField]private Sprite[] _playerSprites;
    [SerializeField]private Image[] _playerLives;

	void Start () 
    {
        _playerData = GameObject.Find("DataObject").GetComponent<PlayerData>();

        for (int i = 0; i <= _playerData.PlayerAmount -1; i++)
        {
            GameObject player = Instantiate(_playerPrefab, _playerSpawns[i].position, Quaternion.identity) as GameObject;
            SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            PlayerAim playerAim = player.GetComponentInChildren<PlayerAim>();
            PlayerWeapon playerWeapon = player.GetComponent<PlayerWeapon>();
            LifeImage lifeImage = player.GetComponent<LifeImage>();
            PlayerLives playerLives = player.GetComponent<PlayerLives>();
            switch(i)
            {
                case 0:
                    playerSprite.sprite = _playerSprites[i];
                    playerMovement.PlayerID = 1;
                    playerAim.PlayerID = 1;
                    lifeImage.Lives = _playerLives[i];
                    playerWeapon.WeaponIndex = _playerData.Player1WeaponID;
                    playerLives.SpawnPosition = _playerSpawns[i].position;
                    break;
                case 1:
                    playerSprite.sprite = _playerSprites[i];
                    playerMovement.PlayerID = 2;
                    playerAim.PlayerID = 2;
                    lifeImage.Lives = _playerLives[i];
                    playerWeapon.WeaponIndex = _playerData.Player2WeaponID;
                    playerLives.SpawnPosition = _playerSpawns[i].position;
                    break;
                case 2:
                    playerSprite.sprite = _playerSprites[i];
                    playerMovement.PlayerID = 3;
                    playerAim.PlayerID = 3;
                    lifeImage.Lives = _playerLives[i];
                    playerWeapon.WeaponIndex = _playerData.Player3WeaponID;
                    playerLives.SpawnPosition = _playerSpawns[i].position;
                    break;
                case 3:
                    playerSprite.sprite = _playerSprites[i];
                    playerMovement.PlayerID = 4;
                    playerAim.PlayerID = 4;
                    lifeImage.Lives = _playerLives[i];
                    playerWeapon.WeaponIndex = _playerData.Player4WeaponID;
                    playerLives.SpawnPosition = _playerSpawns[i].position;
                    break;
            }
            
            
        }
	}
}