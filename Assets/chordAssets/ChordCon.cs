using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordCon : MonoBehaviour
{
    private string inTheCloud = "y";
    private string timeToCheck = "n";
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.position.y < 4.3)
        {
            inTheCloud = "n";
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inTheCloud == "y")
        {
            GetComponent<Transform>().position = CloudConChord.cloudxPos;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            inTheCloud = "n";
            StartCoroutine(checkGameOver());
            //CloudCon.spawnedYet = "n";
        }
    }

private void OnCollisionEnter2D(Collision2D collision)
{

    string toCreate = "";

    Dictionary<string, int> combos = new Dictionary<string, int>()
    {
        { "a", 0 },
        { "b", 1 },
        { "c", 2 },
        { "d", 3 },
        { "e", 4 },
        { "f", 5 },
        { "g", 6 },
        { "ac", 7 },
        { "ce", 8 },
        { "ae", 9 },
        { "eg", 10 },
        { "cg", 11 },
        { "fa", 12 },
        { "fc", 13 },
        { "gb", 14 },
        { "bd", 15 },
        { "gd", 16 },
        { "df", 17 },
        { "da", 18 },
        { "ace", 19 },
        { "ceg", 20 },
        { "fac", 21 },
        { "gbd", 22 },
        { "dfa", 23 }
    };

    if (combos.ContainsKey(gameObject.tag + collision.gameObject.tag))
    {
        toCreate = gameObject.tag + collision.gameObject.tag;
    }
    else if (combos.ContainsKey(collision.gameObject.tag + gameObject.tag))
    {
        toCreate = collision.gameObject.tag + gameObject.tag;
    }


    if (toCreate != "")
    {
        CloudConChord.spawnPos.x = (this.transform.position.x + collision.collider.transform.position.x) / 2;
        CloudConChord.spawnPos.y = (this.transform.position.y + collision.collider.transform.position.y) / 2;
        CloudConChord.newFruit = "y";
        CloudConChord.whichChord = combos[toCreate];
        Destroy(gameObject);
    }
}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name=="limit" && timeToCheck == "y") 
        {
            Debug.Log("game over");

            // Scene Manager.LoadScene
        }
    }

    IEnumerator checkGameOver()
    {
        yield return new WaitForSeconds(.75f);
        timeToCheck = "y";
    }
}
