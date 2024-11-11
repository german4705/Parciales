using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPatrol : MonoBehaviour

   
{
    public List<GameObject> waypoints = new List<GameObject>();
    private int currentWaypointIndex = 0;
    public float rotationSpeed;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Verificamos que haya waypoints en la lista
        if (waypoints.Count == 0) return;

        // Referencia al waypoint actual
        Transform targetWaypoint = waypoints[currentWaypointIndex].transform;

        // Calcular dirección hacia el waypoint
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        // Rotar gradualmente hacia el waypoint para que el forward apunte a él
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Mover hacia adelante en la dirección actual del forward
        transform.position += transform.forward * speed * Time.deltaTime;

        // Comprobar si hemos llegado al waypoint actual
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Cambiar al siguiente waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
    }
}

