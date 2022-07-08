using TMPro;
using UnityEngine;

namespace PerformanceTest
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        [SerializeField,Range(0.01f, 5)] private float _smoothingTime = 1;

        private float _smoothFPS;

        private void Awake()
        {
            _smoothFPS = 1 / Time.deltaTime;
        }

        private void Update()
        {
            float fps = 1 / Time.deltaTime;
            if (_smoothingTime > 0)
            {
                float fraction = Time.deltaTime / _smoothingTime;
                if (fraction > 1) _smoothFPS = Time.deltaTime;
                else _smoothFPS = fraction * fps / _smoothingTime + (1 - fraction) * _smoothFPS;
            }
            else _smoothFPS = fps;

            _tmpText.text = $"FPS: {_smoothFPS:F1}";
        }
    }
}