using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;

public class scriptsJugador : MonoBehaviour
{
    public float speed = 10f;

    [SerializeField] private float vidaMaxima;

    private float vidaActual;

    public AroVida barraVida;

    private Vector2 Movimientos;
    private Animator animator;
    public void OnMovimientos(InputAction.CallbackContext context)
    {
        Movimientos = context.ReadValue<Vector2>();
    }
    void Start()
    {
        vidaActual = vidaMaxima;

        barraVida.SetSliderMax(vidaMaxima);

        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Movimientosjugador();

        bool seEstaMoviendo = Movimientos != Vector2.zero;
        animator.SetBool("isMoving", seEstaMoviendo);
    }
    public void Movimientosjugador()
    {
        Vector3 movement = new Vector3(Movimientos.x, 0f, Movimientos.y);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void TakeDamage(float damage)
    {
        vidaActual -= damage;
        Debug.Log("Vida del jugador: " + vidaActual);

        // Para actualizar la barra de vida
        barraVida.SetSlider(vidaActual);
        
        if(vidaActual <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }


}