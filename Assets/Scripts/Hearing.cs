using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearing : MonoBehaviour
{
    public int hearingRadius = 10;
    void Start()
    {

    }

    void Update()
    {

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, hearingRadius);
    }
}
