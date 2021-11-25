using System;
using UnityEngine;
public class Vision : MonoBehaviour
{

    private string _targetTag = "Player";
    private AgentController _player;
    public int visionDistance = 20;
    private float _angle = 80;
    private float _angleSpeed = 10f;
    private Vector3 _coords;
    private Seeker _seeker;
    private Scanner _scanner;
    private float _alfa;

    private float aSide, bSide, angle;
    void Start()
    {
        _player = FindObjectOfType<AgentController>();
        _scanner = new Scanner(transform, visionDistance, _targetTag, _coords, _angleSpeed, _angle);
        _seeker = GetComponentInParent<Seeker>();
    }

    void Update()
    {
        _alfa = GetXAngle();
        _scanner.Searching(_alfa);
        if (_scanner.Scanning())
        {
            _seeker.SetSpeed(5f);
            _seeker.SetPoint(_scanner.GetCoords());
        }
    }

    private float GetXAngle()
    {
        aSide = Math.Abs(transform.position.x - _player.transform.position.x);
        bSide = Math.Abs(transform.position.y - _player.transform.position.y);



        if (aSide > 20 || bSide > 20)
        {
            return 0;
        }

        angle = 90 - ((float)Math.Atan(aSide / bSide)) * 57.3f;

        if ((transform.position.y - _player.transform.position.y) < 0)
        {
            angle *= -1;
        }
        return angle;
    }
}