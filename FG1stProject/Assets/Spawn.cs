
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private string StickTag;
    private Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(StickTag))
        {
            rigidbody.isKinematic = true;
        }

        else
        {
            rigidbody.useGravity = true;
        }

    }


    public void MoveWithVelocity(Vector3 Velocity)
    {
        rigidbody.velocity = Velocity;
    }


   
}
