using UnityEngine;
using System.Collections;

public class JetpackFuel : MonoBehaviour 
{
    [SerializeField]private float _fuel = 200;
    public float Fuel
    {
        get
        {
            return _fuel;
        }
        set
        {
            _fuel = value;
        }
    }
    private float _maxFuel;
    private float _minFuel;

    private bool _isUsingJetpack = false;
    public bool IsUsingJetpack
    {
        get
        {
            return _isUsingJetpack;
        }
        set
        {
            _isUsingJetpack = value;
        }
    }
    

    void Start()
    {
        _maxFuel = _fuel;
        _minFuel = _fuel - _fuel;
    }

    void Update()
    {
        CheckMinMaxFuel();
    }

    void CheckMinMaxFuel()
    {
        if (_fuel > _maxFuel)
        {
            _fuel = _maxFuel;
        }
        else if (_fuel < _minFuel)
        {
            _fuel = _minFuel;
        }
    }
}