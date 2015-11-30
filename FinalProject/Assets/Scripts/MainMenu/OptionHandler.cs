using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionHandler : MonoBehaviour {
    public bool isCurrentlyActive;
    public Slider mouseSensitivityX;
    public Slider mouseSensitivityY;

    public Slider difficulty;

    int currentSliderSelected;

    public Selectable[] sliders;

    public Button backButton;

    void Start()
    {
        isCurrentlyActive = false;
    }

    void Update()
    {
        if (isCurrentlyActive)
        {
            handleBackButton();
        }
    }

    public void handleSliderOptions()
    {
        switch(currentSliderSelected)
        {
            case 0:
                break;
        }
    }

    void handleBackButton()
    {
        if (Input.GetAxisRaw("Horizontal") < -0.01f)
        {
            backButton.interactable = true;
            backButton.Select();
        }

        if (Input.GetAxisRaw("Horizontal") > .01f)
        {
            backButton.interactable = false;
        }

    }
}
