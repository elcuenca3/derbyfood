using UnityEngine;
using UnityEngine.AI;

public class CarNPC : MonoBehaviour
{
    public Transform playerCar;
    public float speed = 10f;
    public float rotationSpeed = 5f;
    public float chaseRange = 10f;
    private Rigidbody rb;
    private Vector3 initialPosition;
    private bool isChasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Calcula la distancia entre el vehículo NPC y el carro controlado por el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, playerCar.position);

        // Verifica si el jugador está dentro del rango de persecución
        if (distanceToPlayer <= chaseRange)
        {
            isChasing = true;

            // Dirección hacia la posición actual del carro controlado por el jugador
            Vector3 direction = playerCar.position - transform.position;
            direction.Normalize();

            // Movimiento hacia adelante
            rb.MovePosition(transform.position + (direction * speed * Time.fixedDeltaTime));

            // Rotación hacia la posición actual del carro controlado por el jugador
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(
                Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime)
            );
        }
        else
        {
            isChasing = false;

            // Movimiento hacia adelante
            rb.MovePosition(transform.position + (transform.forward * speed * Time.fixedDeltaTime));

            // Verifica si el vehículo NPC ha alcanzado su posición inicial
            if (Vector3.Distance(transform.position, initialPosition) <= 1f)
            {
                // Gira 180 grados
                Quaternion targetRotation = Quaternion.LookRotation(-transform.forward);
                rb.MoveRotation(
                    Quaternion.Lerp(
                        rb.rotation,
                        targetRotation,
                        rotationSpeed * Time.fixedDeltaTime
                    )
                );
            }
            else
            {
                // Gira hacia la posición inicial
                Quaternion targetRotation = Quaternion.LookRotation(
                    initialPosition - transform.position
                );
                rb.MoveRotation(
                    Quaternion.Lerp(
                        rb.rotation,
                        targetRotation,
                        rotationSpeed * Time.fixedDeltaTime
                    )
                );
            }
        }
    }
}
