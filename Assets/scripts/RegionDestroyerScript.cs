using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class RegionDestroyerScript : MonoBehaviour
{
    private GameObject First_Bound;
    private GameObject Second_Bound;
    private bool isDestroyable = false;
    void Awake()
    {
        First_Bound = GameObject.FindGameObjectWithTag("First_Bound");
        Second_Bound = GameObject.FindGameObjectWithTag("Second_Bound");
        isDestroyable = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    async Task Update()
    {
        if(isDestroyable){
            UI_ALL.I.ShowInstructions("Press E to Unlock Next Mission");
            if (Keyboard.current.eKey.wasPressedThisFrame){
                DestroyBounds();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isDestroyable = true;
        }
    }
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.gameObject.CompareTag("Player"))
    //     {
    //         isDestroyable = false;
    //         UI_ALL.I.ShowInstructions("Find This Region's Monolith");
    //     }
    // }

    private async Task DestroyBounds()
    {
        isDestroyable = false;
        if (First_Bound != null && Second_Bound != null)
        {
            Destroy(First_Bound);
            UI_ALL.I.ShowInstructions("Find New Region's Monolith");
            DataLoggerScript.I.FinalSave();
            await RunNotebook.I.RunPythonScriptAsync();
            Destroy(gameObject);
        }
        else if (First_Bound == null && Second_Bound != null)
        {
            Destroy(Second_Bound);
            UI_ALL.I.ShowInstructions("Find the last Monolith");
            DataLoggerScript.I.FinalSave();
            await RunNotebook.I.RunPythonScriptAsync();
            // RunNotebook.I.RunJupyterNotebook();
            Destroy(gameObject);
        }
        else if (First_Bound == null && Second_Bound == null)
        {
            // Destroy(Second_Bound);
            UI_ALL.I.ShowInstructions("Beat your Previous Record!!");
            DataLoggerScript.I.FinalSave();
            await RunNotebook.I.RunPythonScriptAsync();
            // RunNotebook.I.RunJupyterNotebook();
            Destroy(gameObject);
        }

    }
}
