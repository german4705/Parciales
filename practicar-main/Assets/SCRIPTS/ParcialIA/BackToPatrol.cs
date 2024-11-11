using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPatrol : MonoBehaviour
{
    [SerializeField] LayerMask wallLayer;

    public bool Insigth (Vector3 start, Vector3 end)
    {
        return !Physics.Raycast(start, end - start, Vector3.Distance(start, end), wallLayer);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
