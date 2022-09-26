using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShooter : MonoBehaviour
{
    [SerializeField] private float flightDurationInSeconds = 2;
    private Spawn currentSpawn;
    private Camera currentCamera;
    private bool isShot;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    [SerializeField] float forceMultiplier = 2;
    private Rigidbody rb;




    // Start is called before the first frame update
    void Start()
    {
        currentCamera = Camera.main;
    }

   public void ChangeCurrentSpawn(Spawn NewSpawn)
    {
        currentSpawn = NewSpawn;
        isShot = false;
    }


    private void Update()
    {
         void OnMouseDown()
        {
            mousePressDownPos = Input.mousePosition;
        }

         void OnMouseDrag()
        {
            Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
            Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y) * forceMultiplier);

            if (!isShot)
            {
                Aiming.Instance.UpdateTrajectory(forceV, rb, transform.position);
            }

        }

         void OnMouseUp()
        {
            Aiming.Instance.HideLine();
            mouseReleasePos = Input.mousePosition;
            Shoot(mouseReleasePos - mousePressDownPos);

        }

       

        void Shoot(Vector3 force)
        {
            if (isShot)
                return;

        }
    }

}
