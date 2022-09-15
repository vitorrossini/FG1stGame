using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit result;
            bool thereWasHit = Physics.Raycast(transform.position, transform.forward, out result, Mathf.Infinity);
            // Make the ray visible
            Debug.DrawRay(transform.position, transform.forward *50f, Color.red, 0.05f);

            if (thereWasHit)
            {
                // result.collider.gameObject.GetComponent<MeshRenderer>().material.color = GetRandomColor();  // finding the target of the raycast and asking to change its color from the function.
               
                    Destroy(result.collider.gameObject);
                
            }
        }
    }

   /* private Color GetRandomColor()      // function to change the color.
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        return color;
    }*/
}
