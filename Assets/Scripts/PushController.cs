using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushController : MonoBehaviour
{
    [SerializeField]
    float force = 2.0F;

    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        // Si no es Pushable, entonces sale del método
        if (!other.collider.CompareTag("Pushable"))
        {
            return;
        }

        Rigidbody rb = other.collider.GetComponent<Rigidbody>();
        // Si no tiene rigidbody entonces sale del metodo
        if(rb == null)
        {
            return;
        }

        // Obtiene la dirección hacia donde debe ser empujado el objecto
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.y = 0.0F;
        direction.Normalize();

        rb.AddForceAtPosition
            (direction * force, transform.position, ForceMode.Impulse);
    }
}
