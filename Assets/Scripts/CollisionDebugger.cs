using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDebugger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("Hits on ground");
        }
        else
        {
            Debug.Log(collision.collider.tag);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log(collision.collider + "exits ");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
    }
}
