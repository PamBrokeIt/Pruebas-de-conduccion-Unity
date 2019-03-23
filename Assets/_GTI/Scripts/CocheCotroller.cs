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
        motor.Giro = Input.GetAxis("Horizontal");
        float _a = 0f;
        _a += Input.GetAxis("Jump"); //sumamos con el space, acelerando
        _a -= Input.GetAxis("Fire1"); //restamos con el shift, frenando 
        motor.Aceleracion = _a;
    }
}
