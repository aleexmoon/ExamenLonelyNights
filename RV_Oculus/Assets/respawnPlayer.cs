using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform respawnPoint; // arrastra el objeto de punto de reaparición en el inspector
    public CharacterController characterController; // asigna el CharacterController en el inspector

    void Start()
    {
        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
    }

    public void Respawn()
    {
        if (characterController != null)
        {
            characterController.enabled = false; // Deshabilitar para evitar conflictos de física
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;
            characterController.enabled = true; // Rehabilitar después de mover
        }
        else
        {
            Debug.LogError("CharacterController no asignado.");
        }
    }
}
