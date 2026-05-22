using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;

public class scriptsJugador : MonoBehaviour
{
    public float speed= 10f;
    private Vector2 Movimientos;
    public void OnMovimientos(InputAction.CallbackContext context)
    {
        Movimientos= context.ReadValue<Vector2>();
    }
    void Start()
    {
        
    }
    void Update()
    {
      Movimientosjugador();  
    }
    public void Movimientosjugador()
    {
        Vector3 movement = new Vector3(Movimientos.x, 0f, Movimientos.y);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

}