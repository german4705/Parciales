using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    private List<Node> _path = new List<Node>();
    public float speed;

    public void GetPath(List<Node> path)
    {
        _path = path;
    }

    public void FollowPath()
    {
        if (_path == null || _path.Count == 0) return;

        Vector3 direction = _path[0].transform.position - transform.position;

        if (direction.magnitude < 0.5f) // Si estamos cerca del nodo actual, pasa al siguiente
        {
            _path.RemoveAt(0);
        }

        transform.position += direction.normalized * speed * Time.deltaTime; // Mueve al enemigo hacia el nodo
    }


    private void Update()
    {
        FollowPath();
    }
}
