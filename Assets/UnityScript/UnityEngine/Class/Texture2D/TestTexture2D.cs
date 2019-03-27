using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class TestTexture2D : MonoBehaviour
{
    public Texture2D sourceTex;
    public Texture2D[] atlasTexture;
    public float warpFactor = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Texture2D texture = new Texture2D(128, 128);
        //Texture2D texture = Texture2D.blackTexture;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        Texture2D texture = GetComponent<Renderer>().material.mainTexture as Texture2D;
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int y = 0; y < texture.height; ++y)
            {
                for (int x = 0; x < texture.width; ++x)
                {
                    Color color = ((x & y) != 0 ? Color.green : Color.red);
                    texture.SetPixel(x, y, color);
                }
            }
            texture.Apply();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Renderer renderer = GetComponent<Renderer>();
            Texture2D t2d = Instantiate(renderer.material.mainTexture) as Texture2D;
            renderer.material.mainTexture = t2d;
            Color[] colors = new Color[3];
            colors[0] = Color.red;
            colors[1] = Color.green;
            colors[2] = Color.yellow;
            Log.LogInfo("mipmapCount {0}", t2d.mipmapCount);
            int mipCount = Mathf.Min(3, t2d.mipmapCount);
            for (int i = 0; i < mipCount; ++i)
            {
                Color[] cols = t2d.GetPixels(i);
                for (int j = 0; j < cols.Length; ++j)
                {
                    cols[j] = Color.Lerp(cols[j], colors[i], 0.33f);
                }
                t2d.SetPixels(cols, i);
            }
            t2d.Apply();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Texture2D destTex = new Texture2D(sourceTex.width, sourceTex.height);
            Color[] destPix = new Color[destTex.width * destTex.height];
            for (int y = 0; y < destTex.height; ++y)
            {
                for (int x = 0; x < destTex.width; ++x)
                {
                    float xFrac = x * 1.0f / (destTex.width - 1);
                    float yFrac = y * 1.0f / (destTex.height - 1);
                    float warpXFrac = Mathf.Pow(xFrac, warpFactor);
                    float warpYFrac = Mathf.Pow(yFrac, warpFactor);
                    destPix[y * destTex.width + x] = sourceTex.GetPixelBilinear(warpXFrac, warpYFrac);
                }
            }
            destTex.SetPixels(destPix);
            destTex.Apply();
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = destTex;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Texture2D tex = new Texture2D(16, 16, TextureFormat.PVRTC_RGBA4, false);
            byte[] pvrtcBytes = new byte[]
        {
            0x30, 0x32, 0x32, 0x32, 0xe7, 0x30, 0xaa, 0x7f, 0x32, 0x32, 0x32, 0x32, 0xf9, 0x40, 0xbc, 0x7f,
            0x03, 0x03, 0x03, 0x03, 0xf6, 0x30, 0x02, 0x05, 0x03, 0x03, 0x03, 0x03, 0xf4, 0x30, 0x03, 0x06,
            0x32, 0x32, 0x32, 0x32, 0xf7, 0x40, 0xaa, 0x7f, 0x32, 0xf2, 0x02, 0xa8, 0xe7, 0x30, 0xff, 0xff,
            0x03, 0x03, 0x03, 0xff, 0xe6, 0x40, 0x00, 0x0f, 0x00, 0xff, 0x00, 0xaa, 0xe9, 0x40, 0x9f, 0xff,
            0x5b, 0x03, 0x03, 0x03, 0xca, 0x6a, 0x0f, 0x30, 0x03, 0x03, 0x03, 0xff, 0xca, 0x68, 0x0f, 0x30,
            0xaa, 0x94, 0x90, 0x40, 0xba, 0x5b, 0xaf, 0x68, 0x40, 0x00, 0x00, 0xff, 0xca, 0x58, 0x0f, 0x20,
            0x00, 0x00, 0x00, 0xff, 0xe6, 0x40, 0x01, 0x2c, 0x00, 0xff, 0x00, 0xaa, 0xdb, 0x41, 0xff, 0xff,
            0x00, 0x00, 0x00, 0xff, 0xe8, 0x40, 0x01, 0x1c, 0x00, 0xff, 0x00, 0xaa, 0xbb, 0x40, 0xff, 0xff,
        };
            tex.LoadRawTextureData(pvrtcBytes);
            tex.Apply();
            GetComponent<Renderer>().material.mainTexture = tex;
        }
        if(Input.GetKeyDown(KeyCode.G)){
            Texture2D atlas = new Texture2D(8192, 8192);
            for(int i = 0;i < atlasTexture.Length; ++i){
                Log.LogInfo("name {0} readable {1}", atlasTexture[i].name, atlasTexture[i].isReadable);
            }
            Rect[] rect = atlas.PackTextures(atlasTexture,2, 8192,false);
            for(int i = 0;i < rect.Length; ++i){
                Log.LogInfo("rect {0} position {1}", i, rect[i].position.ToString());
            }
            GetComponent<Renderer>().material.mainTexture = atlas;
            if(true)
            {
                string savePath = Application.dataPath + "/sprite_package.jpg";
                byte[] jpgData = atlas.EncodeToJPG();
                File.WriteAllBytes(savePath, jpgData);
                AssetDatabase.Refresh();
                Debug.Log("merge completed!");
                Debug.Log("Save: "+savePath);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            texture = new Texture2D(128, 128, TextureFormat.RGBA32, false, false);
            
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = texture;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {

            if (texture != null)
            {
                Log.LogInfo("alphasTransparency {0}\ndesiredMipmapLevel {1}\nformat {2}\nisReadable {3} loadedMipmapLevel {4}\nloadingMipMapLevel {5}\nmipMapCount {6}\nrequestedMipmapLevel {7}\nstreamingMipmaps {8}\nstreamingMipMapsPriority {9}",
                    texture.alphaIsTransparency,
                    texture.desiredMipmapLevel,
                    texture.format,
                    texture.isReadable,
                    texture.loadedMipmapLevel,
                    texture.loadingMipmapLevel,
                    texture.mipmapCount,
                    texture.requestedMipmapLevel,
                    texture.streamingMipmaps,
                    texture.streamingMipmapsPriority);
            }
            Log.LogInfo("total texture memory {0}", Texture2D.totalTextureMemory);
        }
    }
}
