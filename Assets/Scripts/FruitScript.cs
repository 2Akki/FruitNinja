using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public GameObject slicedfruit;
    // Start is called before the first frame update
    public GameManagerScript gameManager;
    public int pointToScore = 3;

    private void Awake()
    {
        gameManager=FindObjectOfType<GameManagerScript>();
    }
    public void CreateSicedFruit()
    {
       GameObject inst = (GameObject)Instantiate(slicedfruit,transform.position,transform.rotation);
        Rigidbody[] rbs = inst.transform.GetComponentsInChildren<Rigidbody>();
        FindObjectOfType<GameManagerScript>().PlaySound();
        foreach (Rigidbody rb in rbs)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(300, 600), transform.position, 5f);
        }
        Destroy(gameObject);
        Destroy(inst.gameObject,5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mouseScript b = collision.GetComponent<mouseScript>();
        if (!b) {
            return;
        }


        gameManager.IncreaseScore(pointToScore);

            CreateSicedFruit();
      
    }
   
}
