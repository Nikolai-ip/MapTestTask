using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class InfoWindow:MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI Info;
        [SerializeField] protected TextMeshProUGUI Title;
        protected LoadImageWindow LoadImageWindow;

        protected virtual void Awake()
        {
            LoadImageWindow = GetComponentInChildren<LoadImageWindow>();
        }

        public void Show(string title, string text, string imagePath)
        {
            gameObject.SetActive(true);
            Info.text = text;
            Title.text = title;
            LoadImageWindow.SetTexture(imagePath);

        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}