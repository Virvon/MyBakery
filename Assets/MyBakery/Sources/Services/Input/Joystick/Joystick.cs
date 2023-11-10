using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Virvon.MyBackery.Services
{
    internal class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private RectTransform _slidingArea;
        [SerializeField] private RectTransform _handleBackgorund;
        [SerializeField] private RectTransform _handle;

        private Vector2 _startPosition;
        private bool _isActivated;

        public static Vector2 Direction { get; private set; }

        public static event Action Activated;
        public static event Action Deactivated;

        private void Start()
        {
            _startPosition = _handleBackgorund.anchoredPosition;
            _handleBackgorund.gameObject.SetActive(false);
            _isActivated = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Vector2 pointPosition;

            if (_isActivated == false && RectTransformUtility.ScreenPointToLocalPointInRectangle(_slidingArea, eventData.position, null, out pointPosition))
            {
                _isActivated = true;
                Activated?.Invoke();

                _handleBackgorund.gameObject.SetActive(true);
                _handleBackgorund.anchoredPosition = pointPosition;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isActivated = false;
            Deactivated?.Invoke();

            _handleBackgorund.anchoredPosition = _startPosition;
            _handle.anchoredPosition = Vector2.zero;
            _handleBackgorund.gameObject.SetActive(false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 handlePosititon;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_handleBackgorund, eventData.position, null, out handlePosititon))
            {
                handlePosititon = handlePosititon * 2 / _handleBackgorund.sizeDelta;

                if (handlePosititon.magnitude > 1)
                    handlePosititon.Normalize();

                _handle.anchoredPosition = handlePosititon * _handleBackgorund.sizeDelta / 2;

                if (handlePosititon != Vector2.zero)
                    Direction = handlePosititon;
            }
        }
    }
}
