using UnityEngine;

public class Scanner
{
    private Transform _transform;
    private float _distance;
    private string _targetTag;
    private Vector3 _coordinats;
    private float _angleSpeed;
    private float _angle;
    public Scanner(Transform transform, float distance, string targetTag, Vector3 coordinats, float angleSpeed, float angle)
    {
        _transform = transform;
        _distance = distance;
        _targetTag = targetTag;
        _coordinats = coordinats;
        _angleSpeed = angleSpeed;
        _angle = angle;
    }
    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = _transform.position;
        if (Physics.Raycast(pos, dir, out hit, _distance))
        {
            _coordinats = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);

            if (hit.transform.tag == _targetTag)
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * _distance, Color.red);
        }
        return result;
    }

    public Vector3 GetCoords()
    {
        return _coordinats;
    }

    public bool Scanning()
    {
        Vector3 dir = _transform.TransformDirection(new Vector3(0, 0, 1));
        return GetRaycast(dir);
    }

    public void Searching(float x = 0)
    {
        _transform.localRotation = Quaternion.Euler(x, Mathf.Sin(Time.time * _angleSpeed) * _angle, 0);


    }

}
