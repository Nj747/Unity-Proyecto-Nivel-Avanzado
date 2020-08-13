using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public GameObject btnStart;

    public GameObject btnCancel;

    public AudioSource sndButton;

    public void LoadLevelOne()
    {
        sndButton.Play();
        SceneManager.LoadScene("Nivel");
    }

    public void ExitGame()
    {
        sndButton.Play();
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            sndButton.Play();
            SceneManager.LoadScene("Nivel");
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            sndButton.Play();
            Application.Quit();
        }
    }
}
