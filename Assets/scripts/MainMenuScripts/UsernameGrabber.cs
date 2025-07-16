using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UsernameGrabber : MonoBehaviour
{
    private class SaveUsernameObject{
        public List<string> users;
        public string currentSelectedUser;
    }
    SaveUsernameObject saveObject;

    string currentUser;
    public TextMeshProUGUI userName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GrabUsername();
        if(currentUser != null){
            userName.text = "Hi, " + currentUser;
        }
        else{
            userName.text = "No user selected";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame){
            SceneManager.LoadScene("LoginScene");
            // Application.Quit();
        }
    }

    public void GrabUsername(){
        if(File.Exists(Application.dataPath + "/Save_File.json")){
            string jsonData = File.ReadAllText(Application.dataPath + "/Save_File.json");
            saveObject = JsonUtility.FromJson<SaveUsernameObject>(jsonData);
            Debug.Log("Grabbed usernames: " + string.Join(", ", saveObject.users));
            currentUser = saveObject.currentSelectedUser;
        }
        else{
            Debug.Log("No save file found.");
        }
    }

    public void LoadGameScene(){
        SceneManager.LoadScene("Game 1");
    }
}
