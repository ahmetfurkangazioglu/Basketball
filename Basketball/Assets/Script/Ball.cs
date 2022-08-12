using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioSource BallSound;
    private void OnTriggerEnter(Collider other)
    {
        BallSound.Play();
        if (other.CompareTag("BallPoint"))
        {
            gameManager.Result(gameObject.transform.position);
        }
        else if (other.CompareTag("Border"))
        {
            gameManager.Lose();
        }
        else if (other.CompareTag("Feature"))
        {
            gameManager.ChangeScaleHoop(gameObject.transform.position);
            other.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        BallSound.Play();
    }
}
