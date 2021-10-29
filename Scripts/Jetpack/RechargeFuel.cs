using UnityEngine;
using System.Collections;

public class RechargeFuel : MonoBehaviour
{
    private bool _isRecharging = true;
    public bool IsRecharging
    {
        set
        {
            _isRecharging = value;
        }
    }
    private JetpackFuel _jetpackFuel;

    [SerializeField]private float _rechargeRate = 0.1f;
    [SerializeField]private float _rechargeAmount;

    // Use this for initialization
    void Start()
    {
        _jetpackFuel = GetComponent<JetpackFuel>();
    }

    // Update() is called once per frame
    void Update()
    {
        if (!_isRecharging && !_jetpackFuel.IsUsingJetpack)
        {
            StartCoroutine(RechargeTheFuel());
        }
    }

    IEnumerator RechargeTheFuel()
    {
        _isRecharging = true;
        while (_isRecharging)
        {
            yield return new WaitForSeconds(_rechargeRate);
            _jetpackFuel.Fuel += _rechargeAmount;
        }
    }
}