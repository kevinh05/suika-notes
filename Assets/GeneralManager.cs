using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GeneralManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReturnHome(){
		SceneManager.LoadScene(0);
	}
}
