using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lab7CanvasHelper : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject remainingLivesText;
    // Start is called before the first frame update
    void Start()
    {
        ShowUIElements(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Player == null)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            ShowUIElements(true);
            remainingLivesText.GetComponent<Text>().text = "Lives Remaining: " + GameManager.Instance.PlayerLives;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            ShowUIElements(false);
        }
    }

    void ShowUIElements(bool yesOrNo)
    {
        continueButton.SetActive(yesOrNo);
        remainingLivesText.SetActive(yesOrNo);
    }
}
