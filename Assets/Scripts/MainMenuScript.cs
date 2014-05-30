using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Texture))]
public class MainMenuScript : MonoBehaviour
{
    public Texture BannerTexture;
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
        int w = Screen.width;
        int h = Screen.height;

        // Draw banner
        GUI.DrawTexture(new Rect(w * .100f,     // Width
                                 h * .100f,     // Height
                                 w * .300f,     // Horizontal Position
                                 h * .300f),    // Vertical Position
                                 BannerTexture);

        // Create buttons
        bool PlayButton = GUI.Button(new Rect(w * .100f,    // Width
                                              h * .333f,    // Height
                                              w * .105f,    // Horizontal Position
                                              h * .092f),   // Vertical Position
                                              PlayTexture);

        bool OptionsButton = GUI.Button(new Rect(w * .650f,     // Width
                                                 h * .500f,     // Height
                                                 w * .200f,     // Horizontal Position
                                                 h * .092f),    // Vertical Position
                                                 OptionsTexture);

        bool QuitButton = GUI.Button(new Rect(w * .350f,    // Width
                                              h * .300f,    // Height
                                              w * .200f,    // Horizontal Position
                                              h * .092f),   // Vertical Position
                                              QuitTexture);

        // Handle button presses
        if (PlayButton)
            currentGUIMethod = Play;

        if (OptionsButton)
            currentGUIMethod = Options;

        if (QuitButton)
            currentGUIMethod = Quit;
    }

    void Play()
    {
        Application.LoadLevel(1);
    }

    void Options()
    {
        Application.LoadLevel(0);
    }

    void Quit()
    {
        Application.Quit();
    }

    public void OnGUI()
    {
        this.currentGUIMethod();
    } 
}
