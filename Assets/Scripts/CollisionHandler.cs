using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        ExplosionFX();
        StartDeathSequence();
        Invoke("RestartLevel", levelLoadDelay);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void ExplosionFX()
    {
        deathFX.SetActive(true);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }
}
