using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnableLifeImages : MonoBehaviour {

    [SerializeField]private Image[] lives;

    void Awake()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = false;
        }

        PlayerData _playerData = GameObject.Find("DataObject").GetComponent<PlayerData>();

        for (int i = 0; i <= _playerData.PlayerAmount - 1; i++)
        {
            lives[i].enabled = true;
        }
    }

}