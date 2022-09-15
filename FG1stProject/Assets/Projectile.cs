
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    private bool isActive;


    public void Initialize()
    {
        isActive = true;
        projectileBody.AddForce(transform.forward * 700 + transform.up * 200);
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            // projectileBody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

            // transform.Translate(transform.forward * speed * Time.deltaTime);

            
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        GameObject collisionObject = collision.gameObject;
        DestructionFree destruction = collisionObject.GetComponent<DestructionFree>();            // checks if the game object who receives the collision has the "no no" script

        if (destruction = null)                // if the result is NO
        {
            Destroy(collisionObject);

        }
    }
}