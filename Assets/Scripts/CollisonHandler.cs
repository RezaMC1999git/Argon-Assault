using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField] AudioSource deathSFX;
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;
    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();    
    }
    void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathSFX.gameObject.SetActive(true);
        deathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
