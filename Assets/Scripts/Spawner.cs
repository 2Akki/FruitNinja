using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bomb;
    public GameObject[] objectstoSpawn;
    public Transform[] SpawnPlaces;
    public float minWait = .3f;
    public float maxWait = 1f;
 
    // Start is called before the first frame update

    private void Start()
    {

        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
         
            Transform t = SpawnPlaces[Random.Range(0, SpawnPlaces.Length)];
            GameObject go = null;
            float p = Random.Range(0, 100);


            if (p < 8)
            {
                go = bomb;
            }
            else
            {
                go= objectstoSpawn[Random.Range(0,objectstoSpawn.Length)];
            }
            GameObject fruit = Instantiate(go, t.position,t.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(14,17),ForceMode2D.Impulse);
            yield return new WaitForSeconds(Random.Range(minWait,maxWait));
        
            Destroy(fruit, 5);

        }
    }
}
