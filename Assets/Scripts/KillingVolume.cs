using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillingVolume : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (other.gameObject.TryGetComponent(out Death death))
                death.OnDeath.Invoke();
        }
    }
}
