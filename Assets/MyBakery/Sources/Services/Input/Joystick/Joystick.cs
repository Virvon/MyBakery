using UnityEngine;
using UnityEngine.EventSystems;

namespace Virvon.MyBakery.Services
{
    internal class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private RectTransform _slidingArea;
        [SerializeField] private RectTransform _handleBackgorund;
        [SerializeField] private RectTransform _handle;

        private Vector2 _startPosition;

        public static Vector2 Direction { get; private set; }

        private void Start()
        {
            Debug.Log("Joystick");

            _startPosition = _handleBackgorund.anchoredPosition;
            _handleBackgorund.gameObject.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Vector2 pointPosition;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_slidingArea, eventData.position, null, out pointPosition))
            {
                _handleBackgorund.gameObject.SetActive(true);
                _handleBackgorund.anchoredPosition = pointPosition;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
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
