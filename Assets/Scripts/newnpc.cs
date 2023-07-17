using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newnpc : MonoBehaviour
{     public Transform target; // Referencia al objeto del carro controlado por el jugador
    public float followDistance = 10f; // Distancia a la cual el NPC comenzará a seguir al jugador
    public float moveSpeed = 5f; // Velocidad de movimiento del NPC
    public float rotationSpeed = 2f; // Velocidad de rotación del NPC

    private bool isFollowing = false;
    private Vector3 randomTarget;

    private void Start()
    {
        randomTarget = GetRandomTarget(); // Obtiene un objetivo aleatorio inicial
    }

    private void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= followDistance)
            {
                isFollowing = true;
            }
            else
            {
                isFollowing = false;
            }

            if (isFollowing)
            {
                // Movimiento y rotación hacia el objetivo (carro del jugador)
                Vector3 direction = target.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            else
            {
                // Movimiento aleatorio por la arena
                float distanceToRandomTarget = Vector3.Distance(transform.position, randomTarget);

                if (distanceToRandomTarget <= 1f)
                {
                    randomTarget = GetRandomTarget();
                }

                Vector3 direction = randomTarget - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }

    private Vector3 GetRandomTarget()
    {
        // Obtiene una posición aleatoria dentro de un área específica (arena)
        float x = Random.Range(-10f, 10f);
        float z = Random.Range(-10f, 10f);
        return new Vector3(x, 0f, z);
    }
}