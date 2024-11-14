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
    public LayerMask wallLayer;
    List<EnemyFOV> enemies = GameManager.Instance.enemiesFOV;
    public Patrol(EnemyFOV _enemyFOV, List<Transform> _waypoints, float _speed,float _rotationSpeed, LayerMask _wallLayer)
    {
        enemy = _enemyFOV;
        speed = _speed;
        waypoints = _waypoints;
        rotationSpeed = _rotationSpeed;
        wallLayer = _wallLayer;
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
        //foreach (var enemyFOV in enemies)
        //{
        if (enemy.IsPlayerInSight())
        {
            
            fsm.ChangeState(EnemyState.Follow);
            // aca esta el problema. 
            
            //foreach (var enemyFov in enemies)
            //{
            //    if (enemyFov != enemy) 
            //    {
            //        fsm.ChangeState(EnemyState.AlertEnemies);
            //    }
            //}
        }

        else
        { 
       

               
                   if(Insigth(enemy.transform.position, waypoints[currentWaypointIndex].transform.position))
                   {
                      Debug.DrawLine(enemy.transform.position, waypoints[currentWaypointIndex].transform.position);

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

       


        //}
    }

    public bool Insigth(Vector3 start, Vector3 end) // que vea el primer waypoint de patrullaje.
    {
        return !Physics.Raycast(start, end - start, Vector3.Distance(start, end), wallLayer);
    }
}







