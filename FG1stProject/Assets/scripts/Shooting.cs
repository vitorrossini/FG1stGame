using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    
    private bool isShot;
   [SerializeField] private GameObject projectilePrefab;
    // [SerializeField] private Transform shootingStartPosition;
    private int _timesShot;
        private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = projectilePrefab.GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y) * forceMultiplier);

        if(!isShot)
        {
             Aiming.Instance.UpdateTrajectory(forceV, rb, transform.position);
        }

    }

    private void OnMouseUp()
    {
        Aiming.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos - mousePressDownPos);
       
    }

    [SerializeField] private float forceMultiplier = 2;

    void Shoot(Vector3 force)
    {
               if (isShot)
               return;
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
