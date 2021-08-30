using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPage : MonoBehaviour
{
    public Button leftButton, rightButton;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (leftButton != null || rightButton != null)
        {
            leftButton.interactable = false;
            rightButton.interactable = true;
        }
    }

    public void PressedLeft()
    {
        animator.SetBool("LevelSelect1_Left", true);
        animator.SetBool("LevelSelect2_Left", true);
        animator.SetBool("LevelSelect1_Right", false);
        animator.SetBool("LevelSelect2_Right", false);
        leftButton.interactable = true;
        rightButton.interactable = false;
    }

    public void PressedRight()
    {
        animator.SetBool("LevelSelect1_Right", true);
        animator.SetBool("LevelSelect2_Right", true);
        animator.SetBool("LevelSelect1_Left", false);
        animator.SetBool("LevelSelect2_Left", false);
        leftButton.interactable = false;
        rightButton.interactable = true;
    }
}
