using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node : MonoBehaviour
{
    public List<Node> neighbors = new List<Node>();

    public bool _isBlocked = false;
    public int cost = 1;

    [SerializeField] TextMeshProUGUI _textCost;
    private void OnMouseOver()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    GameManager.Instance.setstartingNode(this);
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    GameManager.Instance.setgoalNode(this);
        //}
        if (Input.GetMouseButtonDown(2))
        {
            _isBlocked = !_isBlocked;
            GameManager.Instance.ChangeGameObjectColor(gameObject, _isBlocked ? Color.grey : Color.white); //como es un bool con signo de pregunta 
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            SetCost(cost + 1);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SetCost(cost - 1);
        }
    }

    public void SetCost(int newCost)
    {
        cost = Mathf.Clamp(newCost, 1, 99); // esta en este rango 
        _textCost.text = cost.ToString();
        _textCost.enabled = cost == 1 ? false : true;
    }




    private void OnDrawGizmos()
    {
        foreach (Node neighbor in neighbors)
        {
            
            Debug.DrawLine(transform.position, neighbor.transform.position, Color.green);
        }
    }
}
