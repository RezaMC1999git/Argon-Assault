using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    ScoreBord scoreBord;
    private void Start()
    {
        AddBoxCollider();
        scoreBord = FindObjectOfType<ScoreBord>();
    }

    void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject DeathParticle =  Instantiate(deathFX, transform.position, Quaternion.identity);
        DeathParticle.transform.parent = parent;
        scoreBord.ScoreHit(scorePerHit);
        Destroy(gameObject);
    }
}
