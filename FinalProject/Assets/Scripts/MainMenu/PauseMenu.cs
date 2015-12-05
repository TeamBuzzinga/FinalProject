using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;
    public GameObject gameCamera;
    public GameObject[] enemies;
    public Button currentButton;
    public ObjectivesScript objectiveScript;

    //public Button[] pauseMenuButtons;
    //float transitionDelayTime = .7f;
    //float transitionDelayTimer = 0;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameCamera = GameObject.FindGameObjectWithTag("MainCamera");
        enemies = GameObject.FindGameObjectsWithTag("npc");
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause") && !objectiveScript.getObjectiveUp())
        {
            setPauseScreenActive();
        }
    }

    void setPauseScreenActive()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if (pauseMenu.activeSelf)
        {
            currentButton.Select();
        }
        player.GetComponent<Animator>().enabled = !pauseMenu.activeSelf;
        player.GetComponent<WalkMechanics>().setUpdateEnabled(!pauseMenu.activeSelf);
        player.GetComponent<PlayerAnimation>().enabled = !pauseMenu.activeSelf;
        player.GetComponent<ThrowMechanics>().enabled = !pauseMenu.activeSelf;
        player.GetComponent<Rigidbody>().isKinematic = pauseMenu.activeSelf;
        gameCamera.GetComponent<CameraMechanics>().setUpdateEnabled(!pauseMenu.activeSelf);
        foreach (GameObject e in enemies)
        {

        }

    }

    public void onResumeClick()
    {
        if (objectiveScript.getObjectiveUp())
        {
            return;
        }
        setPauseScreenActive();
    }

    public void onRestartClick()
    {
        if (objectiveScript.getObjectiveUp())
        {
            return;
        }
        Application.LoadLevel(Application.loadedLevel);
    }

    public void onQuitClick()
    {
        if (objectiveScript.getObjectiveUp())
        {
            return;
        }
        Application.LoadLevel("RyanMainMenu");
    }

    public void OnObjectivesClicked()
    {
        if (objectiveScript.getObjectiveUp())
        {
            return;
        }
        objectiveScript.setUpObjectives();
    }
}
