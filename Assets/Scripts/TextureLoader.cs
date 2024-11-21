using System.IO;
using UnityEngine;

namespace DefaultNamespace
{
    public class TextureLoader
    {
        public Texture LoadTextureFromPath(string path)
        {
            if (File.Exists(path))
            {
                byte[] fileData = File.ReadAllBytes(path);
                
                Texture2D texture = new Texture2D(2, 2);
                if (texture.LoadImage(fileData))
                {
                    return texture;
                }
                Debug.LogError("Failed to load texture from file.");
            }
            else
            {
                Debug.LogError("File does not exist at path: " + path);
            }

            return null;
        }
    }
}