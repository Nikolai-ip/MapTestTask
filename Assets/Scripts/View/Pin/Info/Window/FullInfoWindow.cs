using UnityEngine;

namespace View
{
    public class FullInfoWindow:InfoEditableWindow
    {
        [SerializeField] private PinInputHandler _pinInputHandler;

        public override void OnApplyButton()
        {
            base.OnApplyButton();
            _pinInputHandler.OnDataEdited(EditTitleField.text, EditInfoField.text, null, LoadImageWindow.ImagePath);
        }
    }
}