using System;
using UnityEngine;
using View;

namespace Infrastructure
{
    internal class ButtonView :MonoBehaviour, IButtonView
    {
        public event Action OnClick;

        public void ButtonClicked()
        {
            OnClick?.Invoke();
        }
    }
}