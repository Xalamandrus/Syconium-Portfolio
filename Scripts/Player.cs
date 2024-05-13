using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerRenderDistance : MonoBehaviour
{
    [SerializeField] private float _checkDistance = 20f;

    private List<Vector3> _usedPoints = new List<Vector3>();

    private void Update()
    {
        Distance();
    }

    private void Distance()
    {
        foreach (Vector3 point in PointsArea.Instance.Get_Points)
        {
            if (!_usedPoints.Contains(point))
            {
                float distanceToPlayer = Vector3.Distance(transform.position, point);

                if (distanceToPlayer < _checkDistance)
                {
                    DistanceTreeRender(point);
                    _usedPoints.Add(point);
                }
            }
        }

        foreach (GameObject tree in ObjectPooling.Instance.Get_PooledObjects)
        {
            if (tree.activeSelf)
            {
                float distanceToTree = Vector3.Distance(transform.position, tree.transform.position);

                if (distanceToTree >= _checkDistance)
                {
                    tree.SetActive(false);

                    Vector3 treePosition = new Vector3(tree.transform.position.x, 0f, tree.transform.position.z);
                    _usedPoints.Remove(treePosition);
                    PointsArea.Instance.Get_Points.Add(treePosition);
                }
            }
        }
    }

    private void DistanceTreeRender(Vector3 pointPosition)
    {
        GameObject tree = ObjectPooling.Instance.GetPooledObject();

        if (tree != null)
        {
            tree.transform.position = pointPosition;
            tree.SetActive(true);
        }
    }
}
