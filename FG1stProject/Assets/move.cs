using UnityEngine;

public class Move : MonoBehaviour
{
    
    [SerializeField] private float speed = 2f;
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private int playerIndex;
    
    void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  // i made this alone ayy! 
            {
                transform.Translate(transform.right * speed * Time.deltaTime * -1); 
            
            }
        
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            
            }
        
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(transform.forward * speed * Time.deltaTime);
            
            }
        
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(transform.forward * speed * Time.deltaTime * -1);
            
            }
        

            if (Input.GetKeyDown(KeyCode.B) && IsTouchingFloor())  // if you press B AND player is touching the ground
            {
                Jump();
            }
        }
        /*  Input teacher showed us on the first day of class
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
            
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));
            
        }
        */
        

       
        
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
       
       return Physics.SphereCast(transform.position, 0.05f, -transform.up, out hit, 1f); // creates a sphere to check if it hits something

   }
   
}
