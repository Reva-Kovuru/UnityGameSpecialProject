using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ALL : MonoBehaviour
{
    
    public static UI_ALL I;
    public TMP_Text timer;
    public Slider hp_controller; 
    public GameObject You_died;
    public GameObject Pause;
    public GameObject RegionDestroyMsg;

    void Awake()
    {
        if ( I != null && I != this ){
            Destroy(this);

        }
        else{
            I = this;
        }
    }

    public void UpdateTimer(float time)
    {
        
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateHealthSlider(float hp)
    {
        hp_controller.maxValue = MainPlayer_Anni.I.MAINPLAYER_FULLHP;
        hp_controller.value = MainPlayer_Anni.I.MAINPLAYER_HP;
    }

    public void ShowInstructions(string instr){
        RegionDestroyMsg.GetComponentInChildren<TextMeshProUGUI>().text = instr;
    }
}


