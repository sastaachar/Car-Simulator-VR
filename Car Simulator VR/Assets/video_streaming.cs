/*using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class video_streaming : MonoBehaviour
{

    public InputField urlInput;
    public string url = "192.1684.43.80";
    //public RenderTexture texture;
    //public Material mat;
    public float GetRate = 0.15f;
    private float nextGet = 0;

    IEnumerator GetTexture()
    {
        url = urlInput.text;
        Renderer renderer = GetComponent<Renderer>();
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://" + url + ":8080/?action=snapshot");
        yield return www.Send();
        renderer.material.mainTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        //mat.mainTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
    }

    void Update()
    {
        if (Time.time > nextGet)
        {
            StartCoroutine(GetTexture());
            nextGet = Time.time + GetRate;
        }
    }
}
*/

// Add this script to a GameObject. The Start() function fetches an
// image from the documentation site.  It is then applied as the
// texture on the GameObject.

using UnityEngine;
using System.Collections;

public class video_streaming : MonoBehaviour
{
    public string url = "https://docs.unity3d.com/uploads/Main/ShadowIntro.png";

    IEnumerator Start()
    {
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        using (WWW www = new WWW(url))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);
            GetComponent<Renderer>().material.mainTexture = tex;
        }
    }
}