using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class WinScreen : MonoBehaviour
{
    [SerializeField]private Text _wonText;
    [SerializeField]private Image _wonImage;
    [SerializeField]private Sprite[] _playerSprites;
	// Use this for initialization
	void Start()
	{
        _wonText.text = "Player: " + PlayerPrefs.GetInt("PlayerWon");

        switch(PlayerPrefs.GetInt("PlayerWon"))
        {
            case 1:
                _wonImage.sprite = _playerSprites[0];
                break;
            case 2:
                _wonImage.sprite = _playerSprites[1];
                break;
            case 3:
                _wonImage.sprite = _playerSprites[2];
                break;
            case 4:
                _wonImage.sprite = _playerSprites[3];
                break;
        }
	}

    void Update()
    {
        if(Input.GetButtonDown("Xbox_Button_A_all"))
        {
            SceneManager.LoadScene(SceneNames.CHARACTERSELECTIONSCENE);
        }
    }
}