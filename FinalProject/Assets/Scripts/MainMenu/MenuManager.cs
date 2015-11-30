using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {
    public Animator cameraAnimator;
    public Animator creditsAnimator;

    public float timeDelay = .75f;//The amount of time before switching to another option

    public Button[] introButtons = new Button[4];
    public Button[] creditsButtons = new Button[1];
    public Slider[] optionsSliders = new Slider[2];
    public Button optionsBackButton;

    float lastHInput;
    float lastVInput;
    float verticalTimer;
    float horizontalTimer;
   // bool selectOption;
    Vector2 currentPosition;
    Animator menuAnim;

    

    enum State { Intro, Options, Credits };
    State currentState;

    void Start()
    {
        currentPosition = Vector2.zero;
        currentState = State.Intro;
        menuAnim = GetComponent<Animator>();
    }



    void shiftCursor()
    {
       
       switch (currentState)
        {
            case State.Intro:
                handleIntroSelection();
                break;
            case State.Credits:
                handleCreditsMenu();
                break;
            case State.Options:
                handleOptionsMenu();
                break;

        }
    }

    void handleOptionsMenu()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            optionsBackButton.onClick.Invoke();
            return;
        }
        if (lastVInput < -0.01f && verticalTimer <= 0)
        {
            verticalTimer = timeDelay;
            currentPosition += Vector2.up;
            adjustCurrentPosition(optionsSliders);
            optionsSliders[(int)currentPosition.y].Select();
        }
        else if (lastVInput > 0.01f && verticalTimer <= 0)
        {
            verticalTimer = timeDelay;
            currentPosition -= Vector2.up;
            adjustCurrentPosition(optionsSliders);
            optionsSliders[(int)currentPosition.y].Select();
        }
        else if (lastVInput < .01f && lastVInput > -.01f)
        {
            adjustCurrentPosition(optionsSliders);
            verticalTimer = 0;
        }
        optionsSliders[(int)currentPosition.y].value += Mathf.Ceil(Input.GetAxisRaw("Horizontal"));
    }
    
    void handleCreditsMenu()
    {
        //print(selectOption);
        if (Input.GetButtonDown("Cancel"))
        {
            creditsButtons[0].onClick.Invoke();
        }
        
        if (Mathf.Abs(lastHInput) > .01f || Mathf.Abs(lastVInput) > .01f)
        {
            creditsButtons[0].Select();
        }
    }

    void handleIntroSelection()
    {
        //print(selectOption);
        if (lastVInput < -0.01f && verticalTimer <= 0)
        {
            verticalTimer = timeDelay;
            currentPosition += Vector2.up;
            adjustCurrentPosition(introButtons);
            introButtons[(int)currentPosition.y].Select();
        }
        else if (lastVInput > 0.01f && verticalTimer <= 0)
        {
            verticalTimer = timeDelay;
            currentPosition -= Vector2.up;
            adjustCurrentPosition(introButtons);
            introButtons[(int)currentPosition.y].Select();
        }
        else if (lastVInput < .01f && lastVInput > -.01f)
        {
            verticalTimer = 0;
        }
        
    }

    void adjustCurrentPosition(Selectable[] buttons)
    {
        int x = (int)currentPosition.x;
        int y = (int)currentPosition.y;
        if (x < 0)
        {
            //x += buttons.GetLength(0);
        }
        if (y < 0)
        {
            y += buttons.GetLength(0);
        }
        //x = x % buttons.GetLength(0);
        y = y % buttons.GetLength(0);
        currentPosition = new Vector2(x, y);
    }

    void Update()
    {
        shiftCursor();
        if (Input.anyKeyDown)
        {
            menuAnim.SetTrigger("SkipIntro");            
            cameraAnimator.SetTrigger("SkipIntro");
        }

        lastHInput = Input.GetAxisRaw("Horizontal");
        lastVInput = Input.GetAxisRaw("Vertical");
        //selectOption = Input.GetButtonDown("Jump");

        verticalTimer = Mathf.MoveTowards(verticalTimer, 0, Time.deltaTime);
        horizontalTimer = Mathf.MoveTowards(horizontalTimer, 0, Time.deltaTime);

        
    }



    public void optionsPressed()
    {
        cameraAnimator.SetTrigger("Options");
        menuAnim.SetTrigger("Options");
        currentState = State.Options;
    }

    public void playButtonPressed()
    {
        Application.LoadLevel("Office v1.3");
    }

    public void creditsButtonPresed()
    {
        cameraAnimator.SetTrigger("Credits");
        menuAnim.SetTrigger("Credits");
        creditsAnimator.SetTrigger("Credits");
        currentState = State.Credits;
    }

    public void quitButtonPressed()
    {
        Application.Quit();
    }

    public void toIntroScreen()
    {
        cameraAnimator.SetTrigger("Intro");
        menuAnim.SetTrigger("Intro");
        if (!creditsAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleText"))
        {
            creditsAnimator.SetTrigger("Intro");
        }
        
        currentState = State.Intro;
    }
}
