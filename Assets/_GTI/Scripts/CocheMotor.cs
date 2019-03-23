using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheMotor : MonoBehaviour
{
    public GroundChecker groundChecker;

    public float velocidadGiro = 100f;

    private float _aceleracion = 0f;
    private float _giro = 0f;
    
    private Vector3 giroVector = Vector3.zero; //lo usaremos para calcular la vel de giro, w = velocidad angular
    private Vector3 velocidad = Vector3.zero; //esto es la velocidad
    private Animator anim; 


    public float Aceleracion
    {
        get
        {
            return _aceleracion;
        }
        set
        {
            _aceleracion = value;
            velocidad.z += _aceleracion;
            anim.SetFloat("aceleracion", _aceleracion);
            if(velocidad.z > 0)
            {
                velocidad.z -= .1f;
                if(velocidad.z > 20f)
                {
                    velocidad.z = 20f;
                }
            }
            else
            {
                velocidad.z = 0;
            }
        }
    }

    public float Giro
    {
        get
        {
            return _giro;
        }
        set
        {
            _giro = value;
            giroVector.y = _giro * velocidadGiro; //al vector w
            anim.SetFloat("giro", _giro); //al giro del animator
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (groundChecker.BuscarSuelo)
        {
            velocidad.y = 0;
            transform.Translate(Vector3.up * groundChecker.distancia);
        }
        else
        {
            velocidad.y -= (9.8f * Time.deltaTime); //gravedad

        }
        transform.rotation = (Quaternion.LookRotation(Vector3.Cross(transform.right, groundChecker.GetRay.normal)));

        transform.Rotate(giroVector * Time.deltaTime); //delta time hace que se haga un transform a tiempos regulares
        transform.Translate(velocidad * Time.deltaTime); 
    }
}
