using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStrike : MonoBehaviour
{

    [SerializeField] private int _damage;
    
    private Vector3 _startPosition;
    private Vector3 _currentPosition;
    private EnergyStrike _energyStrike;
    public int Damage => _damage;
    
    private void Start()
    {
        _energyStrike = GetComponent<EnergyStrike>();
        _startPosition = new Vector3(_energyStrike.transform.position.x, _energyStrike.transform.position.y, _energyStrike.transform.position.z);
    }

    private void Update()
    {
        _currentPosition = _energyStrike.transform.position;

        if (_currentPosition.x - _startPosition.x > 20)
            Destroy(gameObject);
    }
}
