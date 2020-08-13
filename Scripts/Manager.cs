using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // para usar el objeto Text
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    [Header("GUIs")]
    public Text uiTimeLeft;
    public Text uiGemsCount;
    public GameObject uiFinish;
    public GameObject uiTryAgain;
    public GameObject uiObjective;

    [Header("Player")]
    public PlayerController player;

    [SerializeField]
    int timeLeft;
    public int gemsCount = 0;
    public int goalGems;

    [Header("Audio Sources")]
    public AudioSource sndGemsCollected;
    public AudioSource levelMusic;
    public AudioSource sndNoTimeLeft;

    bool once = false;

    private void Awake()
    {
        Invoke("DisableObjective", 1f);
        uiFinish.SetActive(false);
        uiTryAgain.SetActive(false);
        timeLeft = 120;
        UpdateUI(timeLeft, uiTimeLeft);
        InvokeRepeating("TimeUpdate", 1f, 1f);
    }

    void DisableObjective()
    {
        uiObjective.SetActive(false);
    }

    void TimeUpdate()
    {
        timeLeft -= 1; // resto de a 1 segundo
        UpdateUI(timeLeft, uiTimeLeft);
    }

    private void Update()
    {
        if ((gemsCount >= goalGems) && (timeLeft > 0))
        {
            //Ganador
            FinishMsg("You Won!");
        }

        if ((timeLeft <= 0) || (player.isDead))
        {
            //Perdio
            if (!player.isDead && !once)
            {
                sndNoTimeLeft.Play();
                once = true;
                player.PlayDeadAnimation();
            }
            sndGemsCollected.Stop();
            levelMusic.Stop();
            FinishMsg("You Lose");
            CancelInvoke("TimeUpdate");
        }
    }

    void UpdateUI(int element, Text uiText)
    {
        uiText.text = element.ToString();
    }

    public void UpdateGemsCount()
    {
        gemsCount += 1;
        UpdateUI(gemsCount,uiGemsCount);
        sndGemsCollected.Play();
    }

    void FinishMsg(string msg)
    {
        Text uiText = uiFinish.GetComponentInChildren<Text>();
        uiText.text = msg;
        uiFinish.SetActive(true);
        uiTryAgain.SetActive(true);

        LoadLevel();
    }

    public void LoadLevel()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Nivel");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu Principal");
        }
    }
}
