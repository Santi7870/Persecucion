using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;         // Referencia al jugador
    public float followRange = 5f;   // Distancia m�xima para seguir al jugador

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= followRange)
        {
            // Est� dentro del rango: seguir al jugador
            agent.SetDestination(player.position);
        }
        else
        {
            // Est� fuera del rango: detenerse
            agent.ResetPath();
        }
    }
}
