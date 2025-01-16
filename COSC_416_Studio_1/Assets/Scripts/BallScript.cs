using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidBody;
    [SerializeField] private float ballSpeed = 2f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         
        
    }

    public void MoveBall(Vector2 input)
    {
        Vector3 inputXZPlane = new Vector3(input.x, 0, input.y);
        sphereRigidBody.AddForce(inputXZPlane * ballSpeed);
    }
}
