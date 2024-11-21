using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class PinAnimator:MonoBehaviour
    {
        private PinInputHandler _pinInputHandler;
        [SerializeField] private Color _hoverColor;
        [SerializeField] private float _changeScaleDuration;
        private Image _image;
        private Color _originalColor;
        private void Start()
        {
            _pinInputHandler = GetComponent<PinInputHandler>();
            _image = GetComponent<Image>();
            _pinInputHandler.PointEnter += ChangeColor;
            _pinInputHandler.PointExit += ReturnColor;
            _originalColor = _image.color;
        }

        private void ReturnColor()
        {
            StartCoroutine(ChangeColor(_originalColor));
        }

        private void ChangeColor()
        {
            StartCoroutine(ChangeColor(_hoverColor));

        }

        private IEnumerator ChangeColor(Color target)
        {
            float time = 0;
            Color origin = _image.color;
            while (time<_changeScaleDuration)
            {
                Color newColor = Color.Lerp(origin, target, time / _changeScaleDuration);
                _image.color = newColor;
                time += Time.deltaTime;
                yield return null;
            }

            _image.color = target;
        }
    }
}