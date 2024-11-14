using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPahtFinding : State
{
    [SerializeField] LayerMask wallLayer;

    public PathFinding pf;
    public List<Transform> waypoints;
    public List<EnemyFOV> enemiesFOV;
    public EnemyPath enemyPath;
    public Player player;
    private EnemyFOV enemyFov;
    List<Node> nodes = GameManager.Instance.nodes;
    public AlertPahtFinding (PathFinding _pf, List<Transform> _waypoints, List<EnemyFOV> _enemies, EnemyPath _enemyPath, Player _player, EnemyFOV _enemy)
    {
        pf = _pf;
        waypoints = _waypoints;
        enemiesFOV = _enemies;
        enemyPath = _enemyPath;
        player = _player;
        enemyFov = _enemy;
    }

    public override void OnEnter()
    {
        pf = new PathFinding();
        AlertEnemies();
        Debug.Log("Entrando Enemigos alerta");
        Debug.Log("Yendo a la ultima posicion del player");
    }

    public override void OnExit()
    {
        Debug.Log("Saliendo de Enemigos alerta");
    }

    public override void OnUpdate()
    {
        
        
        Node playerNode = GameManager.Instance.GetNearestNode(player.transform.position, nodes);
        if (Vector3.Distance(enemyPath.transform.position, playerNode.transform.position) < 0.5f)
        {
            fsm.ChangeState(EnemyState.PathBackToPatrol);
        }
        //if(enemyFov.IsPlayerInSight()) // si lo ve follow
        //  {
        //      fsm.ChangeState(EnemyState.Follow);
        //  }
        // else
        // {
        //     fsm.ChangeState(EnemyState.PathBackToPatrol); // si no lo ve, astar hasta el nodo de patrol
        // }

    }

    public void AlertEnemies()
    {
        

        Node playerNode = GameManager.Instance.GetNearestNode(player.transform.position, nodes);

        Node nearestNode = GameManager.Instance.GetNearestNode(enemyPath.transform.position, nodes);


        List<Node> path = pf.AStar(nearestNode, playerNode);



        enemyPath.GetPath(path);
        enemyPath.FollowPath();

        foreach (EnemyFOV enemy in enemiesFOV)
        {
             

            //if (!enemy.IsPlayerInSight())
            //{
            //    if (pf == null)
            //    {
            //        Debug.LogError("PathFinding instance (pf) is null.");
            //        return;
            //    }


               
            //}
               
        }
           


    }
    private void AlertOtherEnemies()
    {


        //foreach (EnemyFOV enemy in enemiesFOV)
        //{
        //    if (!enemy.IsPlayerInSight()) // Excluye al enemigo que detectó al jugador
        //    {
        //        Debug.Log("Todos alerta");
        //        AlertEnemies();
        //    }
        //}
    }

}
