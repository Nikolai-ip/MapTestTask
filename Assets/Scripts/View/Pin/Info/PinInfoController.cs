using System;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class PinInfoController:MonoBehaviour
    {
        [SerializeField] private InfoWindow _shortInfoWindow;
        [SerializeField] private InfoWindow _fullInfoWindow;
        [SerializeField] private Button _deleteButton;
        private InfoWindow _openedWindow;

        private void Start()
        {
            _shortInfoWindow.Hide();
            _fullInfoWindow.Hide();
            _deleteButton.gameObject.SetActive(false);
        }

        public void ShowShortInfo(PinData pinData)
        {
            _fullInfoWindow.Hide();
            _shortInfoWindow.Show(pinData.Title,pinData.ShortInfo, pinData.ImagePath);
            _deleteButton.gameObject.SetActive(true);
            _openedWindow = _shortInfoWindow;
        }

        public void ShowFullInfo(PinData pinData)
        {
            _shortInfoWindow.Hide();
            _fullInfoWindow.Show(pinData.Title,pinData.Info, pinData.ImagePath);
            _deleteButton.gameObject.SetActive(true);
            _openedWindow = _fullInfoWindow;

        }

        public void CloseCurrentWindow()
        {
            _openedWindow.Hide();
            _deleteButton.gameObject.SetActive(false);
        }
    }
}