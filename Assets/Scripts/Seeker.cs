using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seeker : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField]
    private List<GameObject> _points = new List<GameObject>();
    private List<Vector3> _vectors = new List<Vector3>();
    public Vector3 DestPoint { get; set; }

    void Start()
    {
        _points.ForEach(x => _vectors.Add(new Vector3(x.transform.localPosition.x, x.transform.localPosition.y, x.transform.localPosition.z)));

        _agent = GetComponent<NavMeshAgent>();

        DestPoint = PickPoint();
        _agent.SetDestination(DestPoint);
    }

    void Update()
    {
        if (CheckArrive())
        {
            _agent.speed = 3f;
            DestPoint = PickPoint();
            _agent.SetDestination(DestPoint);
        }
    }
    public void SetPoint(Vector3 point)
    {
        DestPoint = point;
        _agent.SetDestination(point);
    }
    private bool CheckArrive() => gameObject.transform.position.x == DestPoint.x && gameObject.transform.position.z == DestPoint.z;
    private Vector3 PickPoint() => _vectors[Random.Range(0, _vectors.Count)];
    public void SetSpeed(float speed) => _agent.speed = speed;

}
