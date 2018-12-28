using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Background_Music : MonoBehaviour{

   public static Background_Music Instance { set; get; }
   
    public int songIndexLocationInArray = 0;
    public float x, y, z;

    public int cycles = 30;

    public int secsCount = 0;

    System.DateTime songStartTime;

    public bool isSongPlaying = false;
    public bool playNextSong = false;

    public AudioClip[] audioSources;
    public AudioClip[] audioSourcesTempMem;
    public AudioClip[] tempClips;
    public bool canReInit = false;
    public bool inTitle = true;
    public bool inStore = false;
    public bool inSettings = false;
    public bool inGame = false;
    public bool inLose = false;
    public bool inWin = false;
    public bool inCredits = false;


    public AudioClip[] titleAudioSources;
    public AudioClip[] settingsAudioSources;
    public AudioClip[] storeAudioSources;
    public AudioClip[] gameAudioSources;
    public AudioClip[] loseAudioSources;
    public AudioClip[] winAudioSources;

    public Aenima<AudioClip> randomizedClips;

    public AudioSource currentBackgroundMusic;


   public float[] lengths;

    public bool seeSong = false;

    // Use this for initialization
    void Start () {
        //(GUITexture)FindObjectOfType(typeof(GUITexture))
        if (inTitle)
        { currentBackgroundMusic = GameObject.Find("MusicPlayerTitle").GetComponent<AudioSource>(); Instance = this; }
        if (inSettings)
        { currentBackgroundMusic = GameObject.Find("MusicPlayerSettings").GetComponent<AudioSource>(); Instance = this; }
        if (inStore)
        { currentBackgroundMusic = GameObject.Find("MusicPlayerStore").GetComponent<AudioSource>(); Instance = this; }
        if (inGame)
        { currentBackgroundMusic = GameObject.Find("MusicPlayerGame").GetComponent<AudioSource>(); Instance = this; }
        if (inLose)
        { currentBackgroundMusic = GameObject.Find("MusicPlayerLose").GetComponent<AudioSource>(); Instance = this; }
        if (inWin)
        { currentBackgroundMusic = GameObject.Find("MusicPlayerWinner").GetComponent<AudioSource>(); Instance = this; }
        if (inCredits)
        { currentBackgroundMusic = GameObject.Find("MusicPlayerCredits").GetComponent<AudioSource>(); Instance = this; }



        Init();

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (canReInit == true) { Init();  }

        if (isSongPlaying == true)
        {
           SongTimer();
        }

        if(seeSong == true)
        {
            GetSongName();
        }
        

    }
    
    void GetSongName()
    {
        print(currentBackgroundMusic.clip.ToString());
        seeSong = false;
    }

    public void Init()
    {
        if (canReInit == true) { currentBackgroundMusic.Stop(); canReInit = false; }
        isSongPlaying = false;
        GetScenePlayList();
        //GetLengths();


        UpdateSong(tempClips);
    }


    void GetLengths()
    {
        lengths = new float[tempClips.Length];

        for (int iter = 0; iter < tempClips.Length; iter++)
        {
            lengths[iter] = tempClips[iter].length;

        }

    }
    void SongTimer()
    {
        System.DateTime now = System.DateTime.UtcNow;
        System.TimeSpan difference = now - songStartTime; // could also write `now - otherTime`
     // Debug.Log("Now: " + now + "\n -  \n" + "Song start Time: " + songStartTime + "\n = difference: " + difference);
       // Debug.Log("difference: " + difference);

        if (difference.TotalSeconds > currentBackgroundMusic.clip.length)
        {
            //Debug.Log("Incrementing to next song. Previous: " + songIndexLocationInArray );
            songIndexLocationInArray++;
            //Debug.Log("Incremented: " + songIndexLocationInArray);
            isSongPlaying = false;
            //Debug.Log("Previous difference: " + difference);
            difference = now - now;
           // Debug.Log("Reset difference: " + difference);
            UpdateSong(tempClips);

        }
    }

   

    void UpdateSong(AudioClip[] m_audioSources)
    {

       

        if (songIndexLocationInArray >= 0 && songIndexLocationInArray <= m_audioSources.Length)
        {
            Debug.Log("Index was in bounds.");
            if (isSongPlaying == false)
            {
                if (songIndexLocationInArray == 0)
                {
                    Debug.Log("Song is at zero, playing. So begining song loop.");
                    PlayBackgroundMusic(songIndexLocationInArray);
                }
                else { Debug.Log("Song is not playing and not at zero."); }
               
                
            }
           

        }
        if(songIndexLocationInArray == m_audioSources.Length && isSongPlaying == false)
        {
            Debug.Log("Last Song was played, lets reset loop.");
         
            Debug.Log("Setting to zero");
            songIndexLocationInArray = 0;
            isSongPlaying = false;
            Debug.Log("Song is no longer playing, loop should reset.");

        }

       

        if (isSongPlaying == false)
        { Debug.Log("Song was not plating, playing. So playing song."); PlayBackgroundMusic(songIndexLocationInArray); }




    }

    void WaitForSecs(float timeToWait)
    {
        Debug.Log("Waiting for..." + timeToWait+" seconds...");
        System.Threading.Thread.Sleep((int)(timeToWait * 1000));
        //yield return  new  WaitForSecondsRealtime(timeToWait);

    }
    


    void PlayBackgroundMusic(int memoryLocationOfAudioSources)
    {

        if (inGame == true)
        {


            currentBackgroundMusic.clip = tempClips[Random.Range(0, tempClips.Length-1)];
            Debug.Log("Playing clip at " + memoryLocationOfAudioSources + " location. Setting isSongPlaying to true.");
            currentBackgroundMusic.Play();
            currentBackgroundMusic.volume = 0.2f;
            songStartTime = System.DateTime.UtcNow;
            isSongPlaying = true;
            secsCount = 0;
        }
        else
        {
            if (memoryLocationOfAudioSources < tempClips.Length && memoryLocationOfAudioSources >= 0)
            {
                currentBackgroundMusic.clip = tempClips[memoryLocationOfAudioSources];
                Debug.Log("Playing clip at " + memoryLocationOfAudioSources + " location. Setting isSongPlaying to true.");
                currentBackgroundMusic.Play();
                currentBackgroundMusic.volume = 0.5f;
                songStartTime = System.DateTime.UtcNow;
                isSongPlaying = true;
                secsCount = 0;
            }
        }



    }


   


    void GetScenePlayList( )
    {
       

        if (inTitle == true)
        {
           PlayMusicTitle();

        }
        if(inSettings)
        {  PlayMusicSettings(); }
        if(inStore)
        {  PlayMusicStore();  }
        if(inGame)
        {  PlayMusicGame(); }
        if(inLose)
        {  PlayMusicLose(); }
        if(inWin)
        {  PlayMusicWin(); }
        if (inCredits)
        { PlayMusicCredits(); }

    }
   void  PlayMusicCredits()
    {
        tempClips = new AudioClip[audioSources.Length];
        for (int iter = 0; iter < audioSources.Length; iter++)
        {
            if (iter == audioSources.Length) { return; }
            tempClips[iter] = audioSources[iter];
        }

    }
    void PlayMusicTitle()
    {
        tempClips = new AudioClip[titleAudioSources.Length];
        for (int iter = 0; iter < titleAudioSources.Length; iter++)
        {
            if (iter == titleAudioSources.Length) { return; }
            tempClips[iter]  = titleAudioSources[iter];
        }

       
    }

     void PlayMusicGame()
     {
        tempClips = new AudioClip[gameAudioSources.Length];
        for (int iter = 0; iter < gameAudioSources.Length; iter++)
        {
            if (iter >= gameAudioSources.Length) { return; }
            else
            {
                tempClips[iter] = gameAudioSources[iter];
            }
        }


     }

    void PlayMusicSettings( )
    {
        tempClips = new AudioClip[settingsAudioSources.Length];
        for (int iter = 0; iter < settingsAudioSources.Length; iter++)
        {
            if(iter == settingsAudioSources.Length) { return; }
            tempClips[iter] = settingsAudioSources[iter];
        }


    }

    void PlayMusicStore()
    {
        tempClips = new AudioClip[storeAudioSources.Length];
        for (int iter = 0; iter < storeAudioSources.Length; iter++)
        {
            if (iter == storeAudioSources.Length) { return; }
            tempClips[iter] = storeAudioSources[iter];
        }


    }

    void PlayMusicLose()
    {
        tempClips = new AudioClip[loseAudioSources.Length];
        for (int iter = 0; iter < loseAudioSources.Length; iter++)
        {
            if (iter == loseAudioSources.Length) { return; }
            tempClips[iter] = loseAudioSources[iter];
        }


    }

    void PlayMusicWin()
    {
        tempClips = new AudioClip[winAudioSources.Length];
        for (int iter = 0; iter < winAudioSources.Length; iter++)
        {
            if (iter == winAudioSources.Length) { return; }
            tempClips[iter] = winAudioSources[iter];
        }


    }




    public  void PlayNextSong()
    {
        currentBackgroundMusic.Stop();
        isSongPlaying = false;

        UpdateSong(tempClips);
    }

}
