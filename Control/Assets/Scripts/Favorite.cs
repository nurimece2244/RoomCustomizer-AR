using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
//#if UNITY_EDITOR
    using UnityEditor;
//#endif
using UnityEditor;
public class Favorite : MonoBehaviour
{

    public Image On;
    public Image Off;
    public GameObject gameobject;
    int index;
    public void ON() 
    {
        index = 1;
        Off.gameObject.SetActive(true);
        On.gameObject.SetActive(false);

    }

    //#if UNITY_EDITOR


 



    public void OFF()
    {
        index = 0;
        Off.gameObject.SetActive(false);
        On.gameObject.SetActive(true);

        // if(PrefabUtility.IsPartOfPrefabInstance(gameobject))
        // {
        //    return;

        //   }
        // string localPath = "Assets/Resources/FavoriteObject/" + gameobject.name + ".prefab";
        //localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        //PrefabUtility.SaveAsPrefabAssetAndConnect(gameobject, localPath, InteractionMode.UserAction);

    }

    //#endif

}
