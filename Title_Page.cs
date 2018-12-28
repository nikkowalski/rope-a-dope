using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Page :MonoBehaviour
{
  public GameObject managerPrefab;

    // Use this for initialization
    void Start()
    { 
        if (GameObject.FindWithTag("Manager") == null) { Instantiate(managerPrefab); }
    } 

        // Update is called once per frame
    void Update ()

    {
		
	}

    public void ChangeScene(string sceneName)
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

  
 
 
}
