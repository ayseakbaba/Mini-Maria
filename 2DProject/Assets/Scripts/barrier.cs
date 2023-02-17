using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Sahne ve seviyeler ile ilgili Unity k�t�phanesi

public class barrier : MonoBehaviour
{
    private Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
        Debug.Log(_scene.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            score.lives--;
            SceneManager.LoadScene(_scene.name);
        }
    }
}