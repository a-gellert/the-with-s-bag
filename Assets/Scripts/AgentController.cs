using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _agent;
    private Vector3 _destPoint = new Vector3();

    void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                _destPoint = hit.point;
                _agent.SetDestination(_destPoint);
            }
        }
    }
}
