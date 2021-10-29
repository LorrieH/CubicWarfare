using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Win_Loss : MonoBehaviour
{
    [SerializeField]private List<GameObject> _players = new List<GameObject>();
    private int _playerID;
	// Use this for initialization
	void Start()
	{
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            _players.Add(player);
        }
        
        
	}
	
	// Update() is called once per frame
	void Update()
	{
        for (int i = 0; i < _players.Count; i++)
        {
            if(_players[i] == null)
            {
                _players.RemoveAt(i);
            }
        }

		if(_players.Count == 1)
        {
            _playerID = _players[0].GetComponent<PlayerMovement>().PlayerID;
            PlayerPrefs.SetInt("PlayerWon", _playerID);
            SceneManager.LoadScene(SceneNames.VICTORYSCENE);
        }

	}
}