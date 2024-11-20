using UnityEngine;
using UnityEngine.UI;

namespace ZombieLabyrinth.Player
{
    public class JoystickController : MonoBehaviour
    {
        [SerializeField] private Transform _playerBody;
        [SerializeField] private float _mouseSensitivity = 75f;
        [SerializeField] private Slider _sensitivitySlider;
        [SerializeField] private float _defaultMouseSensitivity = 75f;
        [SerializeField] private float _screenEdgePercentage = 0.5f; // Touch zone percentage from the right edge
        private float _xRotation = 0f;

        void Start()
        {
            _mouseSensitivity = _defaultMouseSensitivity;

            if (_sensitivitySlider != null)
            {
                _sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
            }
        }

        void Update()
        {
            HandleTouchInput();
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = touch.position;

                float screenWidth = Screen.width;
                float screenHeight = Screen.height;
                float touchZoneXStart = screenWidth * (1 - _screenEdgePercentage);

                if (touchPosition.x > touchZoneXStart)
                {
                    float touchX = touch.deltaPosition.x * _mouseSensitivity * Time.deltaTime;
                    float touchY = touch.deltaPosition.y * _mouseSensitivity * Time.deltaTime;

                    _playerBody.Rotate(Vector3.up, touchX);

                    _xRotation -= touchY;
                    _xRotation = Mathf.Clamp(_xRotation, -90f, 80f);

                    transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
                }
            }
            else
            {
                Debug.Log("No touch input detected");
            }
        }

        void OnSensitivityChanged(float sensitivityValue)
        {
            _mouseSensitivity = sensitivityValue * 15;
        }
    }
}
