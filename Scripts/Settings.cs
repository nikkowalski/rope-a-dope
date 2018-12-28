using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static Settings Instance { set; get; }


   public Toggle englishButton;
   public Toggle spanishButton;




    // Use this for initialization
    void Start()
    {
       // Instance = this;

       
        if ((PlayerPrefs.GetInt("spanish") == 1) && (PlayerPrefs.GetInt("english") == 1))
        { spanishButton.GetComponent<Toggle>().isOn = true; englishButton.GetComponent<Toggle>().isOn = true; PhrasePlayer.Instance.LoadAllPhrases(); }
        else if ((PlayerPrefs.GetInt("spanish") == 0) && (PlayerPrefs.GetInt("english") == 0))
        { spanishButton.GetComponent<Toggle>().isOn = false; englishButton.GetComponent<Toggle>().isOn = true; PhrasePlayer.Instance.LoadEnglishPhrases(); }
        else{


            if (PlayerPrefs.GetInt("english") == 1)
            { englishButton.GetComponent<Toggle>().isOn = true; PhrasePlayer.Instance.LoadEnglishPhrases(); }
            else if (PlayerPrefs.GetInt("english") == 0)
            { englishButton.GetComponent<Toggle>().isOn = false; }


            if (PlayerPrefs.GetInt("spanish") == 1)
            { spanishButton.GetComponent<Toggle>().isOn = true; PhrasePlayer.Instance.LoadSpanishPhrases(); }
            else if (PlayerPrefs.GetInt("spanish") == 0)
            { spanishButton.GetComponent<Toggle>().isOn = false; }




        }
       
       

        //check if toggle is on
        //if toggle is on... update Toggle.graphic is set to Playerprefs.
        //esle toggle is off... update Toggle.graphic is set to 0

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ToggleMute(bool valueToChangeTo)
    {
        if (Manager.isSoundPlayable == true)
        {
            Manager.isSoundPlayable = false;
        }
        else
        {
            if (Manager.isSoundPlayable == false)
            {
                Manager.isSoundPlayable = true;
            }
        }


    }


    public void QuitGame(bool key)
    {
        Debug.Log("you pressed quit");
        Application.Quit();

    }

  

    public void ToggleEnglish()
    {
        print("Entered ToggleEnglish");

        if ((Manager.isEnglishPlayable == 1) && (Manager.isSpanishPlayable == 1))
        {
            print("Entered English 1 and spanish 1");
            Manager.isEnglishPlayable = 0; print("isEnglishPlayable: " + Manager.isEnglishPlayable);
            PlayerPrefs.SetInt("engligh", 0); print("PlayerPrefs.GetInt(\"english\"): " + PlayerPrefs.GetInt("english"));
            Manager.isSpanishPlayable = 1; print("isSpanishPlayable: " + Manager.isSpanishPlayable);
            PlayerPrefs.SetInt("spanish", 1); print("PlayerPrefs.GetInt(\"spanish\"): " + PlayerPrefs.GetInt("spanish"));
            spanishButton.GetComponent<Toggle>().isOn = true;


            Manager.isPhrasesLoaded = false;

            PhrasePlayer.canReInitPhrases = true;
            // print("reinitializing phrases");
        }
        if ((Manager.isEnglishPlayable == 0) && (PlayerPrefs.GetInt("spanish") == 0))
        {
            print("Entered English 0 and spanishMem 0");
            Manager.isEnglishPlayable = 1; print("isEnglishPlayable: " + Manager.isEnglishPlayable);
            PlayerPrefs.SetInt("engligh", 1); print("PlayerPrefs.GetInt(\"english\"): " + PlayerPrefs.GetInt("english"));
            Manager.isSpanishPlayable = 0; print("isSpanishPlayable: " + Manager.isSpanishPlayable);
            PlayerPrefs.SetInt("spanish", 0); print("PlayerPrefs.GetInt(\"spanish\"): " + PlayerPrefs.GetInt("spanish"));
            spanishButton.GetComponent<Toggle>().isOn = false;


            Manager.isPhrasesLoaded = false;

            PhrasePlayer.canReInitPhrases = true;
            // print("reinitializing phrases");
        }
        else if (Manager.isEnglishPlayable == 1)
        {
            print("Entered English 1");
            Manager.isEnglishPlayable = 0; print("isEnglishPlayable: " + Manager.isEnglishPlayable);            
            PlayerPrefs.SetInt("engligh", 0); print("PlayerPrefs.GetInt(\"english\"): " + PlayerPrefs.GetInt("english"));
            


            Manager.isPhrasesLoaded = false;

           PhrasePlayer.canReInitPhrases = true;
           // print("reinitializing phrases");
        }
        else if (Manager.isEnglishPlayable == 0)
        {
                print("Entered English 1");
                Manager.isEnglishPlayable = 1; print("isEnglishPlayable: " + Manager.isEnglishPlayable);                
                PlayerPrefs.SetInt("engligh", 1); print("PlayerPrefs.GetInt(\"english\"): " + PlayerPrefs.GetInt("english"));
                Manager.isPhrasesLoaded = false;
               PhrasePlayer.canReInitPhrases = true;

              //  print("reinitializing phrases");
            

        }
    }

    public void ToggleSpanish()
    {
        print("Entered ToggleSpanish");

        if ((Manager.isSpanishPlayable == 1 ) && (Manager.isEnglishPlayable == 1))
        {
            print("Entered Spanish 1 and English 1");
            Manager.isSpanishPlayable = 1; print("isSpanishPlayable: " + Manager.isSpanishPlayable);
            PlayerPrefs.SetInt("spanish", 1); print("PlayerPrefs.GetInt(\"spanish\"): " + PlayerPrefs.GetInt("spanish"));
            Manager.isEnglishPlayable = 0; print("isEnglishPlayable: " + Manager.isEnglishPlayable);
            PlayerPrefs.SetInt("engligh", 0); print("PlayerPrefs.GetInt(\"english\"): " + PlayerPrefs.GetInt("english"));
            englishButton.GetComponent<Toggle>().isOn = false;
            Manager.isPhrasesLoaded = false;
            PhrasePlayer.canReInitPhrases = true;
            // print("reinitializing phrases");

        }
        else if ((Manager.isSpanishPlayable == 0) && (Manager.isEnglishPlayable == 0))
        {
            print("Entered Spanish 0 and English 0");
            Manager.isSpanishPlayable = 0; print("isSpanishPlayable: " + Manager.isSpanishPlayable);
            PlayerPrefs.SetInt("spanish", 0); print("PlayerPrefs.GetInt(\"spanish\"): " + PlayerPrefs.GetInt("spanish"));
            Manager.isEnglishPlayable =1; print("isEnglishPlayable: " + Manager.isEnglishPlayable);
            PlayerPrefs.SetInt("engligh", 1); print("PlayerPrefs.GetInt(\"english\"): " + PlayerPrefs.GetInt("english"));
            englishButton.GetComponent<Toggle>().isOn = true;
            Manager.isPhrasesLoaded = false;
            PhrasePlayer.canReInitPhrases = true;
            // print("reinitializing phrases");

        }
        else if (Manager.isSpanishPlayable == 1)
        {
            print("Entered Spanish 1");

            Manager.isSpanishPlayable = 0; print("isSpanishPlayable: " + Manager.isSpanishPlayable);
            PlayerPrefs.SetInt("spanish", 0); print("PlayerPrefs.GetInt(\"spanish\"): " + PlayerPrefs.GetInt("spanish"));
            Manager.isPhrasesLoaded = false;
            PhrasePlayer.canReInitPhrases = true;
            // print("reinitializing phrases");
        }
        else if (Manager.isSpanishPlayable == 0)
        {
            print("Entered Spanish 0");
            Manager.isSpanishPlayable = 1; print("isSpanishPlayable: " + Manager.isSpanishPlayable);
            PlayerPrefs.SetInt("spanish", 1); print("PlayerPrefs.GetInt(\"spanish\"): " + PlayerPrefs.GetInt("spanish"));
            Manager.isPhrasesLoaded = false;
            PhrasePlayer.canReInitPhrases = true;
            // print("reinitializing phrases");
        }

        
    }
}


