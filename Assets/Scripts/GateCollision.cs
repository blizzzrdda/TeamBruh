using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GateCollision : MonoBehaviour
{
    private bool gateUsed; 
    
    [SerializeField]
    private Transform SpawningPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(gateUsed) return;

        if (other.CompareTag("Player"))
        {
            if (RoomController.Get().IsGameOver())
            {
                Debug.Log("Game Over");
            }
            else
            {
                RoomController.Get().SetNextRoom();
                Instantiate(RoomController.Get().GetRoom(), SpawningPoint.position, quaternion.identity);
                // destroy self
                Debug.Log("Next level setup");
            }

            gateUsed = true;
        }
    }
}