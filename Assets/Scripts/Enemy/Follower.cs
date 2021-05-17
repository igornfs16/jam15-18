using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistance;

    void Update()
    {
        transform.LookAt(_target.transform);

        if (Vector3.Distance(transform.position, _target.transform.position) >= _minDistance)
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
