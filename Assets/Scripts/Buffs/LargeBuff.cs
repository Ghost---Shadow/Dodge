﻿using UnityEngine;
using System.Collections;

public class LargeBuff : Buff
{
	public Sprite buffSprite;
	
	SpriteRenderer spriteRenderer;
	Buffable obj;
	
	// Use this for initialization
	void Start()
	{
		obj = (Buffable)gameObject.GetComponent(typeof(Buffable));
		spriteRenderer = (SpriteRenderer)gameObject.GetComponent(typeof(SpriteRenderer));
	}
	
	public override void ApplyBuff()
	{
		obj.Size = 3;
		spriteRenderer.sprite = buffSprite;
	}
	
	public override string BuffName
	{
		get 
		{
			return "Tripple Size";
		}
	}
}
