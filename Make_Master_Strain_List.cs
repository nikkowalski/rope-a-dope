using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Make_Master_Strain_List : MonoBehaviour
{

    public GameObject manager;

    private Aenima<string> aenimaForCurrentWords;
                       
    public string[] wordsTempMem;

    private string[] wordsList2 = { "J1" };
    private string[] wordsList3={"Pot","THC","Flo","LSD","WWJD","Bud","Wappa","Y2K","Hog","CH9"};
    private string[] wordsList4 ={"Creeper","Winning","Jesus","Yoda","G-14","Reggie","Cheese","Loud",
                                 "Maui","Papaya","OG-b","OG-d","Tessa","Grass","Ganja","Skunk",
                                 "Sense","Troll","Onyx","Gack","Dank","Mazar","Top44","Dabbs",
                                 "Haze","Kind","Dope","B-52","Green","R-18","G-13"};
    private string[] wordsList5 ={"A-Dub","Kizzle","BLZ Bud","Rocklock","Unknown","T-Rex","God Bud",
                                 "$100 OG","Oger99","Caviar","Tora Bora","Venom","Hawaiian",
                                 "Big Bang","OG Obama","Cheesel","Diesel","Joint","Dr Pepper",
                                 "Mandala","Sativa","Venus","Mr Magoo","Stank","Opium","X-dog","AK-47"};
    private string[] wordsList6 ={"Mango Tango","BlueBerry","Red Beard","Nebula","Sprite","Perplex","The Perp","The White","BC God Bud","AMG MARY OG","Sonoma Coma","TARDIS",
                                 "Grape Ape","Queen Green","Meroin","Yoda OG","Shiva X","Cream Caramel","Chiesel","Route 66","Querkle","Skink #9","Sweet Seeds","Headband",
                                 "Peace Man","Indica","Hybrid","Shatter","Jock Horror","Brand X","Bogart","Catpiss","Django","Doobage","Sniper","Riddler","Zeta Sage",
                                 "Zona Ganja","Xavier","X-Haze","Nebula","Nefertiti","Vortex","Domina","Nigeria"};
    private string[] wordsList7 ={"Head Cheese","Chem Dog","PsychOG","Banana Kush","Matt’s OG","Aspen OG","Kosher Kush","Moon Rocks","Ice Mist","Crystal","Cherry Pie",
                                 "Nice Guy","Grape God","Jasmine","Pit-Bull","Blue God","Bubba Kush","Sweet Tooth","Jack Herer","Banana Kush","OG Mango","Doctor Who",
                                 "UBC Chemo","Aqualung","Pick Axe","Romulan","OG Spock","Super Goo","Sublime","The Purp","Perma hash","Sweet Cheese","Mohan Ram",
                                 "Bogglegum","Death Star","Chocolope","Hail Satan","Amnesia","The Joker","Hash Dawg","Early Girl","Fourway","Appalachia",
                                 "Carl Sagan","Cannatonic","Catfish","Dog Shit","Marijuana","Mary Jane","Bongload","Warlock","Zimbabwe","Y Griega","Narkush",
                                 "Nepal Baba","Mr. Nice"};
    private string[] wordsList8 ={"Skunkberry","Rugburn OG","Golden Goat","Hello Kitty","Purple Urkel","Juicy Fruit","Free Leonard","Blue Dream","High Milds",
                                 "Green Crack","Tangie Land","Sorry Sucker","Bentley OG","Super Noff","UK Psycosis","Death Berry","Kandy Skunk","Pink Lady",
                                 "Sweet Dutch","Green Kush","The Master","Time Traveler","Dream Queen","Triple Diesel","Skywalker","Special K","Runuponyah",
                                 "MK-Ultra","White Rhino","Maui Wowie","Maui Wokie","Dr Grinspoon","Dr Felgud","Dynamite","Herijuana","Silver Tip",
                                 "Hash Plant","Sensi Star","Mean Green Martian","CASEY JONES","Purple Butter","The Magic","L.A. Woman","Superman",
                                 "Lex Luthor","The Batman","Euphoria","Jack Flash","Super Girl","Pipe Dream","Atomic Goat","Bio-Jesus","Blue Magoo",
                                 "Candy Jack","Canna-Sutra","Day Tripper","Green Goblin","Jedi Kush","Jungle Fungus","Cromagnin"}
;
    private string[] wordsList9 ={"Bruce Banner #3","Blue Cookies","SFV Headband","G-13 Widow","Master Yoda","Loud Cookies","Hustler Kush",
                                 "White Dawg","Red Dragon","SFV OG Kush","Train Wreck","Durbin Poison","Swazi Gold","Scooby Snacks",
                                 "Sour Diesel","Lemon Kush","Grape Fruit","Cherry Kola","Dairy Queen","Tangerine Dream","Purple Haze",
                                 "Chernobyl","Purple Wreck","Purple Dogg","Master Kush","OG Doctor Who","Premium KB Killer","Hawaiian Punch",
                                 "Alien Dawg","Grape Sorbet","Incrediberry","SpiderMan","Jethro Tul","Redwood Kush","Obama OG Kush",
                                 "Mud Bright","Thanks Obama","Minecraft","Blueberry Yum Yum","Dutch Treat","Walk on Water",
                                 "Sharks Breath","Charlie Sheen","Tiger Blood","Crack Kush","Jazz Cigarette","91 Chemdog",
                                 "Hawaiian Big Bud","Phoenix Sun","George Bush","Marilyn Monroe","Is This Thing on?","Nelson Mandala",
                                 "Kryptonite","Hong Kong Star","Trichomes","Early Misty","Hollands Hope","Snow White",
                                 "Turtle Power","Alien Asshat","Alien Dawg","Alien Kush","Americano","Asian Fantacy","Atmosphere",
                                 "Candlejack","Danky Doodle","Viet Chong","Tom Bombadill","Hobo Harvest","Chinstrap","Pineapple Express",
                                 "Arabian Crime","Oracle Bud","Zilvermist","Neon Super Skunk"};
    private string[] wordsList10 ={"Tickle Kush","Tiger’s Milk","Kepler 22B Kush","Big Buddha Cheese","Jamacian Coffee","Cherry Cough Syrup","Forest Skunk",
                                 "Super Sour Diesel","White Russian","Jacks Cleaner","Luke Skywalker","Purple Maroc","This Girl is Easy","Yoda OG Kush",
                                 "Concord Kush","Black Rhino","OG Darth Vader","Jolly Rancher","A Perfect Circle","Sannies Herijuana","Cali Outdoor",
                                 "Tsunami Crush","Asian Karaoke","Full Melt Hash","Full Metal Hash","Aurora Indica","Brains Damage","Dream Police",
                                 "Jolly Green Banana","Tapanga Brain Gank","GED Test Prep","Solven Hestin","Orient Express","Optimus Prime",
                                 "Orange Apollo","Zero Gravity","High Voltage","Mr. Nice Guy"};
    private string[] wordsList11 ={"Southwest Stomper","Blue Diamond","This is Permenant","Pinnapple Express","Granddaddy Purple",
                                 "Orange Widow","Colombian Sunk","One Eyed Jamaican","Knightrider Kush","Northern Lights",
                                 "Tangerine Kush","Super Silver Haze","Pineapple Kush","Venom OG Kush","Welcome to Earth",
                                 "Issac Newstrain","Sweet Seeds Cream Caramel","Queen of Hearts","Ninja Turtle","Blue Dynamite",
                                 "Harry Pot Smoker","California Dream","Midnight toker","Natural Mystic","Blissful Wizzard",
                                 "Redheaded Stepchild","Short Term What?","Polynesian Pink Eye","Manchurian Candy","Narcotic Kush"};
    private string[] wordsList12 ={"Holy Grail Kush","White Fire OG Kush","Chicago Marijuana","Strawberry Kush","Sweet Deep Grapefruit",
                                 "Black Rhino OG","OG Michael Phelps","Found My Religion","Whitaker Blues","The Sorcerer is Stoned",
                                 "Boy Scout Cookies","Incredible Hulk","Kongales Crippler","Vancouver Salad","Bottomless Brushfire",
                                 "Mojave Dry Mouth","Cambodian Ball Gag"};
    private string[] wordsList13 ={"Girl Scout Cookies","Presidential Kush","Black Cherry Soda","Pakistan Chitral Kush",
                                 "Thunder Buddies for Life","Strawberry Cough","Platinum Bubba Kush","Sticky Icky OG Kush",
                                 "The Real Sticky Icky","Diamond Pick Axe","Shiva The Destroyer","Murphys Mountain Kush",
                                 "Fucking Incredible","Short Buss Bio-Fuel"};
    private string[] wordsList14 ={"OG Ghost Train Haze","Skywalker OG Kush","Alaskan Thunderfuck","Dude Where is My Car?",
                                 "Purple Monkey Balls","Accidental Tourist","Tetrahydrocannabinol"};
    private string[] wordsList15 ={"Alaskan Thunder Bolt","Weapons of Mass Destractions",
                                 "Black Rhino OG Kush","Captian Kirk Knocked Me Up"};
    private string[] wordsList17 = { "Veganic Strawberry Cough", "Platinum Girl Scout Cookies", "Arizonan Western Light Purp" };


    private string[] freeWords = { "Veganic Strawberry Cough", "Platinum Girl Scout Cookies", "Arizonan Western Light Purp",
                                  "Alaskan Thunder Bolt","Weapons of Mass Destractions","Black Rhino OG Kush", "Tetrahydrocannabinol",
                                  "OG Ghost Train Haze","Alaskan Thunderfuck","Strawberry Cough","Girl Scout Cookies","Murphys Mountain Kush",
                                  "Kongales crippler","Vancouver Salad","Cambodian Ball Gag","One Eyed Jamaican","Knightrider Kush",
                                  "Northern Lights","Full Metal Hash","Aurora Indica","GED Test Prep","Loud Cookies","Hustler Kush",
                                  "White Dawg","Tangie Land","Green Crack","UK Psycosis","Dog Shit","Marijuana","Mary Jane",
                                  "Cream Caramel","Chiesel","Route 66","A-Dub","Sativa","AK-47","Creeper","Reggie","B-52","THC","Wappa","Bud"};

    private static string wordChosen = "";
    public static string chosenWordTempMem = "";

    string[] defaultButtonNames = { "1", "2","3","4","5","6","7","8","9","0","Quit",
                                    "Q","W","E","R","T","Y","U","I","O","P","Light",
                                    "A","S","D","F","G","H","J","K","L","'","Cough",
                                    "Z","X","C","V","B","N","M","-","#","?","Hit"};

    int[] defaultButtonValues = { 0, 1,2,3,4,5,6,7,8,9,10,
                                    11,12,13,14,15,16,17,18,19,20,21,
                                    22,23,24,25,26,27,28,29,30,31,32,
                                    33,34,35,36,37,38,39,40,41,42,43};

    string[] buttonNames = { "1", "2","3","4","5","6","7","8","9","0","Quit",
                             "Q","W","E","R","T","Y","U","I","O","P","Light",
                             "A","S","D","F","G","H","J","K","L","'","Cough",
                             "Z","X","C","V","B","N","M","-","#","?","Hit"};

    private string guessWord = "";
    public string message = "";

    public int attempts = 0;
    public int totalLettersToGuess = 0;
    private int keyboardOffsetX = 147;
    private int keyboardOffsetY = 247;
    public int totalLettersGuessed = 0;



    public AudioClip[] coughs;
    public AudioClip[] lighterFlicks;
    public AudioClip[] jointHit;
    public AudioClip[] bongHit;

    public AudioSource noiseMaker;



    public bool isSpaces = false;
    public static bool hasBeedPurchased = false;
    bool[] buttons;
    bool canPlayFlag = true;
  
    bool menuFlag = false;
    public bool  isNoisePlaying = false;
    public List<char> listOfCharNoSpacesNoDupes;

    List<char> charsToGuess = new List<char>();
    private Aenima<char>  freeCharReveal;


    public char[] charsArrayNoSpacesNoDupes;

    char freeGuessedChar = ' ';
    char blank = ' ';
    char underscore = '|';
    string tempCharMem = " ";



    public GUIStyle spliffs = new GUIStyle();
    public GUIStyle sweetLeaf = new GUIStyle();
    public Texture joint_roach;
    public Texture joint_hit;
    public Texture joint_burningEnd;

    int burntEndPosX = 0;

    public int x = 210;
    public int y = 6;
    public int z = 30;
    public int c = 330;
 
   

    public Font splif;
    public Font sLeaf;



    public float guessWordPosX = 100.00f;
    public float guessWordPosY = 100.00f;

    System.DateTime noiseStartTime;
      
   

    void OnAwake()
    {
      
    }

    void Start()
    {
        buttons = new bool[buttonNames.Length];
        GenerateList();
        ChoseWordFromList(wordsTempMem);
        charsToGuess = RemoveDuplicates(wordChosen);
        attempts = CalcAttempts(charsToGuess);
        totalLettersToGuess = CalcAttempts(charsToGuess);
        guessWord = HideGuessWord(wordChosen);

    }


    void Update()
    {


    }




    void OnGUI()
    {
        //GUI.skin.font = f;
        // GUI.Label(new Rect(10, 10, 100, 30), "Hello World!");
        spliffs.font = splif;
        spliffs.fontSize = ((150 - 29) / 25) * (28 - guessWord.Length) + 23;

        sweetLeaf.font = sLeaf;

        GUI.DrawTexture(new Rect(20, 20, 20, 20), joint_roach, ScaleMode.StretchToFill, false, 100.0F);
        for (int i = 0; i < attempts; i++)
        {
            if (i < attempts)
            {
                burntEndPosX = (40 + (20 * i));
                GUI.DrawTexture(new Rect(40 + (20 * i), 20, 20, 20), joint_hit, ScaleMode.StretchToFill, false, 100.0F);
            }
        }
        GUI.DrawTexture(new Rect(burntEndPosX, 20, 20, 20), joint_burningEnd, ScaleMode.StretchToFill, false, 100.0F);

        GUI.Label(new Rect((Screen.width / 2) - 200, (Screen.height / 2) - guessWordPosY, Screen.width / 2, Screen.height / 2), guessWord, spliffs);
        // GUI.Box(new Rect(45, 20, attempts * 25, 10), "attempts");

        //GUI.Label(new Rect(50, 50, 50, 50), "" + attempts + "");
        GUI.Label(new Rect(x, y, c, z), message);
        Keyboard();
    }


    void ReInitialize()
    {
       
        ResetButtons();

        if (Manager.hasBeedPurchased == 1)
        { GenerateList(); }
        ChoseWordFromList(wordsTempMem);
        charsToGuess = RemoveDuplicates(wordChosen);
        attempts = CalcAttempts(charsToGuess);
        totalLettersToGuess = CalcAttempts(charsToGuess);
        guessWord = HideGuessWord(wordChosen);

    }




    private int ValidatePurchase()
    {

        return PlayerPrefs.GetInt(Manager.key);
    }


    void GenerateList()
    {
        if(ValidatePurchase() == 0)
        {
            PopulateListMemoryFreeVersion();

        }
        if(ValidatePurchase() == 1)
        {

            PopulateListMemoryFullVersion();

        }



    }

    void PopulateListMemoryFreeVersion()
    {
        wordsTempMem = new string[42];

        for (int i = 0; i< wordsTempMem.Length; i++)
        { if (i < wordsTempMem.Length) { wordsTempMem[i] = freeWords[i]; } }
    }

    void PopulateListMemoryFullVersion()
    {
        wordsTempMem = new string[420];
        List<string> tempMemList = new List<string>();

        for (int i = 0; i <= 15; i++)
        { if (i < wordsTempMem.Length)
            {
                switch(i)
                {
                    case 1:
                        tempMemList.Add(wordsList2[0]);
                            break;
                    case 2:
                        for (int j = 0; j < wordsList3.Length; j++)
                        { tempMemList.Add(wordsList3[j]); }
                        break;
                    case 3:
                        for (int j = 0; j < wordsList4.Length; j++)
                        { tempMemList.Add(wordsList4[j]); }
                        break;
                    case 4:
                        for (int j = 0; j < wordsList5.Length; j++)
                        { tempMemList.Add(wordsList5[j]); }
                        break;
                    case 5:
                        for (int j = 0; j < wordsList6.Length; j++)
                        { tempMemList.Add(wordsList6[j]); }
                        break;
                    case 6:
                        for (int j = 0; j < wordsList7.Length; j++)
                        { tempMemList.Add(wordsList7[j]); }
                        break;
                    case 7:
                        for (int j = 0; j < wordsList8.Length; j++)
                        { tempMemList.Add(wordsList8[j]); }
                        break;
                    case 8:
                        for (int j = 0; j < wordsList9.Length; j++)
                        { tempMemList.Add(wordsList9[j]); }
                        break;
                    case 9:
                        for (int j = 0; j < wordsList10.Length; j++)
                        { tempMemList.Add(wordsList10[j]); }
                        break;
                    case 10:
                        for (int j = 0; j < wordsList11.Length; j++)
                        { tempMemList.Add(wordsList11[j]); }
                        break;
                    case 11:
                        for (int j = 0; j < wordsList12.Length; j++)
                        { tempMemList.Add(wordsList12[j]); }
                        break;
                    case 12:
                        for (int j = 0; j < wordsList13.Length; j++)
                        { tempMemList.Add(wordsList13[j]); }
                        break;
                    case 13:
                        for (int j = 0; j < wordsList14.Length; j++)
                        { tempMemList.Add(wordsList14[j]); }
                        break;
                    case 14:
                        for (int j = 0; j < wordsList15.Length; j++)
                        { tempMemList.Add(wordsList15[j]); }
                        break;
                    case 15:
                        for (int j = 0; j < wordsList17.Length; j++)
                        { tempMemList.Add(wordsList17[j]); }
                        break;
                    default:
                        Console.WriteLine("Default case: something went wrong");
                        break;
                }                
            }
        }


        for (int j = 0; j < wordsTempMem.Length; j++)
        {
            if (j < wordsTempMem.Length)
            {
                wordsTempMem[j] = tempMemList[j];
            }
        }
    }

    
    void ChoseWordFromList(string[] listOfWordsArray)
    {
        // use aenimea
        aenimaForCurrentWords = new Aenima<string>(listOfWordsArray.Length, (listOfWordsArray.Length/2));
        for(int i = 0; i < listOfWordsArray.Length; i++)
        { if(i< listOfWordsArray.Length) aenimaForCurrentWords.addItem(listOfWordsArray[i]); }




        wordChosen = aenimaForCurrentWords.getNext();
        chosenWordTempMem = wordChosen;
       
        wordChosen = wordChosen.ToUpper();

        print(wordChosen);
        //2 min
        //95 max
        //UnityEngine.Random.Range(0, words.Length)
    }

    void RemoveSpacesAndDupesInStringArray(string[] stringArray)
    {
        for (int i = 0; i < stringArray.Length; i++)
        {
           
            if(i<stringArray.Length)
            {
               listOfCharNoSpacesNoDupes = RemoveDuplicates(stringArray[i]);
               wordsTempMem[i] = new string(listOfCharNoSpacesNoDupes.ToArray(), 0, listOfCharNoSpacesNoDupes.Count);
            }
        }
    }

    List<char> RemoveDuplicates(string stringToRemove)
    {
        wordChosen = stringToRemove;

        List<char> seenLetters = new List<char>();
        int uniqueLetters = 0;
        for (int i = 0; i < wordChosen.Length; i++)
        {
            char letterChosen = wordChosen[i];
            if (wordChosen[i] == ' ')
            { isSpaces = true; continue; }
            if (seenLetters.Contains(letterChosen))
                continue;
            else
                seenLetters.Add(letterChosen);
            uniqueLetters++;
            if (i > wordChosen.Length)
            { i = wordChosen.Length; }
        }
        for (int j = 0; j < seenLetters.Count; j++)
        {
            if (j <= wordChosen.Length)
            { print(" seenLetters[" + j + "]: " + seenLetters[j]); }
            else { j = wordChosen.Length; }
        }
        return seenLetters;
    }



    void SortListAlphabetically(string[] placeListToSortHere)
    { Array.Sort(placeListToSortHere); }


    void SortListByCharLength(string[] placeListToSortHere)
    { Array.Sort(placeListToSortHere, (x, y) => x.Length.CompareTo(y.Length)); }

    int CalcAttempts(List<char> charactersToGuess)
    { return charsToGuess.Count; }

    string HideGuessWord(string stringToHide)
    {
        List<char> seenCharacters = new List<char>();
        string stringToPass = "";
        for (int i = 0; i < wordChosen.Length; i++)
        {
            char characterChosen = wordChosen[i];
            if (wordChosen[i] == ' ')
            { seenCharacters.Add(blank); }
            else
            { seenCharacters.Add(underscore); }
            stringToPass += seenCharacters[i];
            if (i > wordChosen.Length)
            { i = wordChosen.Length; }
        }
        return stringToPass;
    }

    void GuessChar(char chosenLetter)
    {
        freeGuessedChar = chosenLetter;
        print(chosenLetter +" : "+ "   "+'~');
        if (chosenLetter != '~')
        {
            if (charsToGuess.Contains(chosenLetter))
            { RevealLetters(chosenLetter); CheckForWin(); }
            else
            {
                if (menuFlag == true) { return; }
                else
                {

                    if (attempts >= 0)
                    {
                        if (attempts < 1) { YouLoseThisRound(); }
                        else { if (menuFlag == false) { print(PhrasePlayer.Instance.canPlayPhrase);
                                                        PhrasePlayer.Instance.PlayPhrase();
                                                        print(PhrasePlayer.Instance.canPlayPhrase);
                                                        DecrementAttempts();
                                                      }
                        }
                    }
                }
            }
        }
    }
    void DecrementAttempts()
    {
        attempts--;
    }


    void Keyboard()
    {

        int cX = 0;
        int cY = 0;
        int keysPerRow = 11;
        int numberOfRows = 4;
        float headerOffset = 9;
        float xKeyboardButtonPosInit = 0f + keyboardOffsetX;
        float yKeyboardButtonPosInit = 0f + keyboardOffsetY;
        float borderX = 0.01f;
        float borderY = 0.08f;
        float startWidthPosition = 0.1f;
        //Rename these once i figure out what to name them 
        float startHeightPosition = 0.6f;
        //Rename these once i figure out what to name them 
        float keyboardWidthRatio = 0.8f;
        float keyboardHeightRatio = 0.3f;
        float xSpacingPercentage = 0.1f;
        float ySpacingPercentage = 0.1f;
        float initKeyboardXPos = 0;
        float initKeyboardYPos = 0;
        float keyboardWidth = (Screen.width * keyboardWidthRatio) * (1 - (2 * borderX));
        // A border on each side 
        float keyboardHeight = (Screen.height * keyboardHeightRatio) * (1 - (2 * borderY));
        // A border on each side 
        float xButSize = (keyboardWidth * (1 - xSpacingPercentage) / keysPerRow);
        float yButSize = (keyboardHeight * (1 - ySpacingPercentage) / numberOfRows);
        float xButSpacing = (keyboardWidth * xSpacingPercentage / keysPerRow);
        float yButSpacing = (keyboardHeight * ySpacingPercentage / numberOfRows);

        Vector2 buttonSize = new Vector2(xButSize, yButSize); Vector2 buttonSpacing = new
        Vector2(xButSpacing, yButSpacing);

        int keyboardBackgroungWidth = (int)(Screen.width * keyboardWidthRatio);
        int keyboardBackgroungHeight = (int)(Screen.height * keyboardHeightRatio);

        initKeyboardXPos = Screen.width * startWidthPosition;
        initKeyboardYPos = Screen.height * startHeightPosition;

        GUI.Box(new Rect(initKeyboardXPos, initKeyboardYPos, keyboardBackgroungWidth, keyboardBackgroungHeight), " ", sweetLeaf);

        xKeyboardButtonPosInit = initKeyboardXPos + (keyboardBackgroungWidth * borderX);
        yKeyboardButtonPosInit = initKeyboardYPos + (keyboardBackgroungHeight * borderY) + headerOffset;

        for (int i = 0; i < buttonNames.Length; i++)
        {
            if (cX >= keysPerRow)
            {
                cX = 0;
                cY++;
            }

            GUI.SetNextControlName(buttonNames[i]);
            buttons[i] = GUI.Button(new Rect(xKeyboardButtonPosInit + ((buttonSize.x + buttonSpacing.x) * cX), yKeyboardButtonPosInit + ((buttonSize.y + buttonSpacing.y) * cY), buttonSize.x, buttonSize.y), buttonNames[i], sweetLeaf);

            if (buttons[i])
            {

                char letterChosen = CheckChar(buttonNames[i], i);
                GuessChar(letterChosen);


            }


            cX++;
        }

    }
    private char CheckChar(string stringToPassIn, int iter)
    {
       


            string invalidChar = "~";

            char charToReturn = ' ';

            int functionCalls = iter;

            tempCharMem = defaultButtonNames[iter];
            //charToCompare = stringToPassIn;
            //  check if char is valid 
            print("stringToPassIn: " + stringToPassIn + ".");
            print("Checking stringToPassIn for vailid character.");
        if (stringToPassIn != "~")
        {

            if (stringToPassIn != invalidChar)
            {

                print("Char is vailid and value of Default Button Name at point ["
                      + iter + "]: "
                      + defaultButtonNames[iter]
                      + " was stored: "
                      + tempCharMem
                      + " in tempCharMem.");
                //print("iter: " + iter + ".");
                //check if string is "quit" or "hint" or "f1" or "f2" 
                // decrementAttempts();
                if ((functionCalls == 10) || (functionCalls == 21) || (functionCalls == 32) || (functionCalls == 43))
                {
                    menuFlag = true;
                    print("Menu button has been pressed.");
                    // if so perform corresponding function call
                    switch (functionCalls)
                    {
                        case 10: { QuitGame(); break; }
                        case 21: { LighterFlick(); break; }
                        case 32: { Cough(); break; }
                        case 43: { if (canPlayFlag) { TakeAHit(); } break; }
                        default:
                            break;
                    }

                }

                if ((functionCalls != 10) && (functionCalls != 21) && (functionCalls != 32) && (functionCalls != 43))
                {

                    menuFlag = false;
                    print("menuFlag = false");

                    if (canPlayFlag)
                    {
                        charToReturn = StringToFirstChar(stringToPassIn);
                        print("Char is vailid, menu buttons are not pressed, and: "
                              + charToReturn
                              + " is being returned from the converted value of stringToPassIn: "
                              + stringToPassIn +
                              ". Attempts will now be decremented.");

                        //  change buttonname[i] to invalid special char 
                        buttonNames[iter] = invalidChar;
                    }

                }

            }
            else
            {

                print("Char not vailid and: " + tempCharMem + " tempCharMem is being returned. Player will now be made fun of.");
                charToReturn = StringToFirstChar(tempCharMem);
                //if (attempts >= 1)
                //{ decrementAttempts();message = messedUpMessage(charToReturn);  }
                //print("charToReturn: " + charToReturn + " has been pressed and is now invailid.");

            }
          

        }
        else { charToReturn = StringToFirstChar(stringToPassIn); }
        //print("Default return clause charToReturn: " + charToReturn + ".");
       
        return charToReturn;
    }
    char StringToFirstChar(string stringToConvert)
    {
       // List<char> seenLetters = new List<char>();
        for (int i = 0; i < stringToConvert.Length; i++)
        { char letterChosen = stringToConvert[i]; }
        return stringToConvert[0];
    }
    void RevealLetters(char choseLetter)
    {
        StringBuilder strBuilder = new StringBuilder(guessWord);
        for (int i = 0; i < wordChosen.Length; i++)
        {
            if (wordChosen[i] == choseLetter)
            { strBuilder[i] = wordChosen[i]; }
        }
        guessWord = strBuilder.ToString();
        //print(guessWord);
    }
    void CheckForWin()
    {
        if (attempts > 0)
        { totalLettersGuessed++; }

        if ((totalLettersGuessed == totalLettersToGuess) && (attempts > 0))
        { YouWinThisRound(); }


    }
    void YouWinThisRound()
    {
        //message = "You Fornicating won!";
        Manager.canDisplayWord = true;
       
        UnityEngine.SceneManagement.SceneManager.LoadScene("Winner");
        
    }
    void YouLoseThisRound()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        

    }
    void QuitGame()
    {
        YouLoseThisRound();

    }


    void Cough()
    {
        Debug.Log("you coughed");
        //play sound chough  //currentBackgroundMusic.clip = audioSources[memoryLocationOfAudioSources];
        PlayNoise(coughs);
        Background_Music.Instance.PlayNextSong();
       // menuFlag = false;
    }
    void TakeAHit()
    {
        Debug.Log("you you took a hit");
        string strTMem;

        int howToHit = UnityEngine.Random.Range(0,1);

        if(howToHit == 0)
        {
            //LighterFlick();
            PlayNoise(jointHit);
            if (attempts > 3)
            {
                // aenimaForCurrentWords = new Aenima<string>(listOfWordsArray.Length, (listOfWordsArray.Length/2));
                freeCharReveal = new Aenima<char>(charsToGuess.Count);
                for (int i = 0; i < charsToGuess.Count; i++)
                { if (i < charsToGuess.Count) freeCharReveal.addItem(charsToGuess[i]);/*   here   */    }

                char freebie = freeCharReveal.getNext();
                

                
                GuessChar(freebie);

                strTMem = "" + freebie + "";
                
                CheckChar(strTMem, GetDefaultButtonValue(freeGuessedChar));

                DecrementAttempts();
                DecrementAttempts();
                
            }

        }
        else
        {
            LighterFlick();
            Debug.Log("you you took a bong hit");
            PlayNoise(bongHit);
           // PlayNoise(jointHit);
           // Cough();
           if(attempts>3)
            {
                // aenimaForCurrentWords = new Aenima<string>(listOfWordsArray.Length, (listOfWordsArray.Length/2));
                freeCharReveal = new Aenima<char>(charsToGuess.Count, charsToGuess.Count);
                for (int i = 0; i < charsToGuess.Count; i++)
                { if (i < charsToGuess.Count) freeCharReveal.addItem(charsToGuess[i]); }
                GuessChar(freeCharReveal.getNext());
                DecrementAttempts();
                DecrementAttempts();
                
            }


           
        }
        
    }
    void LighterFlick()
    {
        //play sound
        Debug.Log("you lit the joint");
        PlayNoise(lighterFlicks);
       // menuFlag = false;
    }

    void ResetButtons()
    {
        for (int j = 0; j < buttonNames.Length; j++)
        {
            buttonNames[j] = defaultButtonNames[j];
        }

    }
    void PlayNoise(AudioClip[] noisesToPlay)
    {
        int iter = UnityEngine.Random.Range(0, noisesToPlay.Length);
        noiseMaker.clip = noisesToPlay[iter];
        Debug.Log("Playing noise at " + iter + " location. Setting isNoisePlaying to true.");
        noiseMaker.Play();
       
     
    }

    int GetDefaultButtonValue(char m_freeGuessedChar)
    {
        int returnVal = 0;
        string strMem = "" + freeGuessedChar + "";

        for(int i = 0; i < buttonNames.Length;i++)
        {
            if(strMem == buttonNames[i])
            {
                returnVal = defaultButtonValues[i];
            }

        }




        return returnVal;
    }

}
