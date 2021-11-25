using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour
{
    private string _targetTag = "Player";
    public int senseRadius = 5;
    private float _angle = 360;
    public float _angleSpeed = 5f;
    private Vector3 _coords;
    private Seeker _seeker;
    private Scanner _scanner;
    void Start()
    {
        _scanner = new Scanner(transform, senseRadius, _targetTag, _coords, _angleSpeed, _angle);
        _seeker = GetComponentInParent<Seeker>();
    }

    void Update()
    {
        _scanner.Searching();
        if (_scanner.Scanning())
        {
            _seeker.SetSpeed(5f);
            _seeker.SetPoint(_scanner.GetCoords());
        }
    }
}
