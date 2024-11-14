using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPatrol : State
{
    [SerializeField] LayerMask wallLayer;

    public PathFinding pf;
    public List<Transform> waypoints;
    public List<EnemyFOV> enemiesFOV;
    public EnemyPath enemyPath ;
    public BackToPatrol(PathFinding _pf, List<Transform> _waypoints,  List<EnemyFOV> _enemies,EnemyPath _enemyPath )
    {
        pf = _pf;
        waypoints = _waypoints;
        enemiesFOV = _enemies;
        enemyPath = _enemyPath;
    }
   

    public override void OnEnter()
    {
        pf = new PathFinding();
        
        Debug.Log("Entrando del estado de backtopatrol");
        BackToNode();
        
    }

    public override void OnExit()
    {
        Debug.Log("saliendo del estado de backtopatrol");
    }

    public override void OnUpdate()
    {
        Debug.Log("volviendo al Node por path");
        Node patrolNode = waypoints[0].GetComponent<Node>();
        if (Vector3.Distance(enemyPath.transform.position, patrolNode.transform.position) < 0.5f)
        {
            fsm.ChangeState(EnemyState.Patrol);
        }
    }

    public bool Insigth(Vector3 start, Vector3 end)
    {
        return !Physics.Raycast(start, end - start, Vector3.Distance(start, end), wallLayer);
    }

   
    public void BackToNode()
    {
        

        Node patrolNode = waypoints[0].GetComponent<Node>();
        List<Node> nodes = GameManager.Instance.nodes;

       

        Node nearestNode = GameManager.Instance.GetNearestNode(enemyPath.transform.position, nodes);
        

        List<Node> path = pf.AStar(nearestNode, patrolNode);

       

        enemyPath.GetPath(path);
        enemyPath.FollowPath();

        
    }



}
