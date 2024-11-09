using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding 
{
    public List<Node> AStar(Node start, Node goal)
    {
        if (start == null || goal == null) return null;
        PriorityQueue frontier = new PriorityQueue();

        frontier.Put(start, 0);

        Dictionary<Node, Node> camefrom = new Dictionary<Node, Node>();
        camefrom.Add(start, null);

        Dictionary<Node, float> costSoFar = new Dictionary<Node, float>();
        costSoFar.Add(start, 0);



        while (frontier.Count > 0)
        {
            Node current = frontier.Get();
            if (current == goal)

            {
                List<Node> path = new List<Node>(); // Lista de nodos hasta el camino
                Node nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    GameManager.Instance.ChangeGameObjectColor(nodeToAdd.gameObject, Color.yellow);
                    path.Add(nodeToAdd);
                    Debug.Log("Adding node to path: " + nodeToAdd.gameObject.name); // Debug para ver qué nodos se están agregando al camino
                    nodeToAdd = camefrom[nodeToAdd];
                }
                path.Reverse();
                return path;
            }

            foreach (Node next in current.neighbors)
            {
                if (next._isBlocked) continue;

                float newCost = costSoFar[current] + next.cost;
                float dist = (goal.transform.position - next.transform.position).magnitude;

                float priority = newCost + dist;

                if (!camefrom.ContainsKey(next))
                {
                    frontier.Put(next, priority);
                    camefrom.Add(next, current);
                    costSoFar.Add(next, newCost);
                }
                else if (newCost < costSoFar[next])
                {
                    frontier.Put(next, priority);
                    camefrom[next] = current;
                    costSoFar[next] = newCost;
                }
            }
        }

        return null;
    }
}
