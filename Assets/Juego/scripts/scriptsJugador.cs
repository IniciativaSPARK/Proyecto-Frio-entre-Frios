using UnityEngine;
using UnityEngine.InputSystem;

public class scriptsJugador : MonoBehaviour
{
    public float speed = 10f;

    [SerializeField] private float vidaMaxima = 10f;
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

        if (barraVida != null)
        {
            barraVida.SetSliderMax(vidaMaxima);
        }

        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Movimientosjugador();

        bool seEstaMoviendo = Movimientos != Vector2.zero;

        if (animator != null)
        {
            animator.SetBool("isMoving", seEstaMoviendo);
        }
    }

    public void Movimientosjugador()
    {
        Vector3 movement = new Vector3(Movimientos.x, 0f, Movimientos.y);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void TakeDamage(float damage)
    {
        vidaActual -= damage;

        Debug.Log("Vida del jugador: " + vidaActual);

        if (barraVida != null)
        {
            barraVida.SetSlider(vidaActual);
        }

        if (vidaActual <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }
}