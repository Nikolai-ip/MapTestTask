using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class InfoEditableWindow:InfoWindow
    {
        [SerializeField] protected TMP_InputField EditInfoField;
        [SerializeField] protected TMP_InputField EditTitleField;
        [SerializeField] private Button _applyButton;
        [SerializeField] private Button _discardButton;
        [SerializeField] private Button _editButton;

        private string _titleBuffer;
        private string _infoBuffer;
        protected virtual void OnEnable()
        {
            ToggleEditState(false);
        }

        public virtual void OnEditButton()
        {
            ToggleEditState(true);
            _titleBuffer = Title.text;
            _infoBuffer = Info.text;
        }

        public virtual void OnApplyButton()
        {
            Title.text = EditTitleField.text;
            Info.text = EditInfoField.text;
            ToggleEditState(false);
        }

        public virtual void OnDiscardButton()
        {
            Title.text =_titleBuffer;
            Info.text = _infoBuffer;
            LoadImageWindow.OnDiscardButton();
            ToggleEditState(false);
        }
        
        private void ToggleEditState(bool isActive)
        {
            EditInfoField.gameObject.SetActive(isActive);
            EditTitleField.gameObject.SetActive(isActive);
            _applyButton.gameObject.SetActive(isActive);
            LoadImageWindow.Toggle(isActive);
            _discardButton.gameObject.SetActive(isActive);
            Info.gameObject.SetActive(!isActive);
            Title.gameObject.SetActive(!isActive);
            _editButton.gameObject.SetActive(!isActive);
        }
    }
}