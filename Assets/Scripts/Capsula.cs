using UnityEngine;

public class Capsula : MonoBehaviour
{
    // Start iscalled once before the first execution of Update after the MonoBehaviour is created

    public int counter = 0;
    public float speed = 1f;


    public CharacterController charaController;

    void Start()
    {

        charaController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
            //charaController.Move(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
            //charaController.Move(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            //charaController.Move(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            //charaController.Move(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }


    }
}
        


