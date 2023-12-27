using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.InputSystem.Layouts;

namespace Virvon.MyBakery.Services
{
    internal class Joystick : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private RectTransform _slidingArea;
        [SerializeField] private RectTransform _handleBackgorund;
        [SerializeField] private RectTransform _handle;

        [InputControl(layout = "Vector2")]
        [SerializeField]
        private string _controlPath;

        private Vector2 _startPosition;
        private bool _isPointerDown;

        public static Vector2 Direction { get; private set; }

        protected override string controlPathInternal 
        { 
            get => _controlPath; 
            set => _controlPath = value; 
        }

        private void Start()
        {
            Debug.Log("Joystick");

            _isPointerDown = false;
            _startPosition = _handleBackgorund.anchoredPosition;
            _handleBackgorund.gameObject.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Vector2 pointPosition;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_slidingArea, eventData.position, null, out pointPosition) && _isPointerDown == false)
            {
                _isPointerDown = true;
                _handleBackgorund.gameObject.SetActive(true);
                _handleBackgorund.anchoredPosition = pointPosition;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isPointerDown)
            {
                Debug.Log("pointer up");
                _isPointerDown = false;
                SendValueToControl(Vector2.zero);
                Direction = Vector2.zero;

                _handleBackgorund.anchoredPosition = _startPosition;
                _handle.anchoredPosition = Vector2.zero;
                _handleBackgorund.gameObject.SetActive(false);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 handlePosititon;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_handleBackgorund, eventData.position, null, out handlePosititon) && _isPointerDown)
            {
                handlePosititon = handlePosititon * 2 / _handleBackgorund.sizeDelta;

                if (handlePosititon.magnitude > 1)
                    handlePosititon.Normalize();

                _handle.anchoredPosition = handlePosititon * _handleBackgorund.sizeDelta / 2;

                if (handlePosititon != Vector2.zero)
                {
                    Direction = handlePosititon;
                    SendValueToControl(handlePosititon);
                }
            }
        }
    }
}
