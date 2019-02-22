using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GameController : DefaultTrackableEventHandler
{

    public static GameController instance;
    public int playerScore = 0;
    public Text scoreCountText;
    public Text livesCountText;
    public int round = 1;
    public Text roundeTextTargetText;
    public Text roundeTextNumber;
    public int shotsPreRound = 3;
    private int lives = 2;
    //public GameObject[] shells;
    public GameObject GUIScoreText;
    public GameObject GUILivesText;
    public GameObject GUICenterTarget;
    public GameObject GUIFireButton;
    public GameObject GUIDog;
    public GameObject GUIRoundText;
    public GameObject GUIGameOverPanel;
    public GameObject startPanel;
    public GameObject GUIGun;

    AudioSource audio;
    public AudioClip[] clips;

    //Round
    private int roundTargetScore = 3;
    public int roundScore = 0;
    private int socreIncrement = 2;
    public bool playerStarted = false;




    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = int.Parse(scoreCountText.text);
        showStartPanel();
        audio = GetComponent<AudioSource>();
        livesCountText.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(DefaultTrackableEventHandler.trueFalse == true)
        {
            hideStartPanel();
            showItems();
            if(playerStarted == false)
            {
                StartCoroutine(playRound());
            }
            playerStarted = true;
        }
        else
        {
            showStartPanel();
            hideItems();

        }
    }

    public void showItems()
    {
        GUIScoreText.SetActive(true);
        GUILivesText.SetActive(true);
        GUICenterTarget.SetActive(true);
        GUIFireButton.SetActive(true);
        GUIDog.SetActive(true);
        //GUIRoundText.SetActive(true);
        GUIGun.SetActive(true);
    }

    public void hideItems()
    {
        GUIScoreText.SetActive(false);
        GUILivesText.SetActive(false);
        GUICenterTarget.SetActive(false);
        GUIFireButton.SetActive(false);
        GUIDog.SetActive(false);
        //GUIRoundText.SetActive(false);
        GUIGun.SetActive(false);
    }

    public IEnumerator playRound()
    {
        yield return new WaitForSeconds(2f);
        roundeTextTargetText.text = "SHOOT " + roundTargetScore + " DUCKS";
        GUIRoundText.SetActive(true);
        playFX(0);
        StartCoroutine(hideRoundText());
    }

    private void playFX (int sound)
    {
        audio.clip = clips[sound];
        audio.Play();
    }

    private IEnumerator hideRoundText()
    {
        yield return new WaitForSeconds(4);
        GUIRoundText.SetActive(false);
    }

    private void showStartPanel()
    {
        startPanel.SetActive(true);
    }

    private void hideStartPanel()
    {
        startPanel.SetActive(false);
    }
}
