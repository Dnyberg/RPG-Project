using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_Mover : MonoBehaviour
{
    [SerializeField] Transform target;

    

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }  


    }

    void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;

        }
    
    }
}
