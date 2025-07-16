using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public float InGameTime;
    public static EventManager I;
    void Start()
    {
        isnotPaused = true; 
    }

    void Awake()
    {
        if ( I != null && I != this ){
            Destroy(this);
        }
        else{
            I = this;
        }
        
    }
    public bool isnotPaused;// Flag to check if the game is paused

    void Update()
    {
        if(isnotPaused)
        {
            InGameTime += Time.deltaTime;
            UI_ALL.I.UpdateTimer(InGameTime);
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
            if(Input.GetKeyDown(KeyCode.F4)){
                Application.Quit();
                Debug.Log("Quitting game...");
            }
        }
    }

    public void Pause()
    {
        if (UI_ALL.I.Pause.activeSelf == false && UI_ALL.I.You_died.activeSelf == false )
        {
            UI_ALL.I.Pause.SetActive(true);
            Time.timeScale = 0f;     
        }
        else
        {
            UI_ALL.I.Pause.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void PlayerDied()
    {
        isnotPaused = false; // Set the flag to indicate the game is not paused
        UI_ALL.I.You_died.SetActive(true);
        UI_ALL.I.RegionDestroyMsg.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game 1");
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenuScene");
    }
}
