using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private float _bombCooldownTime;
    [SerializeField] private float _bombDropPower;
    [SerializeField] private Transform _bombSpawnPoint;
    [SerializeField] private ParticleSystem _flashStrike;

    private float _elapsedTime;
    private Rigidbody _bombRigidBody;

    private void Start()
    {
        _elapsedTime = 0f;
        _flashStrike.Stop();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    public void FlashAttack()
    {
        _flashStrike.Play();
    }

    public void DropBomb()
    {
        if (_elapsedTime >= _bombCooldownTime)
        {
            _elapsedTime = 0f;
            GameObject bomb = Instantiate(_bombPrefab, _bombSpawnPoint.transform.position, Quaternion.identity);
            bomb.SetActive(true);
            _bombRigidBody = bomb.GetComponent<Rigidbody>();
            _bombRigidBody.AddForce(Vector3.up + Vector3.right * _bombDropPower);
        }
    }
}
