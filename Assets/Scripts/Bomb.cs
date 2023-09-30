using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mouseScript b = collision.GetComponent<mouseScript>();

        if (!b)
        {
            return;
        }

        FindObjectOfType<GameManagerScript>().OnBombHit();
       
    }
}
