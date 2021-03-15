using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [Header("Login Panel")]
    public Text usernameText;
    public Text errorPopup;
    public InputField passwordLogin;

    [Header("Register Panel")]
    public InputField email;
    public InputField password;
    public InputField repeatPassword;
    public InputField username;
    public Text errorRegPopup;

    public void LoginMethod()
    {
        if(usernameText.text == null)
        {
            errorPopup.text = "You need to write your username or email dickhead!";
        }
        else if(usernameText.text == " ")
        {
            errorPopup.text = "You think you can fool me fool?";
        }
        else if(usernameText.text.Length < 3)
        {
            errorPopup.text = "You need to have atleast 3 characters in you username shitlord";
        }
        else if(passwordLogin.text != PlayerPrefs.GetString("password"))
        {
            errorPopup.text = "Wrong username or passworde";
        }
        else if(usernameText.text != PlayerPrefs.GetString("username"))
        {
            errorPopup.text = "Wrong username or passworde";
        }
        else if((usernameText.text == PlayerPrefs.GetString("username") || usernameText.text == PlayerPrefs.GetString("email")) && passwordLogin.text == PlayerPrefs.GetString("password"))
        {
            errorPopup.text = "Logged In";
            errorPopup.color = Color.green;
            SceneManager.LoadScene(1);
        }
        else
        {
            errorPopup.text = "You fucked up something I did not remamber to notify you!";
        }
    }

    public void RegisterMethod()
    {
        if(email.text == null)
        {
            errorRegPopup.text = "You need to write email";
        }
        else if(password.text == null)
        {
            errorRegPopup.text = "You need to write password";
        }
        else if (repeatPassword.text == null)
        {
            errorRegPopup.text = "You need to rewrite password";
        }
        else if (username.text == null)
        {
            errorRegPopup.text = "You need to write your username";
        }
        else if (password.text.Length < 8)
        {
            errorRegPopup.text = "You need at least 8 characters";
        }
        else if(password.text != repeatPassword.text)
        {
            errorRegPopup.text = "Passwords do not match!";
            password.text = null;
            repeatPassword.text = "";
        }
        else if(PlayerPrefs.GetString("username") == username.text)
        {
            errorRegPopup.text = "This username is already in use";
        }
        else
        {
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetString("password", password.text);
            PlayerPrefs.SetString("email", email.text);
            errorRegPopup.text = "Successfully created account go to login";
            errorRegPopup.color = Color.green;
        }
    }
}
