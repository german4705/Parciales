using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBackToPatrol : State
{
    public LayerMask wallLayer;
    public List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    public EnemyFOV enemy;
    private float speed = 5;
    public LineBackToPatrol(LayerMask _wallLayer, List<Transform> _waypoints, EnemyFOV _enemy)
    {
        wallLayer = _wallLayer;
        waypoints = _waypoints;
        enemy = _enemy;
    }
    public override void OnEnter()
    {
        Debug.Log("Entrando a LineBackToPatrol");
    }

    public override void OnExit()
    {
        Debug.Log("saliendo de LineBackToPatrol ");
    }

    public override void OnUpdate()
    {
        Debug.Log("buscando el nodo con la vision");
        if (Insigth(enemy.transform.position, waypoints[currentWaypointIndex].transform.position))
        {
            Debug.DrawLine(enemy.transform.position, waypoints[currentWaypointIndex].transform.position);
            if (waypoints.Count == 0) return;

            // Referencia al waypoint actual
            Transform targetWaypoint = waypoints[currentWaypointIndex].transform;

            // Calcular dirección hacia el waypoint
            Vector3 direction = (targetWaypoint.position - enemy.transform.position).normalized;

            // Rotar gradualmente hacia el waypoint para que el forward apunte a él
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, lookRotation, enemy.rotationSpeed * Time.deltaTime);

            // Mover hacia adelante en la dirección actual del forward
            enemy.transform.position += enemy.transform.forward * speed * Time.deltaTime;

            //Comprobar si hemos llegado al waypoint actual
            if (Vector3.Distance(enemy.transform.position, targetWaypoint.position) < 0.5f)
            {
                // Cambiar al siguiente waypoint
                fsm.ChangeState(EnemyState.Patrol);
            }
        }else
        {
            fsm.ChangeState(EnemyState.PathBackToPatrol);
        }
    }

    public bool Insigth(Vector3 start, Vector3 end)
    {
        return !Physics.Raycast(start, end - start, Vector3.Distance(start, end), wallLayer);
    }
}
