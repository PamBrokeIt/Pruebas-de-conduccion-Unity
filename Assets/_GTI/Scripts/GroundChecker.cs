using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public float distancia = 0;

    public LayerMask ground = ~0; // la tilde hace que to
    private bool suelo = false;
    private RaycastHit hit;


    public bool BuscarSuelo
    {
        get
        {
            return suelo;
        }
    }

    public RaycastHit GetRay
    {
        get
        {
            return hit;
        }
    }

    private void FixedUpdate()
    {
        suelo = Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f, ground);

        if(suelo)
        {
            distancia = 0.5f - hit.distance;
        }
    }
}
