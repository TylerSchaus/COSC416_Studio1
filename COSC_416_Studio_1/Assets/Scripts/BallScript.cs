using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidBody;
    [SerializeField] private float ballSpeed = 5f;
    [SerializeField] private float ballJumpSpeed = 140f; // Ball jump speed different from ballSpeed as we need more force for jumps. 
    [SerializeField] private Collider floor; // Collider for the floor. 
    private bool canJump = false; // Boolean value to verify the sphere is grouded.
    private Vector3 inputVector; // Vector to help the current input values. 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         
        // Wasn't sure if I can just delete this or not. Pretty sure I could've. 
    }

    public void CatchInput(Vector3 input) // Catch the current input here from the InputManager. 
    {
        inputVector = input; 
    }

    public void FixedUpdate() // Using FixedUpdate instead of the simple MoveBall method because it was resulting differents jump having different amount of force at random. 
    {
        float jump = inputVector.y * ballJumpSpeed; // Calculate jump power. 
        if (!canJump)
        {
            jump = 0; // Set the jump to zero when we cant jump. 
        }

        Vector3 inputXYZPlane= new Vector3(inputVector.x * ballSpeed, jump, inputVector.z * ballSpeed); // Variables 
        sphereRigidBody.AddForce(inputXYZPlane);
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == floor){ // Make sure the collision occurs with the floor. Otherwise the ball can "wall jump". 
            canJump = true;
        }
   
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider == floor) // Check the sphere has left the floor. 
        {
            canJump = false;
        }
    }
}
