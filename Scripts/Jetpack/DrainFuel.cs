using UnityEngine;
using System.Collections;

public class DrainFuel : MonoBehaviour
{
    private bool _isDrainingFuel = false;
    public bool IsDrainingFuel
    {
        get
        {
            return _isDrainingFuel;
        }
        set
        {
            _isDrainingFuel = value;
        }
    }
    private JetpackFuel _jetpackFuel;

    [SerializeField]private float _drainRate = 0.1f;
    [SerializeField]private float _drainAmount;

	// Use this for initialization
	void Start()
	{
        _jetpackFuel = GetComponent<JetpackFuel>();
	}
	
	// Update() is called once per frame
	void Update()
	{
        if (!_isDrainingFuel && _jetpackFuel.IsUsingJetpack)
        {
            StartCoroutine(DrainTheFuel());
        }
	}

    IEnumerator DrainTheFuel()
    {
        _isDrainingFuel = true;
        while (_isDrainingFuel)
        {
            yield return new WaitForSeconds(_drainRate);
            _jetpackFuel.Fuel -= _drainAmount;
        }
    }
}