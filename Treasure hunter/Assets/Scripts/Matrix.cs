using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour {
	public Transform p;//parent of local


	public List<Local> locals = new List<Local>();
	// Use this for initialization

	void Awake()
    {
		int i = 0;
		int j = 0;
		foreach (Transform t in p)
		{
			t.localPosition = new Vector3(i, j);
			locals.Add(new Local(new Vector2(i, j), t));


			if (i < 19)
			{
				i++;
			}
			else
			{
				i = 0;
				j++;
				if (j == 13) break;
			}
		}
    }


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
