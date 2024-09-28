using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looper : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoopGame());
    }
    IEnumerator LoopGame()
    {
        yield return new WaitForSeconds(20f);
        PlayerPrefs.SetInt("SCORE", ScoreBord.instance.score);
        Application.LoadLevel(Application.loadedLevel);
    }
}
