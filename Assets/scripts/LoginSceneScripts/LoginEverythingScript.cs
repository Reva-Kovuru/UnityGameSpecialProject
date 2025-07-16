using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class LoginEverythingScript : MonoBehaviour
{
    public class SaveUsernameObject{
        public List<string> users;
        public string currentSelectedUser;
    }
    public static LoginEverythingScript I;

    public SaveUsernameObject saveObject;
    void Awake()
    {
        if ( I != null && I != this ){
            Destroy(this);
        }
        else{
            I = this;
        }

        saveObject = new SaveUsernameObject();
        saveObject.users = new List<string>();
        saveObject.currentSelectedUser = null;
        LoadUsernameFromSaveFile();
        saveObject.currentSelectedUser = null;

    }
    void Start()
    {
        
    }

    void Update()
    {
        string currUser = saveObject.currentSelectedUser;
        LoadSceneWithUser(currUser);
    }

    public void SaveChangesMethod(){
        string jsonData = JsonUtility.ToJson(saveObject, true);
        File.WriteAllText(Application.dataPath + $"/Save_File.json", jsonData);
    }
    public void SaveUsernameInSaveFile(string username)
    {
        if(saveObject.users.Count >= 3){
            LoginCanvasScript.I.ErrorCanvasPrint();
        }
        else{
            saveObject.users.Add(username);
            saveObject.currentSelectedUser = username;
            string jsonData = JsonUtility.ToJson(saveObject, true);
            File.WriteAllText(Application.dataPath + $"/Save_File.json", jsonData);
            Debug.Log("Username saved: " + username);
        }
    }

    public void LoadUsernameFromSaveFile()
    {
        if(File.Exists(Application.dataPath + "/Save_File.json")){
            string jsonData = File.ReadAllText(Application.dataPath + "/Save_File.json");
            saveObject = JsonUtility.FromJson<SaveUsernameObject>(jsonData);
            Debug.Log("Loaded usernames: " + string.Join(", ", saveObject.users));
        }
        else{
            Debug.Log("No save file found.");
        }
    }

    public void LoadSceneWithUser(string currUser){
        // SaveUsernameInSaveFile();
        SaveChangesMethod();
        if(currUser != null && saveObject.users.Contains(currUser)){
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    public void SelectCurrentUser(int index){
        if(index == 0){
            saveObject.currentSelectedUser = saveObject.users[0];
        }
        else if(index == 1){
            saveObject.currentSelectedUser = saveObject.users[1];
        }
        else if(index == 2){
            saveObject.currentSelectedUser = saveObject.users[2];
        }
    }
}
