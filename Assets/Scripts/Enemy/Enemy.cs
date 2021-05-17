using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    private EnemyReplacement _target;

    private void Start()
    {
        _target = GetComponent<EnemyReplacement>();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if (_health < 0)
            _target.ReplaceEnemy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnergyStrike energyStrike))
            ApplyDamage(energyStrike.Damage);
    }
}
