using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
    
public class CloudCon : MonoBehaviour
{
    public Transform[] fruitObj;
    static public string spawnedYet = "n";
    static public Vector2 cloudxPos;
    public int numOfSpawnableFruits = 2;
    static public Vector2 spawnPos;
    static public string newFruit = "n";
    static public int whichFruit = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnFruit();
        replaceFruit();

        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
        }
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(4, 0);
        }
        if ((!Input.GetKey("a")) && (!Input.GetKey("d")))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (GetComponent<Rigidbody2D>().velocity.x < 0 && transform.position.x < -2.05)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (GetComponent<Rigidbody2D>().velocity.x > 0 && transform.position.x > 2.0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        cloudxPos = transform.position;

        if (Input.GetKeyDown("space") && spawnedYet == "y")
        {
            spawnedYet = "n";   
        }
    }

    void spawnFruit()
    {
        if (spawnedYet == "n")
        {
            StartCoroutine(spawnTimer());
            //Instantiate(fruitObj[Random.Range(0, numOfSpawnableFruits)], transform.position, fruitObj[0].rotation);
            spawnedYet = "w";
        }
    }

    void replaceFruit()
    {
        if (newFruit == "y")
        {
            newFruit = "n";
            if (whichFruit + 1 < fruitObj.Length)
            {
                Instantiate(fruitObj[whichFruit+1], spawnPos, fruitObj[0].rotation);
            } else
            {
                Instantiate(fruitObj[whichFruit], spawnPos, fruitObj[0].rotation);
            }
        }
    }
    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(.5f);
        Instantiate(fruitObj[Random.Range(0, numOfSpawnableFruits)], transform.position, fruitObj[0].rotation);
        spawnedYet = "y";
    }
}
