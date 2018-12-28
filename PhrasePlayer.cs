using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhrasePlayer : MonoBehaviour {

    public static PhrasePlayer Instance { set; get; }

    public AudioSource phrasePlayer;
    AudioClip ac;
    public  Aenima<AudioClip> phrasesQueue;

    public AudioClip[] phrasesArrayEnglish ;


    public AudioClip[] phrasesArraySpanish;


   

   

    static public int englighPlayable = 1;
    static public int spanishPlayable = 0;
    public static bool canReInitPhrases = false;
    public  bool canPlayPhrase = false;

    public AudioClip[] audioClipMemory;
    private static PhrasePlayer _instance;

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start () {
        Instance = this;
        LoadAllPhrases();
    }
	
	// Update is called once per frame
	void Update () {
      //if (PlayerPrefs.GetInt("english") == 1) { englighPlayable = PlayerPrefs.GetInt("english"); print( "english: " + englighPlayable ); }
      // if (PlayerPrefs.GetInt("spanish") == 1) { spanishPlayable = PlayerPrefs.GetInt("spanish"); print("spanish: " + spanishPlayable); }

        if (canReInitPhrases == true) { LoadAllPhrases(); canReInitPhrases = false; }
        if (canPlayPhrase == true) { PlayPhrase(); if (canPlayPhrase == true) { print("canPlayPhrase was true for some reason.");  canPlayPhrase = false; } canPlayPhrase = false; }
    }
   
    public void LoadPhrases()
    {

        if ((PlayerPrefs.GetInt("english") == 1) && (PlayerPrefs.GetInt("spanish") == 1))
        {
            LoadAllPhrases();


        }
        else
        {
            if ((PlayerPrefs.GetInt("english") == 1 )&& (PlayerPrefs.GetInt("spanish") == 0))
            {
                LoadEnglishPhrases();

            }
            if ((PlayerPrefs.GetInt("spanish") == 1) && (PlayerPrefs.GetInt("english") == 0))
            {
                LoadSpanishPhrases();

            }
        
            if ((PlayerPrefs.GetInt("spanish") == 0) && (PlayerPrefs.GetInt("english") == 0))
            {
                print("reinitializing phrases - default");
              Manager.isEnglishPlayable = 1;
                PlayerPrefs.SetInt("english", 1);
              Settings.Instance.englishButton.GetComponent<Toggle>().isOn = true;
              LoadEnglishPhrases();
              
            }
        }
       
    } 
    public void LoadAllPhrases()
    {

        phrasesQueue = new Aenima<AudioClip>(audioClipMemory.Length);
        for (int iter = 0; iter < audioClipMemory.Length; iter++)
        {
            if (iter == audioClipMemory.Length) { break; }
            phrasesQueue.addItem(audioClipMemory[iter]);

        }


          
            Manager.isPhrasesLoaded = true;
    }

    public void LoadEnglishPhrases()
    {

        
        print("reinitializing phrases - english");
        phrasesQueue = new Aenima<AudioClip>(phrasesArrayEnglish.Length);
        for (int phraseEnglish = 0; phraseEnglish < phrasesArrayEnglish.Length; phraseEnglish++)
        {
            if (phraseEnglish == phrasesArrayEnglish.Length) { break; }
            phrasesQueue.addItem(phrasesArrayEnglish[phraseEnglish]);
        }

        
        Manager.isPhrasesLoaded = true;
    }

    public void LoadSpanishPhrases()
    {
        print("reinitializing phrases - spanish");
        phrasesQueue = new Aenima<AudioClip>(phrasesArraySpanish.Length);
        for (int phraseSpanish = 0; phraseSpanish < phrasesArraySpanish.Length; phraseSpanish++)
        {
            if (phraseSpanish == phrasesArraySpanish.Length) { break; }
            phrasesQueue.addItem(phrasesArraySpanish[phraseSpanish]);
        }
     
        Manager.isPhrasesLoaded = true;
    }


   

    public void PlayPhrase()
    {
        ac = phrasesQueue.getNext();
        print(ac);
        phrasePlayer.clip = ac;
        phrasePlayer.Play();
        phrasePlayer.volume = 1.0f;
        canPlayPhrase = false; print(canPlayPhrase);
    }
    
}
