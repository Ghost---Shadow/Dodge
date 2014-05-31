using UnityEngine;
using System.Collections;

public class GUIHandler : MonoBehaviour {

	public enum MyButton{
		play,
		music,
		exit
	}
	public MyButton button;
	public Texture alternateTexture = null;

	private bool isMusicPlaying = true;
	private Texture originalTexture = null;

	void Awake(){
		originalTexture = this.gameObject.guiTexture.texture;
	}
	void OnMouseDown(){
		if(button == MyButton.play){
			Application.LoadLevel("Level01");
		}else if (button == MyButton.music){
			// TODO: Add music
			isMusicPlaying = !isMusicPlaying;
			if(isMusicPlaying)
				this.gameObject.guiTexture.texture = originalTexture;
			else
				this.gameObject.guiTexture.texture = alternateTexture;
		} else if(button == MyButton.exit){
			Application.Quit();
		}
	}
}
