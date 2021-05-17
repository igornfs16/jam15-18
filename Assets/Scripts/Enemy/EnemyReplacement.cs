using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyReplacement : MonoBehaviour
{
    [SerializeField] private GameObject _currentObject;
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private ParticleSystem _replaceEffect;


    private void Start()
    {
        _currentObject.SetActive(true);
        _targetObject.SetActive(false);
    }

    public void ReplaceEnemy()
    {
        GetComponent<BoxCollider>().enabled = false;
        _replaceEffect.Play();
        _currentObject.SetActive(false);
        _targetObject.SetActive(true);
    }
}
