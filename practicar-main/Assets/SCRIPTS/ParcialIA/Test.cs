using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Test : MonoBehaviour
{
    public List<GameObject> waypoints; // Lista de waypoints para la patrulla
    public float speed = 2f; // Velocidad de movimiento entre waypoints
    public float rotationSpeed = 5f; // Velocidad de rotaci�n para mirar hacia el waypoint

    private int currentWaypointIndex = 0; // �ndice del waypoint actual

    public LayerMask wallLayer;

    public PathFinding _pf;
    public EnemyPath enemy;
    
    public bool Insigth(Vector3 start, Vector3 end)
    {
        return !Physics.Raycast(start, end - start, Vector3.Distance(start, end), wallLayer);
    }

    private void Start()
    {
        _pf = new PathFinding();

        BackToPatrol();

    }

    void Update()
    {



        //if (Insigth(transform.position, waypoints[currentWaypointIndex].transform.position))
        //{
        //    Debug.DrawLine(transform.position, waypoints[currentWaypointIndex].transform.position);
        //    if (waypoints.Count == 0) return;

        //    // Referencia al waypoint actual
        //    Transform targetWaypoint = waypoints[currentWaypointIndex].transform;

        //    // Calcular direcci�n hacia el waypoint
        //    Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        //    // Rotar gradualmente hacia el waypoint para que el forward apunte a �l
        //    Quaternion lookRotation = Quaternion.LookRotation(direction);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        //    // Mover hacia adelante en la direcci�n actual del forward
        //    transform.position += transform.forward * speed * Time.deltaTime;

        //    // Comprobar si hemos llegado al waypoint actual
        //    if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.5f)
        //    {
        //        // Cambiar al siguiente waypoint
        //        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        //    }
        //}
        //else
        //{


        //}

    }

    public void BackToPatrol()
           {
        Node Patrol = waypoints[0].GetComponent<Node>();
        List<Node> nodes = GameManager.Instance.nodes; // Obt�n la lista de nodos desde GameManager
        Node nearestNode = GameManager.Instance.GetNearestNode(transform.position, nodes);
        if (GameManager.Instance != null)
        {





            Debug.Log("Nodo m�s cercano enemigo: " + nearestNode);
            Debug.Log("Nodo m�s cercano patrol : " + Patrol);


            List<Node> path = _pf.AStar(nearestNode, Patrol);
            enemy.GetPath(path); // Asigna el camino hacia el nodo m�s cercano al jugador
            enemy.FollowPath(); // Mueve el enemigo hacia el siguiente nodo en el camino
        }

           }
        
       
       
    
}

