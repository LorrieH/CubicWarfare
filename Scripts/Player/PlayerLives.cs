using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {

    [SerializeField]private GameObject _respawnManager;
    private PlayerRespawn _playerRespawn;
    private LifeImage lifeImage;
    [SerializeField]private int _lives = 5;
    private Vector3 _spawnPosition;
    public Vector3 SpawnPosition
    {
        get{ return _spawnPosition; }
        set{ _spawnPosition = value; }
    }

    void Awake()
    {
        GameObject parentObject = Instantiate(_respawnManager, transform.position, transform.rotation) as GameObject;
        transform.parent = parentObject.transform;
        lifeImage = GetComponent<LifeImage>();
        _playerRespawn = parentObject.gameObject.GetComponent<PlayerRespawn>();
    }

    public void RemoveLives()
    {
        if (_lives > 0)
        {
            lifeImage.CutLives();
            _playerRespawn.IsDead = true;
            _lives -= 1;
        }
        else
        {
            _lives -= 1;
            Destroy(this.gameObject);
        }    
    }
}
