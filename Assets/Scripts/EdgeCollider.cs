using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollider : MonoBehaviour
{
    public GameManager gameManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            //gameOver
           gameManager.Perdiste();
          
        }
        else if (collision.tag == "Cube")
        {
            //destroy go
            Destroy(collision.gameObject);
        }

    }
}
