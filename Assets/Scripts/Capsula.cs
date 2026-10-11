using UnityEngine;
public class Capsula : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 6f;
    private Rigidbody rigidbodyComponent;
    private Vector3 moveDirection;
    private bool isGrounded;
    private bool jumpRequested;
    private void Awake()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontal -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontal += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            vertical -= 1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            vertical += 1f;
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequested = true;
        }
    }
    private void FixedUpdate()
    {
        rigidbodyComponent.AddForce(moveDirection * moveForce);
        if (jumpRequested)
        {
            rigidbodyComponent.AddForce(
            Vector3.up * jumpForce,
            ForceMode.Impulse
            );
            jumpRequested = false;
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}


