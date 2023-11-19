using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class GlobalManager : MonoBehaviour
{
    private static GlobalManager _instance;
    public static GlobalManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GlobalManager").AddComponent<GlobalManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }
    public bool isChord = true;
	public int HighScore = 0;
}


public class SettingsMenu : MonoBehaviour
{

	public AudioMixer audioMixer;
	public void PlayGame(){
		SceneManager.LoadScene(1);
	}
    public void SetVolume(float volume){
		audioMixer.SetFloat("volume", volume);
	}
	public void SetToChord(){
		if(!GlobalManager.Instance.isChord){
			GlobalManager.Instance.isChord = true;
		}
		 
	}
	public void SetToRythm(){
		if(GlobalManager.Instance.isChord){
			GlobalManager.Instance.isChord = false;
		}	 
	}


}
