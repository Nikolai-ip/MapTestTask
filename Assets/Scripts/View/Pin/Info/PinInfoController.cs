using System;
using Model;
using UnityEngine;

namespace View
{
    public class PinInfoController:MonoBehaviour
    {
        [SerializeField] private InfoWindow _shortInfoWindow;
        [SerializeField] private InfoWindow _fullInfoWindow;
        private InfoWindow _openedWindow;

        private void Start()
        {
            _shortInfoWindow.Hide();
            _fullInfoWindow.Hide();
        }

        public void ShowShortInfo(PinData pinData)
        {
            _fullInfoWindow.Hide();
            _shortInfoWindow.Show(pinData.Title,pinData.ShortInfo, pinData.ImagePath);
            _openedWindow = _shortInfoWindow;
        }

        public void ShowFullInfo(PinData pinData)
        {
            _shortInfoWindow.Hide();
            _fullInfoWindow.Show(pinData.Title,pinData.Info, pinData.ImagePath);
            _openedWindow = _fullInfoWindow;

        }

        public void CloseCurrentWindow()
        {
            _openedWindow.Hide();
        }
    }
}