using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour 
{
    [SerializeField]private Image _fuelBar;
    private float _fuelOffset;
    private JetpackFuel _jetPackFuel;
    // use this for initialization
    void Start()
    {
        _jetPackFuel = GetComponent<JetpackFuel>();
        _fuelOffset = _jetPackFuel.Fuel;
    }

    // Update is called once per frame 
    void Update()
    {
        _fuelBar.fillAmount = _jetPackFuel.Fuel / _fuelOffset;
    }
}