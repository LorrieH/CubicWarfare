using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField]private AudioClip _clip;
    [SerializeField]private float _respawnTime = 3;
    private GameObject _player;
    private PlayerLives _playerLives;
    private bool _isDead = false;
    public bool IsDead
    {
        set { _isDead = value; }
    }
    
	// Use this for initialization
	void Start()
	{
        _source = GetComponent<AudioSource>();
        _player = transform.GetChild(0).gameObject;
        _playerLives = _player.GetComponent<PlayerLives>();
	}

    void Update()
    {
        if(_isDead)
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        _isDead = false;
        _player.SetActive(false);
        yield return new WaitForSeconds(_respawnTime);
        _player.SetActive(true);
        _source.PlayOneShot(_clip);
        _player.transform.position = _playerLives.SpawnPosition;
        GameObject spawnParticles = ObjectPool.instance.GetObjectForType("SpawnParticles", true);
        spawnParticles.transform.position = _player.transform.position;
    }
}