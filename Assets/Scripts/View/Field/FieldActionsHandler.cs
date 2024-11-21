using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace View
{
    public class FieldActionsHandler:MonoBehaviour, IFieldActionsHandler, IPointerDownHandler
    {
        public event Action<Vector2> FieldClicked;
        [SerializeField] RectTransform canvasRect;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, eventData.position, eventData.pressEventCamera, out var localPoint))
            {
                FieldClicked?.Invoke(eventData.position);
            }
            
        }

    }
}