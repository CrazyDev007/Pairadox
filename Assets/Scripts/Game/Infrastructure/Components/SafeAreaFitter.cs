using UnityEngine;

namespace Game.Infrastructure.Components
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaFitter : MonoBehaviour
    {
        private RectTransform _panel;
        private Rect _lastSafeArea = new Rect(0, 0, 0, 0);
        private Vector2Int _lastScreenSize = Vector2Int.zero;

        private void Awake()
        {
            _panel = GetComponent<RectTransform>();
            ApplySafeArea();
        }

        private void Update()
        {
            // Re-apply if screen size or orientation changes
            if (Screen.safeArea != _lastSafeArea ||
                new Vector2Int(Screen.width, Screen.height) != _lastScreenSize)
            {
                ApplySafeArea();
            }
        }

        private void ApplySafeArea()
        {
            var safeArea = Screen.safeArea;
            _lastSafeArea = safeArea;
            _lastScreenSize = new Vector2Int(Screen.width, Screen.height);

            // Convert safe area rectangle from pixel space to normalized anchor space
            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            _panel.anchorMin = anchorMin;
            _panel.anchorMax = anchorMax;
        }
    }
}