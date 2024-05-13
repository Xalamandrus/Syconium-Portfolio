using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoSingleton<ObjectPooling>
{
    private List<GameObject> _pooledObjects = new List<GameObject>();
    [SerializeField] private int _objectCount;

    [SerializeField] private GameObject _treePrefab;

    private void Start()
    {
        for (int i = 0; i < _objectCount; i++)
        {
            GameObject obj = Instantiate(_treePrefab, gameObject.transform);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        return null;
    }

    public List<GameObject> Get_PooledObjects => _pooledObjects;
}
