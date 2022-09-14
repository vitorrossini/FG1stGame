using UnityEngine;

public class move : MonoBehaviour
{
    
    [SerializeField] private float speed = 2f;
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private Transform groundCheck;
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
            
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));
            
        }

        if (Input.GetKeyDown(KeyCode.B) && IsTouchingFloor())
        {
            Jump();
        }

       
        
    }
    private void Jump()
    {
        float jumpSpeed = 200f;
        characterBody.AddForce(Vector3.up * jumpSpeed);
    }

   /* private bool IsGrounded()
    {
       
      return Physics.CheckBox(groundCheck.position, Vector3.up, Quaternion.identity , Ground);
        
    }*/
   private bool IsTouchingFloor()
   {
       /*
        * Parameters: Center from where we shoot,radius of sphere, direction of sphere, hit parameter, distance of the sphere
        * 
        */
       RaycastHit hit;
       
       return Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);

   }
   
}
