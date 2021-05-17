using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject[] prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomPrefapIndex = Random.Range(0, prefab.Length);
            GameObject spawned = Instantiate(prefab[randomPrefapIndex], _container.transform.position, Quaternion.identity);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetEnemy(out GameObject result)
    {
        result = _pool.FirstOrDefault(enemy => enemy.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadCamera()
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                Vector3 point = _camera.WorldToViewportPoint(item.transform.position);
                
                if (point.x < -2)
                {
                    item.SetActive(false);
                }
            }
        }
    }
}
