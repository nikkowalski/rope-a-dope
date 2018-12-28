using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour {


    Image myImageComponent;
    

    public Sprite[] backgroundSprite;


    public Material[] backgroundMat;

    


    void Awake()
    {
       
    }


    // Use this for initialization
    void Start () {

        // AnimateJoint();

        ChangeBackgroundImage(backgroundMat, backgroundSprite, UnityEngine.Random.Range(0, backgroundMat.Length));
       
    }
	
	// Update is called once per frame
	void Update () {
        
     
    }


    public void ChangeBackgroundImage(Material[] changeToMat, Sprite[] changeToSprt, int iter) //method to set our first image
    {
        Debug.Log("ChangeBackgroundImage(): ");

        myImageComponent = GetComponent<Image>(); //Our image component is the one attached to this gameObject.

        myImageComponent.material = changeToMat[iter];
        myImageComponent.sprite = changeToSprt[iter];

        

        

    }
    


}
