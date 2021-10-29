using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private Image _healthBar;
    private float _healthOffset;
    private PlayerHealth _playerHealth;
    // use this for initialization
    void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _healthOffset = _playerHealth.PHealth;
    }

    // Update is called once per frame 
    void Update()
    {
        _healthBar.fillAmount = _playerHealth.PHealth / _healthOffset;
    }
}