using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _sideStepSize;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Player _player;
    [SerializeField] private int _maxZ;
    [SerializeField] private int _minZ;
    [SerializeField] private Rigidbody _rigidbody;

    private int _direction = 1;

    

    private void Start()
    {
        _player.transform.position = _startPosition;
        _rigidbody.velocity = new Vector3 (0f, 0f,0f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
       _player.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    private void MoveByZ(float direction)
    {
       _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z + _sideStepSize * direction);
    }

    public void MoveByZUp()
    {
        if (_player.transform.position.z < _maxZ)
            MoveByZ(_direction);
    }

    public void MoveByZDown()
    {
        if (_player.transform.position.z > _minZ)
            MoveByZ(-_direction);
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public float CurrentSpeed()
    {
        return _speed;
    }
}
