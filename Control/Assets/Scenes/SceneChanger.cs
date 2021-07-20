using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject gameobject;
    public float xPosition;
    public float yPosition;
    public float zPosition;
    public void LoadScene(string sceneName)
  {
      SceneManager.LoadScene(sceneName);
  }

    public void NotDestroy()
    {

        gameobject.transform.parent = null;
        gameobject.transform.position = new Vector3(xPosition, yPosition, zPosition);
        DontDestroyOnLoad(gameobject);

    }
}




