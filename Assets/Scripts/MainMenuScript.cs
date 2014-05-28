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

        //banner.transform.position = Vector3.zero;
        //banner.transform.localScale = Vector3.zero;
        //banner.pixelInset = new Rect(50, 50, 100, 100);
    }

    void MainMenu()
    {
        int width = Screen.width;
        int height = Screen.height;

        // Draw banner
        GUI.DrawTexture(new Rect(width * .1f, height * .1f, 300, 100), BannerTexture);

        // Create buttons
        bool PlayButton = GUI.Button(new Rect(width * .1f, height / 3, width * .105f, height * .092f), PlayTexture);
        bool OptionsButton = GUI.Button(new Rect(width * .65f, height * .5f, width * .2f, height * .092f), OptionsTexture);
        bool QuitButton = GUI.Button(new Rect(width, height, 200, 100), QuitTexture);

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
