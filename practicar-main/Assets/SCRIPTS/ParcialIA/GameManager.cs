using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Node _goalNode; // Nodo objetivo, el más cercano al jugador
    public List<Node> nodes = new List<Node>(); // Lista de todos los nodos en la escena
    public List<EnemyPath> enemies = new List<EnemyPath>(); // Lista de enemigos en la escena
    public Player player;

    public PathFinding _pf;
    public static GameManager Instance;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Node playerNode = GetNearestNode(player.transform.position, nodes);

            // Calcular el camino A* para cada enemigo
            foreach (var enemy in enemies)
            {
                Node startNode = GetNearestNode(enemy.transform.position, nodes);
                List<Node> path = _pf.AStar(startNode, playerNode);
                enemy.GetPath(path);
            }
        }
    }
    // seteamos los nodos principio y final de los nodos 
    //public void setstartingNode(Node startingNode)
    //{

    //    if (_startingNode != null) ChangeGameObjectColor(_startingNode.gameObject, Color.white);
    //    _startingNode = startingNode;
    //    ChangeGameObjectColor(startingNode.gameObject, Color.green);

    //    enemyPath.SetPos(_startingNode.transform.position);
    //}
    //public void setgoalNode(Node goalNode)
    //{
    //    if (_goalNode != null) ChangeGameObjectColor(_goalNode.gameObject, Color.white);
    //    _goalNode = goalNode;
    //    ChangeGameObjectColor(goalNode.gameObject, Color.red);
    //}

    public void ChangeGameObjectColor(GameObject obj, Color color)
    {
        obj.GetComponent<Renderer>().material.color = color;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        //StartCoroutine(_pf.PaintBFS(_startingNode, _goalNode));
    //        //_player.GetPath(_pf.BFS(_startingNode, _goalNode));

    //        //_player.GetPath(_pf.DijkstraPath(_startingNode, _goalNode));
    //        enemyPath.GetPath(_pf.AStar(GetNearestNode(enemyPath.transform.position,nodes), GetNearestNode(player.transform.position,nodes)));
    //        //StartCoroutine(_pf.PaintGrredyBFS(_startingNode, _goalNode));
    //    }
    //}
}

