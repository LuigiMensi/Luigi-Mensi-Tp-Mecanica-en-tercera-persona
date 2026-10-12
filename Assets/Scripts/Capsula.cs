using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
public class Capsula : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 6f;
    private Rigidbody rigidbodyComponent;
    private Vector3 moveDirection;
    private bool isGrounded;
    private bool jumpRequested;
    public int itemsCollected = 0;
    public int totalItems = 0;

    public TextMeshProUGUI TextItemsCollected;
    public GameObject winPanel;
    private void Start()
    {
        winPanel.SetActive(false);
        rigidbodyComponent = GetComponent<Rigidbody>();
        totalItems = GameObject.FindGameObjectsWithTag("Item").Length;
        TextItemsCollected.text = "Items Collected: " + itemsCollected + "/" + totalItems;
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
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy (collision.gameObject);
            itemsCollected++;
            TextItemsCollected.text = "Items Collected: " + itemsCollected +"/" + totalItems;
            if (itemsCollected >= totalItems) 
            {
                Debug.Log("All items collected.");
                winPanel.SetActive(true);
            }

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


