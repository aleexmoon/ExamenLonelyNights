using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player, spawnPoint;
    public Animator animator; 
    private bool zombieNear = false, zombieKill = false; // Booleano para indicar si el enemigo está cerca del jugador
    [SerializeField] private float shootCooldown = 5f; // Tiempo de enfriamiento entre disparos
    public GameObject enemyBullet, enemyPrefab;
    public float enemySpeed, lastShootTime;
    private int enemyLife = 1; // Inicializar la vida del enemigo

    void Update()
    {
        // Verificar la distancia entre el enemigo y el jugador
        float distance = Vector3.Distance(transform.position, player.position);

        // Si la distancia es menor que cierto valor, activar el bool zombieNear
        if (distance < 5f && zombieKill == false)
        {
            zombieNear = true;
            enemy.SetDestination(player.position);
            ShootAtPlayer();
        }
        else
        {
            zombieNear = false;
            enemy.ResetPath();
        }

        // Pasa el valor del bool al Animator
        animator.SetBool("zombieNear", zombieNear);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Flema")
        {
            enemyLife -= 1;
            isEnemyDead();
        }
    }

    void isEnemyDead()
    {
        if(enemyLife == 0)
        {
            zombieKill = true;
            zombieNear = false;
            Destroy(gameObject, 2f); // Destruir este enemigo
        }
        else
        {
            zombieKill = false;
        }
        animator.SetBool("zombieKill", zombieKill);
    }
    
    void ShootAtPlayer()
    {
        // Verificar si ha pasado suficiente tiempo desde el último disparo
        if (Time.time - lastShootTime < shootCooldown)
            return;

        // Realizar el disparo
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation);
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 2f); // Destruir la bala después de un tiempo

        // Actualizar el tiempo del último disparo
        lastShootTime = Time.time;
    }
}
