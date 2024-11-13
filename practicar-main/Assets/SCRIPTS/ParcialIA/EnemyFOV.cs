using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{

    FiniteStateMachine fsm;
    [SerializeField] float viewRadius;
    [SerializeField] float viewAngle;

    [SerializeField] Player player;
    public LayerMask wallLayer;



    //constructor del patrol
    public List<Transform> waypoints;
    public float patrolSpeed = 2f;
    public float rotationSpeed;

    public List<EnemyFOV> enemiesFOV = new List<EnemyFOV>();

    //contructor de backtopatrol
    public PathFinding _pf;
    public EnemyPath enemypath;
    void Start()
    {
        fsm = new FiniteStateMachine();
        fsm.AddState(EnemyState.Patrol, new Patrol(this, waypoints, patrolSpeed, rotationSpeed,wallLayer));
        fsm.AddState(EnemyState.Follow, new Follow(player,this,patrolSpeed,rotationSpeed));
        fsm.AddState(EnemyState.PathBackToPatrol, new BackToPatrol(_pf,waypoints,enemiesFOV, enemypath));
        fsm.AddState(EnemyState.LinePathToPatrol,new LineBackToPatrol(wallLayer, waypoints,this));
        fsm.AddState(EnemyState.AlertEnemies, new AlertPahtFinding(_pf, waypoints, enemiesFOV, enemypath, player, this));
        fsm.ChangeState(EnemyState.Patrol);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.Update();
       
    }

    public bool IsPlayerInSight()
    {
        return fieldOfView(player);
    }


    public bool fieldOfView(Player obj)
    {
        Vector3 dir = obj.transform.position - transform.position;

        if (dir.magnitude < viewRadius)
        {
            Debug.DrawLine(transform.position, obj.transform.position, Color.red);

            if (Vector3.Angle(transform.forward, dir) < viewAngle / 2)
            {
                if (!Physics.Raycast(transform.position, dir, dir.magnitude, wallLayer))
                {
                    Debug.DrawLine(transform.position, obj.transform.position, Color.blue);
                    return true;

                }


            }

        }
        return false;
    }

    //public void FollowPlayer(Vector3 playerPosition)
    //{
    //    Vector3 direction = playerPosition - transform.position;
    //    transform.position += direction.normalized * patrolSpeed * Time.deltaTime;
    //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
    //}

    //public void StopFollowingPlayer()
    //{
    //    //fsm.ChangeState(EnemyState.BackToPatrol); // Volvemos al estado de patrulla si no tiene al jugador en visión
    //}



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 LineA = GetVectorFromAngle(viewAngle / 2 + transform.eulerAngles.y);
        Vector3 LineB = GetVectorFromAngle(-viewAngle / 2 + transform.eulerAngles.y);

        Gizmos.DrawLine(transform.position, transform.position + LineA * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + LineB * viewRadius);
    }

    public Vector3 GetVectorFromAngle(float angle)
    {
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }
}
