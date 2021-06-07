using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class AuthManager : MonoBehaviour
{
    FirebaseAuth auth;
    FirebaseUser user;
    AuthUI authUI;

    private void Start()
    {
        authUI = GetComponent<AuthUI>();
        //Inicijalizacija Firebase-a
        InitializeFirebase();
    }

    void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if(auth.CurrentUser != user)
        {
            /* Skraćeni zapis
            bool signedIn;
            if (user != auth.CurrentUser && auth.CurrentUser != null)
            {
                signedIn = true;
            }
            else
            {
                signedIn = false;
            }
            */


            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;

            if(!signedIn && user != null)
            {
                Debug.Log("User " + user.UserId + " is now signed out");
            }

            user = auth.CurrentUser;
            if(signedIn)
            {
                Debug.Log("User " + user.UserId + " is now signed in");
                //Prikazi u AuthUI-u panel igre
            }
        }
    }

    //Metoda na buttonu za Login
    public void OnLoginButtonClick()
    {
        TryLoginWithFirebaseAuth(authUI.loginEmail.text, authUI.loginPassword.text);
    }

    //Metoda na butonu za register
    public void OnCreateAccountButtonClick()
    {
        TryRegisterWithFirebaseAuth(authUI.registerEmail.text, authUI.registerPassword.text, authUI.registerConfirmPassword.text);
    }

    //Metoda na buttonu za odjavu / sing out
    public void OnLogoutButtonClick()
    {
        auth.SignOut();
        authUI.ShowLoginPanel();
    }

    void TryLoginWithFirebaseAuth(string emailFromUser, string passwordFromUser)
    {
        auth.SignInWithEmailAndPasswordAsync(emailFromUser, passwordFromUser).ContinueWith(task =>
        {
            //Prijava se prekinula
            if (task.IsCanceled)
            {
                Debug.Log("Login with email and password was canceled");
                return;
            }

            //Prijava nije uspijela iz nekog razloga npr. kriva šifra, internet puko itd.
            if (task.IsFaulted)
            {
                Debug.Log("Login with e-mail and password encounterd an error: " + task.Exception);
                return;
            }

            //Prijava je uspiješna
            if (task.IsCompleted)
            {
                FirebaseUser newUser = task.Result;
                Debug.Log("User logged in ssuccessfully: " + newUser.DisplayName + " " + newUser.UserId);
                //authUI.ShowLoggedInPanel();
            }
        });
    }

    void TryRegisterWithFirebaseAuth(string userEmail, string userPassword, string userPasswordConf)
    {
        auth.CreateUserWithEmailAndPasswordAsync(userEmail, userPassword).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("Creating account was canceled");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log("Creating account encounterd an error: " + task.Exception);
                return;
            }
            else
            {
                if (userPassword == userPasswordConf && task.IsCompleted)
                {
                    FirebaseUser newUser = task.Result;
                    Debug.Log("Firebase user created ssuccessfully");
                    if (newUser != null)
                    {
                        authUI.ShowLoggedInPanel();
                    }
                }
                else if (userPassword != userPasswordConf && task.IsCompleted)
                {
                    Debug.Log("Passwords do not match");
                    return;
                }
            }
        });
    }
}
