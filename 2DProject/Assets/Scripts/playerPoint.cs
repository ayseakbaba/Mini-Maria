using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerPoint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>(); //audio caching
        _text.text = score.totalScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas"))
        {
            audio.Play();
            Destroy(other.gameObject);
            score.totalScore++;
            _text.text = score.totalScore.ToString();
        }
    }
}
