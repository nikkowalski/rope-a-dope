using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Title_Page
{
   
    // Use this for initialization
    void Start () {
		
	}
	//

	// Update is called once per frame
	void Update () {
		
	}
    public void MakePurchase()
    {
        print("begin Purchase button process");
        IAP_Manager.Instance.PurchaseFullGame();
        print("end Purchase button process");
    }


    public void ChangeScene(string sceneName)
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
