using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheMotor : MonoBehaviour
{
    public GroundChecker groundChecker;

    public float velocidadGiro = 100f;

    private float _aceleracion = 0f;
    private float _giro = 0f;
    
    private Vector3 _w = Vector3.zero; //lo usaremos para calcular la vel de giro, w = velocidad angular
    private Vector3 _v = Vector3.zero; //
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
            _v.z += _aceleracion;
            anim.SetFloat("aceleracion", _aceleracion);
            if(_v.z > 0)
            {
                _v.z -= .1f;
                if(_v.z > 20f)
                {
                    _v.z = 20f;
                }
            }
            else
            {
                _v.z = 0;
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
            _w.y = _giro * velocidadGiro; //al vector w
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
        if (groundChecker.InGround)
        {
            _v.y = 0;
            transform.Translate(Vector3.up * groundChecker.distancia);
        }
        else
        {
            _v.y -= (9.8f * Time.deltaTime); //gravedad

        }

        transform.Rotate(_w * Time.deltaTime); //delta time hace que se haga un transform a tiempos regulares
        transform.Translate(_v * Time.deltaTime); 
    }
}
