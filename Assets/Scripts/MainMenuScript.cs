using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Texture))]
public class MainMenuScript : MonoBehaviour
{
    public Texture PlayTexture;
    public Texture OptionsTexture;
    public Texture QuitTexture;

    delegate void GUIMethod();
    GUIMethod currentGUIMethod;

    void Start()
    {
        if (!PlayTexture || !OptionsTexture || !QuitTexture)
            Debug.LogError("Button texture is missing!");

        currentGUIMethod = MainMenu;
    }

    void MainMenu()
    {
        int width = Screen.width;
        int height = Screen.height;

        if (GUI.Button(new Rect(width / 3, height / 6, 200, 100), PlayTexture))
            currentGUIMethod = Play;
    }

    void Play()
    {
        Application.LoadLevel(1);
    }

    public void OnGUI()
    {
        this.currentGUIMethod();
    } 
}
