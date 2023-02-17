using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
