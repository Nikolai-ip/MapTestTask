using Model;
using UnityEngine;

namespace View
{
    public class PinView:MonoBehaviour
    {
        public int ID { get; private set; }
        private RectTransform _rectTransform;
        private PositionConverter _posConvertor;
        private void Awake()
        {
            _posConvertor =
                new PositionConverter(FindObjectOfType<Canvas>().GetComponent<RectTransform>(), Camera.main);
            _rectTransform = GetComponent<RectTransform>();

        }

        public void SetData(PinData pinData)
        {
            ID = pinData.ID;
            var localPosition = _posConvertor.WorldPosToCanvasLocalPos(new Vector2(pinData.Position.x,pinData.Position.y));
            _rectTransform.anchoredPosition = new Vector2(localPosition.x,localPosition.y + _rectTransform.rect.height/2) ;
            _rectTransform.localScale = Vector3.one;
        }

    }
}