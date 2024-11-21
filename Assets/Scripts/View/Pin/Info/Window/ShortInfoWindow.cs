using UnityEngine;

namespace View
{
    public class ShortInfoWindow:InfoEditableWindow
    {
        [SerializeField] private PinInputHandler _pinInputHandler;
        public override void OnApplyButton()
        {
            base.OnApplyButton();
            _pinInputHandler.OnDataEdited(EditTitleField.text,null, EditInfoField.text, LoadImageWindow.ImagePath);
        }
    }
}