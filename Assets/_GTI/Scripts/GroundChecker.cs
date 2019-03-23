using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public float distancia = 0;

    public LayerMask ground = ~0; // la tilde hace que to
    private bool _inGround = false;

    public bool InGround
    {
        get
        {
            return _inGround;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        _inGround = Physics.Raycast(transform.position, -Vector3.up, out hit, 0.5f, ground);

        if(_inGround)
        {
            distancia = 0.5f - hit.distance;
        }
    }
}
