using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SquareGo : MonoBehaviour
{
    int speed;
    Rigidbody2D rgbd;
    public AudioSource clip;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.velocity = new Vector2(0, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //gameOver
            if (PlayerPrefs.GetInt("effect") == 0)
            {
                clip.Play();
            }
            
        }
    }

}
