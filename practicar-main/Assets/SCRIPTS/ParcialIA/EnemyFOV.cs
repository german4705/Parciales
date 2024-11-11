using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{

    FiniteStateMachine fsm;
    [SerializeField] float viewRadius;
    [SerializeField] float viewAngle;

    [SerializeField] GameObject player;
    [SerializeField] LayerMask wallLayer;

    //constructor del patrol
    public List<Transform> waypoints;
    public float patrolSpeed = 2f;
    public float rotationSpeed;

    void Start()
    {
        fsm = new FiniteStateMachine();
    }

    // Update is called once per frame
    void Update()
    {
        fsm.Update();
        fsm.AddState(EnemyState.Patrol, new Patrol(this, waypoints, patrolSpeed, rotationSpeed));
        fsm.ChangeState(EnemyState.Patrol);
    }

    public bool IsPlayerInSight()
    {
        return fieldOfView(player);
    }


    public bool fieldOfView(GameObject obj)
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

    public void FollowPlayer(Vector3 playerPosition)
    {
        Vector3 direction = playerPosition - transform.position;
        transform.position += direction.normalized * patrolSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
    }

    public void StopFollowingPlayer()
    {
        fsm.ChangeState(EnemyState.BackToPatrol); // Volvemos al estado de patrulla si no tiene al jugador en visión
    }



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
