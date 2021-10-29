using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour 
{
    private PlayerData _playerData;
    [SerializeField]private GameObject[] _players;
    private CharacterSelectInput[] _playersInput;
    [SerializeField]private int _activePlayers;
    public int ActivePlayers
    {
        get { return _activePlayers; }
        set { _activePlayers = value; }
    }
    [SerializeField]private int _readyPlayers;
    public int ReadyPlayers
    {
        get { return _readyPlayers; }
        set { _readyPlayers = value; }
    }
    [SerializeField]private Text _readyText;
	
    void Start()
    {
        _readyText.enabled = false;
        _playerData = GameObject.Find("DataObject").GetComponent<PlayerData>();
        _playersInput = new CharacterSelectInput[4];
        for (int i = 0; i < _players.Length; i++)
        {
            _playersInput[i] = _players[i].GetComponent<CharacterSelectInput>();
        }
    }
    
    void Update () 
    {
        CheckForReadyPlayers();
	}

    void CheckForReadyPlayers()
    {
        if(_activePlayers == 1)
        {
            _readyText.enabled = true;
            _readyText.text = "NEED ATLEAST 2 PLAYERS TO START!";
        }
        else if(_activePlayers >= 2)
        {
            _readyText.text = "PRESS START TO READY UP!";
        }

        if(_readyPlayers >= 2 && _readyPlayers == _activePlayers)
        {
            _playerData.PlayerAmount = _readyPlayers;
            SceneManager.LoadScene(SceneNames.MAINSCENE);
        }
    }
}
