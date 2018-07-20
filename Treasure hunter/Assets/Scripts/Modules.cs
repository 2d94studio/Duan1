using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modules : MonoBehaviour {
	// Use this for initialization
	void Start ()
	{
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[System.Serializable]
public class Local
{
	public Transform transform;
	public int posX;
	public int posY;

	public Vector2 pos
	{
		set
		{
			posX = (int)value.x;
			posY = (int)value.y;
		}
		get
		{
			return new Vector2(posX, posY);
		}
	}
	public Local(Vector2 vector2, Transform transform)
	{
		pos = vector2;
		this.transform = transform;
	}
	public Local()
	{
		pos = Vector2.zero;
	}
}