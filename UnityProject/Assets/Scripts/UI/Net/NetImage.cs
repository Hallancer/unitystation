﻿using UnityEngine;
using UnityEngine.UI;

///prefab-based for now
public class NetImage : NetUIElement
{
	public override ElementMode InteractionMode => ElementMode.ServerWrite;
	public override string Value {
		get { return prefab ?? "-1"; }
		set {
			externalChange = true;
			Element.sprite = Resources.Load<GameObject>( value )?.GetComponentInChildren<SpriteRenderer>()?.sprite;
			prefab = value;
			externalChange = false;
		}
	}
	private Image element;
	private string prefab;
	public Image Element {
		get {
			if ( !element ) {
				element = GetComponent<Image>();
			}
			return element;
		}
	}
	
	public override void ExecuteServer() {}
}