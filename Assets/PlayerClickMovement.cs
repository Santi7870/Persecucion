using UnityEngine;
using UnityEngine.AI;


public class PlayerClickMovement : MonoBehaviour
{
    public Camera mainCamera; // Asigna tu cámara aquí si no es la MainCamera por defecto
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit: " + hit.collider.name);

                if (NavMesh.SamplePosition(hit.point, out NavMeshHit navHit, 5.0f, NavMesh.AllAreas))

                {
                    Debug.Log("Moving to: " + navHit.position);
                    agent.SetDestination(navHit.position);
                }
                else
                {
                    Debug.Log("No valid NavMesh at click.");
                }
            }
        }
    }

}