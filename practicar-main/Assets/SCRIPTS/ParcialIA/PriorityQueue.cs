using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue 
{
    Dictionary<Node, float> _allCost = new Dictionary<Node, float>();

    public int Count
    {
        get { return _allCost.Count; }
    }

    public void Put(Node node, float cost)
    {
        if (_allCost.ContainsKey(node)) _allCost[node] = cost;
        else _allCost.Add(node, cost);
    }

    public Node Get()
    {
        Node node = null;
        float LowestCost = Mathf.Infinity;

        foreach (var item in _allCost)
        {
            if (item.Value < LowestCost)
            {
                node = item.Key;
                LowestCost = item.Value;
            }
        }
        _allCost.Remove(node);
        return node;

    }
}
