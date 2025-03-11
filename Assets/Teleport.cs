using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform[] walls; 
    [SerializeField] Transform TeleportLocation; 

    public void OnCollisionEnter(Collision collision)
    {
        foreach (Transform wall in walls)
        {
            if (collision.gameObject == wall.gameObject)
            {
                TeleportPlayer();
                break;
            }
        }
    }

    public void TeleportPlayer()
    {
        if (TeleportLocation != null)
        {
            transform.position = TeleportLocation.position;
        }
        else
        {
            Debug.LogWarning("No special teleport location assigned!");
        }
    }
}

