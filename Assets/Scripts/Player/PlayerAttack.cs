﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private float _dropPower;

    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private float _bombCooldownTime;
    [SerializeField] private float _dropPower;
    [SerializeField] private Transform _bombSpawnPoint;



    private Rigidbody _energyStrikeRigidBody;

    private void Start()
    {
        _flashStrike.Stop();
    }

    public void FlashAttack()
    {
        GameObject energyStrike = Instantiate(_energyStrikePrefab, _energyStrikeSpawnPoint.transform.position, Quaternion.identity);
        energyStrike.SetActive(true);
        _energyStrikeRigidBody = energyStrike.GetComponent<Rigidbody>();
        _energyStrikeRigidBody.AddForce(Vector3.right * _dropPower);
        _flashStrike.Play();
    }

}
