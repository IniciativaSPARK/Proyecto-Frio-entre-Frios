using UnityEngine;
using UnityEngine.InputSystem;

public class seguimientoMouse : MonoBehaviour
{
    public LayerMask groundLayer;

    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            Vector3 hitpoint = hit.point;
            hitpoint.y = transform.position.y;

            Vector3 direction = hitpoint - transform.position;

            if (direction != Vector3.zero)
            {
                transform.forward = direction;
            }
        }
    }
}