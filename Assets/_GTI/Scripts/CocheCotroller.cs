using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CocheMotor))]

public class CocheCotroller : MonoBehaviour
{

    private CocheMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<CocheMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        motor.Giro = Input.GetAxis("Horizontal"); //actualizamos el valor de giro por el input
        float velActual = 0f;
        velActual += Input.GetAxis("Jump"); //sumamos con el space, acelerando
        velActual -= Input.GetAxis("Fire1"); //restamos con el shift, frenando 

        motor.Aceleracion = velActual; //actualzimos la velocidad con con el valor de la suma 
    }
}
