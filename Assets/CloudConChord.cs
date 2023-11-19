using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
    
public class CloudConChord : MonoBehaviour
{
    public Transform[] chordObj;
    static public string spawnedYet = "n";
    static public Vector2 cloudxPos;
    public int numOfSpawnableFruits = 7;
    static public Vector2 spawnPos;
    static public string newFruit = "n";
    static public int whichChord = 0;
    public int scoreValue = 0;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: \n" + scoreValue;
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

        if (GetComponent<Rigidbody2D>().velocity.x < 0 && gameObject.transform.position.x < 18.0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (GetComponent<Rigidbody2D>().velocity.x > 0 && gameObject.transform.position.x > 21.9)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        cloudxPos = gameObject.transform.position;

        if (Input.GetKeyDown("space") && spawnedYet == "y")
        {
            spawnedYet = "n";   
        }
        if (Input.GetMouseButtonDown(0) && spawnedYet == "y")
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x < 18.0 || mousePos.x > 21.9)
            {
                mousePos.x = 20;
            }
            cloudxPos = new Vector2(mousePos.x, gameObject.transform.position.y);
            spawnedYet = "n";   
        }
    }

    void spawnFruit()
    {
        if (spawnedYet == "n")
        {
            StartCoroutine(spawnTimer());
            //Instantiate(chordObj[Random.Range(0, numOfSpawnableFruits)], transform.position, chordObj[0].rotation);
            spawnedYet = "w";
        }
    }

    void replaceFruit()
    {

        if (newFruit == "y")
        {
            scoreValue += whichChord;
            newFruit = "n";
            if (whichChord + 1 < chordObj.Length)
            {
                Instantiate(chordObj[whichChord+1], spawnPos, chordObj[0].rotation);
            } else
            {
                Instantiate(chordObj[whichChord], spawnPos, chordObj[0].rotation);
            }
        }
    }
    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(.5f);
        Instantiate(chordObj[Random.Range(0, numOfSpawnableFruits)], gameObject.transform.position, chordObj[0].rotation);
        spawnedYet = "y";
    }
}
