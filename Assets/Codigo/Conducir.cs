using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conducir : MonoBehaviour
{

    public float aceleracion = 100f;
    public float velocidadMax = 100f;
    public Rigidbody coche;

    // Start is called before the first frame update
    void Start()
    {
        coche = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        Vector3 fuerza = new Vector3(0.0f, 1.0f, 0.0f); //aplicar fuerza hacia arriba.

        var velVector = coche.velocity; //recoge la velocidad del rigidbody en forma de vector
        float velActual = velVector.magnitude; //recoge la longitud del vector velocidad (el modulo)

        Debug.Log(aceleracion);

        if (Input.GetKey(KeyCode.W))
        {
            if (velActual < velocidadMax)
            {
                coche.AddForce(fuerza * aceleracion, ForceMode.Impulse);
            }
        }

    }
}
