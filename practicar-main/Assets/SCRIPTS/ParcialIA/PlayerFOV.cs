using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOV : MonoBehaviour
{
    [SerializeField] float viewRadius;
    [SerializeField] float viewAngle;

    [SerializeField] List<GameObject> enemies;
    [SerializeField] LayerMask wallLayer;


    // Update is called once per frame
    void Update()
    {
        foreach (var enemy in enemies)
        {
            if (fieldOfView(enemy))
            {
                //enemy.GetComponent<Renderer>().material.color = Color.red;
                
            }else
            {
                //enemy.GetComponent<Renderer>().material.color = Color.white;
                Debug.DrawLine(transform.position, enemy.transform.position, Color.red);
            }
        }
    }

    public bool fieldOfView(GameObject obj)
    {
        Vector3 dir = obj.transform.position - transform.position;
      
        
        if(  dir.magnitude < viewRadius)
        {
            Debug.Log("dentro de la pizza");
            if (Vector3.Angle(transform.forward, dir)<viewAngle/2)
            {
                if(!Physics.Raycast(transform.position,dir,dir.magnitude,wallLayer))
                {
                    Debug.DrawLine(transform.position, obj.transform.position,Color.blue);
                    return true;
                    
                }
                
                
            }
            
        }
        return false;




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
