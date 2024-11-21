using System;
using AnotherFileBrowser.Windows;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FileBrowser : MonoBehaviour
{
    public void OpenFileBrowser(RawImage image, Action<string> onLoaded)
    {
        var bp = new BrowserProperties();
        bp.filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
        bp.filterIndex = 0;

        new AnotherFileBrowser.Windows.FileBrowser().OpenFileBrowser(bp, path =>
        {
            StartCoroutine(LoadImage(path, image, onLoaded));
        });
    }

    IEnumerator LoadImage(string path, RawImage image, Action<string> onLoaded)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
        {
            yield return uwr.SendWebRequest();

#pragma warning disable CS0618
            if (uwr.isNetworkError || uwr.isHttpError)
#pragma warning restore CS0618
            {
                Debug.Log(uwr.error);
            }
            else
            {
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                image.texture = uwrTexture;
            }
            onLoaded?.Invoke(path);
        }
    }
}
