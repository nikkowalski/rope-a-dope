using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public static Manager Instance { set; get; }




    [SerializeField]
    public static int hasBeedPurchased = 0;

    public static string key = "hasBeedPurchased";

    public static bool isSoundPlayable;

    [SerializeField]
    public static int isEnglishPlayable = 1;
    [SerializeField]
    public static int isSpanishPlayable = 0;
    public static bool isPhrasesLoaded = true;
    public static bool canDisplayWord = true;
    public static bool checkedLang = false;

    public Font font;
    public int fontSize = 60;
    public float x = 25.0f;
    public float y = 45.0f;
    private static bool created = false;
    public static bool canReloadM = false;

    [SerializeField]
    public string winningWordString = " ";
    public Text winningWord;
    private GameObject m_testTextObject;


    Toggle m_Toggle;


    void Awake()
    {
        Instance = this;

        if (CheckIfPurchaseSaveStateExists())
        { hasBeedPurchased = PlayerPrefs.GetInt(key); print("PlayerPrefs exixted and has been set to what was in memory."); }
        else
        { PlayerPrefs.SetInt(key, hasBeedPurchased); print("PlayerPrefs Created memory for purchase"); }

       PlayerPrefs.SetInt("english", isEnglishPlayable); print(" Set playerPrefs english: " + isEnglishPlayable);
       PlayerPrefs.SetInt("spanish", isSpanishPlayable); print(" Set playerPrefs spanish: " + isSpanishPlayable);

        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {

        Screen.orientation = ScreenOrientation.LandscapeLeft;//or right for right landscape


    }

    // Update is called once per frame
    void Update()
    {

       if (isPhrasesLoaded == false) { CheckLanguage(); }
        
        SceneManagement();
    }

    bool CheckIfPurchaseSaveStateExists()
    {
        if (PlayerPrefs.GetInt(key) == 0)
        {
            print("PlayerPrefs existed and the result was zero");
            return true;
        }
        else if (PlayerPrefs.GetInt(key) == 1)
        {
            print("PlayerPrefs existed and the result was one");
            return true;
        }
        print("PlayerPrefs does not exixt");
        return false;
    }




    void SceneManagement()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Title")
        {
            checkedLang = false;
        }
        else if (sceneName == "Store")
        {
            checkedLang = false;
        }
        else if (sceneName == "game")
        {
            if(checkedLang == false) { CheckLanguage(); checkedLang = true; }

            winningWordString = Make_Master_Strain_List.chosenWordTempMem;
        }
        else if (sceneName == "Winner")
        {
            checkedLang = false;

            if (canDisplayWord == true)
            {
                m_testTextObject = new GameObject();
                m_testTextObject.transform.SetParent(GameObject.Find("Canvas").transform);
                winningWord = m_testTextObject.AddComponent<Text>();
                winningWord.name = "Winning Word";
                winningWord.text = winningWordString;
                winningWord.font = font;
                winningWord.fontSize = fontSize;
                winningWord.alignment = TextAnchor.MiddleCenter;
                winningWord.rectTransform.sizeDelta = new Vector2(900, 300);
                winningWord.rectTransform.localPosition = new Vector3(15, 40, 0);
                winningWord.color = Color.green;
                winningWord.enabled = true;
                canDisplayWord = false;
            }
        }
        else if (sceneName == "Lose")
        {
            checkedLang = false;
        }
        else if (sceneName == "Settings")
        {
            checkedLang = false;

        }



    }
    public void ChangeScene(string sceneName)
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

    }


    void CheckLanguage()
    {
        if ((isEnglishPlayable == 1) && (isSpanishPlayable == 1))
        {

            PhrasePlayer.Instance.LoadAllPhrases();
        }
        else
        if ((isEnglishPlayable == 0) && (isSpanishPlayable == 0))
        {

            PhrasePlayer.Instance.LoadEnglishPhrases();
        }
        else
        {
            if (isEnglishPlayable == 1)
            {
                PhrasePlayer.Instance.LoadEnglishPhrases();

            }
            if (isSpanishPlayable == 1)
            {
                PhrasePlayer.Instance.LoadSpanishPhrases();

            }
        }
    }



    





}