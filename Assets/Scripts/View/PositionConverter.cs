using UnityEngine;

namespace View
{
    public class PositionConverter
    {
        private RectTransform _canvasTr;
        private Camera _camera;

        public PositionConverter(RectTransform canvasTr, Camera camera)
        {
            _canvasTr = canvasTr;
            _camera = camera;
        }

        public Vector2 WorldPosToCanvasLocalPos(Vector2 worldPos)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvasTr,  
                worldPos, 
                _camera, 
                out Vector2 localPosition
            );
            return localPosition;
        }

    }
}