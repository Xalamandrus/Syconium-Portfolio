using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsArea : MonoSingleton<PointsArea>
{
    [SerializeField] private float _minDistance = -20f;
    [SerializeField] private float _maxDistance = 20f;

    private List<Vector3> _points = new List<Vector3>();
    [SerializeField] private int _pointsCount = 10;
    [SerializeField] private int _distance = 10;

    private void Start()
    {
        while (_points.Count < _pointsCount)
        {
            float randomX = Random.Range(_minDistance, _maxDistance);
            float randomZ = Random.Range(_minDistance, _maxDistance);

            Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);

            bool validPosition = true;

            foreach (Vector3 point in _points)
            {
                if (Vector3.Distance(randomPosition, point) < _distance)
                {
                    validPosition = false;
                    break;
                }
            }

            if (validPosition)
            {
                _points.Add(randomPosition);
            }
        }
    }

    private void OnDrawGizmos()
    {
        foreach (Vector3 point in _points)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(point, 0.5f);
        }
    }

    public List<Vector3> Get_Points => _points;
}