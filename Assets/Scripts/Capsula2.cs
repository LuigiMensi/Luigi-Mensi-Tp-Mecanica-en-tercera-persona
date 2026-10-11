using UnityEngine;

public class Capsula2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 5f;
    float gravity = -9.81f;

    public Vector3 moveDirection;

    public CharacterController characterController;
    void Start()
    {
        Debug.Log("Capsula Script Started.");
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = (new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection = (new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = (new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = (new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
        if (characterController.isGrounded == false)
        {
            characterController.Move(new Vector3 (0, gravity, 0)* Time.deltaTime);
        }
    
    
    
    }
}
