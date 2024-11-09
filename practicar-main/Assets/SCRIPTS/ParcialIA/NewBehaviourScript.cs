using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public List<GameObject> waypoints; // Lista de waypoints para la patrulla
    public float speed = 2f; // Velocidad de movimiento entre waypoints
    public float rotationSpeed = 5f; // Velocidad de rotación para mirar hacia el waypoint

    private int currentWaypointIndex = 0; // Índice del waypoint actual

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
