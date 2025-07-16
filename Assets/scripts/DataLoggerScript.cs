using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLoggerScript : MonoBehaviour
{
    public static DataLoggerScript I;
    int fileCounter = 0;
    int bulletsPerSecond = 0;
    int enemyKillsPerSecond = 0;
    float timeCounter = 0;
    float minuteCounter = 0;
    public bool isOffensive = false;

    public GameObject Mob;

    SaveObject saveObject;

    private class SaveUsernameObject{
        public List<string> users;
        public string currentSelectedUser;
    }
    SaveUsernameObject saveUsernameObject;
    string currentUser;

    // List<string> saveObjectList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if ( I != null && I != this ){
            Destroy(this);
        }
        else{
            I = this;
        }

        saveObject = new SaveObject();
        saveObject.bulletsPerSecond = new List<int>();
        saveObject.enemyKillsPerSecond = new List<int>();
        // saveObject.enemiesKilled = 0;
        GrabCurrentUser();
    }

    void Update()
    {
        timeCounter += Time.deltaTime;
        minuteCounter += Time.deltaTime;
        if(timeCounter >= 1){
            timeCounter = 0;
            Save();
            ResetSecondsValues();
        }
        // Change it to minute afrerwards!
        // if(minuteCounter >= 20){
        //     minuteCounter = 0;
        //     FinalSave();
        //     Debug.Log("Data Saved");
        // }
    }

    public void IncrementMobData(){
        if(isOffensive){
            Mob.GetComponent<NewMonoBehaviourScript>().AdjustSpawnIntervalIncrementer("Offensive");
        }
        else{
            Mob.GetComponent<NewMonoBehaviourScript>().AdjustSpawnIntervalIncrementer("Defensive");
        }
    }
    // Find the Save_File.json and take the current user
    public void GrabCurrentUser(){
        if(File.Exists(Application.dataPath + "/Save_File.json")){
            string jsonData = File.ReadAllText(Application.dataPath + "/Save_File.json");
            saveUsernameObject = JsonUtility.FromJson<SaveUsernameObject>(jsonData);
            Debug.Log("Grabbed usernames: " + string.Join(", ", saveUsernameObject.users));
            currentUser = saveUsernameObject.currentSelectedUser;
        }
    }

    private void Save(){
        saveObject.bulletsPerSecond.Add(bulletsPerSecond);
        saveObject.enemyKillsPerSecond.Add(enemyKillsPerSecond);
    }

    public void FinalSave(){
        string jsonData =  JsonUtility.ToJson(saveObject, true);
        while(File.Exists(Application.dataPath + $"/DataLoggerJSON_" + currentUser + "_" + fileCounter +".json")){
            fileCounter++;
        }
        File.WriteAllText(Application.dataPath + $"/DataLoggerJSON_" + currentUser + "_" + fileCounter +".json", jsonData);
        IncrementMobData();
    }

    public void OnBulletFired(){
        bulletsPerSecond++;
        Debug.Log("Bullet Fired");
    }
    public void ResetSecondsValues(){
        bulletsPerSecond = 0;
        enemyKillsPerSecond = 0;
    }

    public void EnemyDead(){
        // saveObject.enemiesKilled++;
        enemyKillsPerSecond++;
        Debug.Log("Enemy Killed");
    }

    private class SaveObject
    {
        public List<int> bulletsPerSecond;
        public List<int> enemyKillsPerSecond;
    }
}
