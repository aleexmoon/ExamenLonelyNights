using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtZombie : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
