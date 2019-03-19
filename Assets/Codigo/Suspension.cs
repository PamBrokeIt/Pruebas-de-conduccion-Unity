using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspension : MonoBehaviour
{
    private Rigidbody coche;
    private Transform rueda; //posicion de la rueda alrededor del coche (local es el coche)

    public float gravityForce = 1000f;
    public float radioRueda = 1.0f;
    public float suspLongMaxima = 0.2f;
    public float hoverForce = 1000;
    public float hoverHeight;
    float thrust = 0f;
    public bool grounded;

    public GameObject hoverPoint;


    // Works like start but before it

    void Awake()
    {
        coche = transform.root.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {        
        Vector3 ralloOrigen = rueda.position;
        hoverHeight = suspLongMaxima + radioRueda;
    }


    private void FixedUpdate()
    {
        float speed = coche.velocity.magnitude;


        //--------RAYCAST--------
        //  Hover Force
        RaycastHit hit;
        bool grounded = false;

        if (Physics.Raycast(hoverPoint.transform.position, -Vector3.up, out hit, hoverHeight))
        {
            coche.AddForceAtPosition(hoverPoint.transform.up * gravityForce, hit.point);
            grounded = true;
        }
        else
        {
            // Self levelling - returns the vehicle to horizontal when not grounded
            if (transform.position.y > hoverPoint.transform.position.y)
            {
                coche.AddForceAtPosition(hoverPoint.transform.up * gravityForce, hoverPoint.transform.position);
            }
            else
            {
                coche.AddForceAtPosition(hoverPoint.transform.up * -gravityForce, hoverPoint.transform.position);
            }
        }


        /*
            if (Physics.Raycast(hoverPoint.transform.position, -Vector3.up, out hit, ))
            {
                coche.AddForceAtPosition(Vector3.up * hoverForce * (1.0f - (hit.distance / hoverHeight)), hoverPoint.transform.position);
                grounded = true;
                Debug.DrawRay(transform.position, -Vector3.up, Color.red);
            }
            else
            {
                // Self levelling - returns the vehicle to horizontal when not grounded
                if (transform.position.y > hoverPoint.transform.position.y)
                {
                    body.AddForceAtPosition(hoverPoint.transform.up * gravityForce, hoverPoint.transform.position);
                }
                else
                {
                    body.AddForceAtPosition(hoverPoint.transform.up * -gravityForce, hoverPoint.transform.position);
                }
            }
            /*

        //--------RAYCAST--------



        // down = local downwards direction
        //Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, Vector3.down, out hit, radioRueda + suspLongMaxima))
        {

            grounded = true;
            // the velocity at point of contact
            //Vector3 velocityAtTouch = parent.GetPointVelocity(hit.point);

            // calculate spring compression
            // difference in positions divided by total suspension range
            float compression = hit.distance / (suspLongMaxima + radioRueda);
            compression = -compression + 1;

            // final force
            //Vector3 force = Vector3.down * compression * spring;
            // velocity at point of contact transformed into local space

            // Vector3 t = transform.InverseTransformDirection(velocityAtTouch);

            // local x and z directions = 0
            //t.z = t.x = 0;

            // back to world space * -damping
            //Vector3 damping = transform.TransformDirection(t) * -damper;
            Vector3 finalForce = force;

            // VERY simple turning - force rigidbody in direction of wheel
            /*t = parent.transform.InverseTransformDirection(velocityAtTouch);
            t.y = 0;
            t.z = 0;

            t = transform.TransformDirection(t);
            */



    }
}
