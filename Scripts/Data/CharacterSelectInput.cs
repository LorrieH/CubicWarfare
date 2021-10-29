using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelectInput : MonoBehaviour {
    [SerializeField]private int _playerID;
    public int PlayerID{ get { return _playerID; } }
    [SerializeField]private bool _playerActive;
    public bool PlayerActive{ get { return _playerActive; } }
    [SerializeField]private bool _playerReady;
    public bool PlayerReady { get { return _playerReady; } }
    [SerializeField]private int _currentWeaponIndex;
    [SerializeField]private Sprite[] _weapons;

    private PlayerData _playerData;

    private CharacterSelect _characterSelect;


    [SerializeField]private GameObject _beginPanel;
    [SerializeField]private Image _readyImage;
    private Image _currentWeaponImage;

    void Start()
    {
        _playerData = GameObject.Find("DataObject").GetComponent<PlayerData>();
        _characterSelect = GameObject.Find("CharacterSelectManager").GetComponent<CharacterSelect>();
        _currentWeaponImage = GameObject.Find("CurrentWeaponImage" + _playerID).GetComponent<Image>();
        _readyImage.enabled = false;
        SetWeaponText();

    }

	void Update () 
    {
        if (!_playerActive)
        {
            if (Input.GetButtonDown("Xbox_Button_A_" + _playerID))
            {
                _playerActive = true;
                _beginPanel.SetActive(false);
                _characterSelect.ActivePlayers++;
            }
        }
        if (_playerActive)
        {
            if (Input.GetButtonDown("Xbox_Button_Y_" + _playerID) && !_playerReady)
            {
                NextWeapon();
            }
            if (Input.GetButtonDown("Xbox_Button_Start_" + _playerID))
            {
                ToggleReady();
                _playerData.SetData(_playerID, _currentWeaponIndex);
            }
        }

	}

    void NextWeapon()
    {
        if(_currentWeaponIndex >= _weapons.Length -1)
        {
            _currentWeaponIndex = 0;
        }
        else
        {
            _currentWeaponIndex++;
        }
        SetWeaponText();
    }

    void ToggleReady()
    {
        _playerReady = !_playerReady;
        if(_playerReady)
        {
            _characterSelect.ReadyPlayers++;
            _readyImage.enabled = true;
        }
        else if(!_playerReady)
        {
            _characterSelect.ReadyPlayers--;
            _readyImage.enabled = false;
        }
    }

    void SetWeaponText()
    {
        _currentWeaponImage.sprite = _weapons[_currentWeaponIndex];
    }
}
