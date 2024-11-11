using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    public List<Transform> waypoints; // Lista de waypoints para la patrulla
    public float speed = 2f; // Velocidad de movimiento entre waypoints

    private int currentWaypointIndex = 0; // Índice del waypoint actual
    private EnemyFOV enemy;
    public float rotationSpeed;
    // Constructor
    public Patrol(EnemyFOV _enemyFOV, List<Transform> _waypoints, float _speed,float _rotationSpeed)
    {
        enemy = _enemyFOV;
        speed = _speed;
        waypoints = _waypoints;
        rotationSpeed = _rotationSpeed;
    }

    public override void OnEnter()
    {
        Debug.Log("Entrando en el estado de patrullaje.");
    }

    public override void OnExit()
    {
        Debug.Log("Saliendo del estado de patrullaje.");
    }

    public override void OnUpdate()
    {
        if (waypoints.Count == 0) return;

        
        Transform targetWaypoint = waypoints[currentWaypointIndex].transform;

        
        Vector3 direction = (targetWaypoint.position - enemy.transform.position).normalized;

        
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, lookRotation, enemy.rotationSpeed * Time.deltaTime);

        
        enemy.transform.position += enemy.transform.forward * speed * Time.deltaTime;

        
        if (Vector3.Distance(enemy.transform.position, targetWaypoint.position) < 0.05f)
        {
            
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
    }
}







