using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.SceneManagement;

public class GeneralManager1 : MonoBehaviour
{
	public void ReturnHome(){
		SceneManager.LoadScene(0);
	}
}
