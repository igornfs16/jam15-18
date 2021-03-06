using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Enemy enemy))

            _player.Die();
    }
}
