using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Infrastructure.Components
{
    public class ClickDetector2D : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Awake() => _mainCamera = Camera.main;

        private void Update()
        {
            if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
            {
                var mousePosition = Pointer.current.position.ReadValue();
                var ray = _mainCamera.ScreenPointToRay(mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction); //.GetRayIntersection(ray);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    SendMessage("OnMouseClicked2D");
                }
            }
        }
    }
}