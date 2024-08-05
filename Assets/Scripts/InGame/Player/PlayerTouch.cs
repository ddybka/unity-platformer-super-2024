using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            Debug.Log("Health");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("NextLevel"))
        {
            Invoke("NextLevel", .5f);
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Spike");
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
