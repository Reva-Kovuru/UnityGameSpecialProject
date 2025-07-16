using UnityEngine;
using UnityEngine.SceneManagement;


public class WelcomeSceneScripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
            Debug.Log("Quitting game...");
        }
    }

    public void LoadLoginScene(){
        SceneManager.LoadScene("LoginScene");
    }
}
