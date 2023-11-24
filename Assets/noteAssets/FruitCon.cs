using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCon : MonoBehaviour
{

	//		[SerializeField] private AudioSource dropSoundEffect;
	//[Header("------")]

    private string inTheCloud = "y";
    private string timeToCheck = "n";

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y < 4.3)
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
            GetComponent<Transform>().position = CloudCon.cloudxPos;
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
        if (collision.gameObject.tag == gameObject.tag)
        {
            CloudCon.spawnPos.x = (this.transform.position.x + collision.collider.transform.position.x) / 2;
            CloudCon.spawnPos.y = (this.transform.position.y + collision.collider.transform.position.y) / 2;
            CloudCon.newFruit = "y";
            CloudCon.whichFruit = int.Parse(gameObject.tag);
            Destroy(gameObject);
			//dropSoundEffect.play();
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
