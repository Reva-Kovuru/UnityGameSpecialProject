using TMPro;
using UnityEngine;

public class LoginCanvasScript : MonoBehaviour
{
    public static LoginCanvasScript I;

    public GameObject errorDisplay;
    public TextMeshProUGUI userButton1;
    public TextMeshProUGUI userButton2;
    public TextMeshProUGUI userButton3;
    void Awake()
    {
        if ( I != null && I != this ){
            Destroy(this);
        }
        else{
            I = this;
        }
        ButtonTextSetter();
    }

    void Update()
    {
        ButtonTextSetter();
    }

    public void ErrorCanvasPrint()
    {
        errorDisplay.SetActive(true);
    }

    public void ErrorCanvasClose()
    {
        errorDisplay.SetActive(false);
    }
    public void ButtonTextSetter(){
        if(LoginEverythingScript.I.saveObject.users.Count == 1){
            userButton1.text = LoginEverythingScript.I.saveObject.users[0];
        }
        if(LoginEverythingScript.I.saveObject.users.Count == 2){
            userButton1.text = LoginEverythingScript.I.saveObject.users[0];
            userButton2.text = LoginEverythingScript.I.saveObject.users[1];
        }
        if(LoginEverythingScript.I.saveObject.users.Count == 3){
            userButton1.text = LoginEverythingScript.I.saveObject.users[0];
            userButton2.text = LoginEverythingScript.I.saveObject.users[1];
            userButton3.text = LoginEverythingScript.I.saveObject.users[2];
        }
    }
}
