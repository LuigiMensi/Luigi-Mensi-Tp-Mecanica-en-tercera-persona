using UnityEngine;

public class ItemTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entro en el trigger.");

            Destroy(gameObject);
        }
    }

}
