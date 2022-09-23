using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;

    private Transform current;
    
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(point1.position);
        current = point1;
    }

    // Update is called once per frame
    void Update()
    {
        
     /*   if (Input.GetMouseButton(0))  // 0 means its the left button
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // gets the info of where im clicking

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                agent.SetDestination(hit.point);  // agent goes to the point clicked
            }
        } */

     if (agent.remainingDistance <= 0.5f)
     {
         if (current == point1)
         {
             current = point2;
         }

         else
         {
             current = point1;

         }

         agent.SetDestination(current.position);
         
         
     }
     
    }
}
