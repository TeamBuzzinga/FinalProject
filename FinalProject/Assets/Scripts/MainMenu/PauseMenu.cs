using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;
    public GameObject gameCamera;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            setPauseScreenActive();
        }
    }

    void setPauseScreenActive()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        player.GetComponent<Animator>().enabled = !pauseMenu.activeSelf;
        player.GetComponent<WalkMechanics>().setUpdateEnabled(!pauseMenu.activeSelf);
        player.GetComponent<PlayerAnimation>().enabled = !pauseMenu.activeSelf;
       
        player.GetComponent<Rigidbody>().isKinematic = pauseMenu.activeSelf;
        gameCamera.GetComponent<CameraMechanics>().setUpdateEnabled(!pauseMenu.activeSelf);

    }

    public void onResumeClick()
    {
        setPauseScreenActive();
    }

    public void onRestartClick()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void onQuitClick()
    {
        Application.LoadLevel("MainMenu");
    }
}
