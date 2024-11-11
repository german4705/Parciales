using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Node _goalNode; // Nodo objetivo, el más cercano al jugador
    public List<Node> nodes = new List<Node>(); // Lista de todos los nodos en la escena
    public List<EnemyPath> enemies = new List<EnemyPath>(); // Lista de enemigos en la escena
    public Player player;
    //public GameObject positionPlayer;

    public PathFinding _pf;
    public static GameManager Instance;

    public List<EnemyFOV> enemiesFOV = new List<EnemyFOV>();

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    [SerializeField] LayerMask wallLayer;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        _pf = new PathFinding();
    }

    public Node GetNearestNode(Vector3 position, List<Node> nodes)
    {
        Node nearestNode = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Node node in nodes)
        {
            float distance = Vector3.Distance(position, node.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestNode = node;
            }
        }

        return nearestNode;
    }

    private void Update()
    {
        Node playerNode = GetNearestNode(player.transform.position, nodes);
        bool isAnyEnemyAlerting = false;

        foreach (var enemyFOV in enemiesFOV)
        {
            if (enemyFOV.IsPlayerInSight())
            {
                enemyFOV.FollowPlayer(player.transform.position); // Los enemigos con visión directa siguen al jugador
                isAnyEnemyAlerting = true; // Activa la alerta global
            }
            else
            {
                enemyFOV.StopFollowingPlayer(); // Los enemigos sin visión directa vuelven a patrullar
            }
        }

        // Si hay enemigos que ven al jugador, calculamos el camino para los que no tienen visión directa
        if (isAnyEnemyAlerting)
        {
            AlertEnemiesWithoutSight(playerNode);
        }
    }


    private void AlertEnemiesWithoutSight(Node playerNode)
    {
        foreach (var enemy in enemies)
        {
            var enemyFOV = enemy.GetComponent<EnemyFOV>();

            // Si el enemigo no tiene visión del jugador, sigue su camino de nodos
            if (!enemyFOV.IsPlayerInSight())
            {
                Node startNode = GetNearestNode(enemy.transform.position, nodes);
                List<Node> path = _pf.AStar(startNode, playerNode);
                enemy.GetPath(path); // Asigna el camino hacia el nodo más cercano al jugador
                enemy.FollowPath(); // Mueve el enemigo hacia el siguiente nodo en el camino
            }
        }
    }





    public void ChangeGameObjectColor(GameObject obj, Color color)
    {
        obj.GetComponent<Renderer>().material.color = color;
    }



    //Vector3 dir = player.transform.position - enemyFOV.transform.position;
    //dir.y = 0;


    //Quaternion targetRotation = Quaternion.LookRotation(dir);
    //enemyFOV.transform.rotation = Quaternion.Slerp(enemyFOV.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);


    //enemyFOV.transform.position += dir.normalized * speed * Time.deltaTime;
}

