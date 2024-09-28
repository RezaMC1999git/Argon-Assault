using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;
    void Start()
    {
        MakeSingletone();
        Invoke("LoadFirstScene", 5f);       
    }
     void LoadFirstScene()
     {
        SceneManager.LoadScene(1);
     }
     void MakeSingletone()
     {
        if(instance!= null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
     }
}
