using UnityEditor;
using UnityEngine;
using System.IO;
using System;
public class PackTextures{
    [MenuItem("ZWWX/Test")]
    static void TestZ()
    {
        Debug.Log("Test");
    }
    [MenuItem("ZWWX/Merge Selection Sprites")]
    static void MergeSprites()
    {
        UnityEngine.Object[] gos = Selection.GetFiltered(typeof(Texture2D), SelectionMode.Assets);
        Debug.Log("Selection Count="+gos.Length);
        int width = 0;
        int height = 0;
        Texture2D[] textures = new Texture2D[gos.Length];
        for (int i = 0; i < gos.Length; i++)
        {
            Texture2D tex = gos[i] as Texture2D;
            Debug.Log(tex.width);
            width += tex.width + 1;
            if (tex.height > height)
                height = tex.height;
            textures[i] = tex;
        }
        Texture2D tex2d = new Texture2D(width, height);
        tex2d.PackTextures(textures, 2);
 
        string savePath = Application.dataPath + "/sprite_package.jpg";
        try
        {
            byte[] jpgData = tex2d.EncodeToJPG();
            File.WriteAllBytes(savePath, jpgData);
            AssetDatabase.Refresh();
            Debug.Log("merge completed!");
            Debug.Log("Save: "+savePath);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.StackTrace);
        }
    }
}