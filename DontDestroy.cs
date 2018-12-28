using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    
    private DontDestroy instance; 


    // Use this for initialization
    void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (instance != null)
        {
            DontDestroyOnLoad(gameObject);
            
        }
    }
}
