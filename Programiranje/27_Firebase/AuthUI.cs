using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthUI : MonoBehaviour
{
    [Header("Login data")]
    public InputField loginEmail;
    public InputField loginPassword;

    [Header("Register data")]
    public InputField registerEmail;
    public InputField registerPassword;
    public InputField registerConfirmPassword;
    public InputField registerName;
    public InputField registerLastName;

    [Header("Panels")]
    public GameObject loginPanel;
    public GameObject registerPanel;
    public GameObject loggedInPanel;

    private void Start()
    {
        ShowPanel(loginPanel);
    }

    private void ShowPanel(GameObject panel)
    {
        loginPanel.SetActive(false);
        loggedInPanel.SetActive(false);
        registerPanel.SetActive(false);

        panel.SetActive(true);

        Debug.Log("Active panel is: " + panel.name);
    }

    public void ShowLoginPanel()
    {
        ShowPanel(loginPanel);
    }

    public void ShowRegisterPane()
    {
        ShowPanel(registerPanel);
    }

    public void ShowLoggedInPanel()
    {
        ShowPanel(loggedInPanel);
    }
}
