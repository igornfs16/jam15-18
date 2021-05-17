using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnergyStrike energyStrike))
        {
            _enemy.ApplyDamage(energyStrike.Damage);
        }
    }
}
