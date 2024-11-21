using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class LoadImageWindow:MonoBehaviour
    {
        [SerializeField] private GameObject _loadIcon;
        [SerializeField] private RawImage _image;
        public string ImagePath { get; private set; }
        private FileBrowser _fileBrowser;
        private Texture _buffer;
        private TextureLoader _textureLoader = new();
        private void Awake()
        {
            _fileBrowser = FindObjectOfType<FileBrowser>();
            _loadIcon.SetActive(false);
            _image.gameObject.SetActive(false);
        }

        public void SetTexture(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath)) return;
            if (ImagePath != imagePath)
                _image.texture = _textureLoader.LoadTextureFromPath(imagePath);
            _image.gameObject.SetActive(true);
        }

        public void Toggle(bool active)
        {
            _loadIcon.SetActive(active);
            _image.gameObject.SetActive(!active);

        }
        public void OnImageLoadButton()
        {
            _buffer = _image.texture;
            _fileBrowser.OpenFileBrowser(_image,OnImageLoaded);
            _image.gameObject.SetActive(true);
            _loadIcon.SetActive(false);
        }

        private void OnImageLoaded(string path)
        {
            ImagePath = path;
        }

        public void OnDiscardButton()
        {
            _image.texture = _buffer;
        }
        
    }
}