using UnityEngine;
using UnityEngine.InputSystem;

public class seguimientoMouse : MonoBehaviour
{
    public LayerMask groundLayer;

    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            Vector3 hitpoint = hit.point;
            hitpoint.y = transform.position.y;
            transform.forward = hitpoint - transform.position;
            
        }

    }
}
