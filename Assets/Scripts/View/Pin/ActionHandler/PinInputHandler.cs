using System;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace View
{
    public class PinInputHandler:MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public event Action PointEnter;
        public event Action PointExit;
        private PositionConverter _positionConverter;
        private RectTransform _rectTransform;
        [SerializeField] private PinView _pinView;
        private PinsInfoActionsHandler _pinsInfoActionsHandler;
        private bool _isDrag;
        public void Awake()
        {
            _positionConverter =
                new PositionConverter(FindObjectOfType<Canvas>().GetComponent<RectTransform>(), Camera.main);
            _rectTransform = GetComponent<RectTransform>();
            _pinsInfoActionsHandler = FindObjectOfType<PinsInfoActionsHandler>();
        }
        public void OnMoreInfoClicked()
        {
            _pinsInfoActionsHandler.OnMoreInfoClicked(_pinView.ID);
        }

        public void OnDataEdited(string title, string info, string shortInfo, string imagePath)
        {
            var newData = new PinData(_pinView.ID, title, info, shortInfo, imagePath);
            Debug.Log("Data edited " + newData);
            _pinsInfoActionsHandler.OnPinDataEdit(newData);
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_isDrag)
            {
                Debug.Log("Pin selected id: " + _pinView.ID);
                _pinsInfoActionsHandler.OnPinSelected(_pinView.ID);

            }
            else
                _isDrag = false;

        }
        public void OnDrag(PointerEventData eventData)
        {
            _isDrag = true;
            var newPos = _positionConverter.WorldPosToCanvasLocalPos(eventData.position);
            _rectTransform.anchoredPosition = new Vector2(newPos.x,newPos.y);
            _pinsInfoActionsHandler.OnPinPositionChanged(_pinView.ID, eventData.position);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointEnter?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointExit?.Invoke();
        }
        

    }
}