using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : State
{
    public Player player;
    public EnemyPath enemypath;
    public EnemyFOV enemifov;
    private float speed;
    private float rotationSpeed;
    List<Node> Nodes = GameManager.Instance.nodes;
    List<EnemyFOV> enemies = GameManager.Instance.enemiesFOV;


    public Follow(Player _player,EnemyFOV _enemyFOV,float _speed, float _rotation)
    {
        player = _player;
        enemifov = _enemyFOV;
        speed = _speed;
        rotationSpeed = _rotation;
    }

    public override void OnEnter()
    {
        Debug.Log("Entran al estado de persiguiendo");

        Node playerNode = GameManager.Instance.GetNearestNode(player.transform.position, Nodes);

        GameManager.Instance.AlertEnemies(playerNode);



    }

    public override void OnExit()
    {
        Debug.Log("Saliendo del estado de persiguiendo");
    }

    public override void OnUpdate()
    {
        if(enemifov.IsPlayerInSight())
        {
           
            FollowPlayer(player.transform.position);
            
            
        }
        else
        {
            fsm.ChangeState(EnemyState.Patrol);
        }

        
        //bool isAnyEnemyAlerting = false;

        //foreach (var enemyFOV in enemies)
        //{


        //    GameManager.Instance.AlertEnemiesWithoutSight(playerNode);



        //}

        //if (isAnyEnemyAlerting)
        //{
        //    GameManager.Instance.AlertEnemiesWithoutSight(playerNode);
        //}


    }

    public void FollowPlayer(Vector3 playerPosition)
    {
        Vector3 direction = playerPosition - enemifov.transform.position;
        enemifov.transform.position += direction.normalized * speed * Time.deltaTime;
        enemifov.transform.rotation = Quaternion.Slerp(enemifov.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
    }

}

   

