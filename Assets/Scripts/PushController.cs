using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushController : MonoBehaviour
{
        [SerializeField]
        float force = 2.0F;

        void OnControllerColliderHit(ControllerColliderHit other)
        {
            //Si no es pushable entonces sale del método
            if (!other.collider.CompareTag("Pushable"))
            {
                return;
            }

            Rigidbody rb = other.collider.GetComponent<Rigidbody>();

            //Si no tiene rigidbody entonces sale del método
            if (rb == null)
            {
                return;
            }

            Vector3 direction = other.gameObject.transform.position - transform.position;

            direction.y = 0.0F;
            direction.Normalize();

            rb.AddForceAtPosition(direction * force, transform.position, ForceMode.Impulse);
        }
    }

