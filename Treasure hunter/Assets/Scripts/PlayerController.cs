using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 1;


	public GameObject wLeft, wRight, wBottom;

	public Transform pLeft, pRight, pBottom;


	public LayerMask layerOfWall;

	int posXUp = 0;

	bool isKeyMove = false;
	bool started = false;
	// Use this for initialization
	void Start()
	{
	}

	private void DestroyLeft()
	{

		if (wLeft == null) return;
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Destroy(wLeft.gameObject);
			wLeft = null;
		}
	}
	private void DestroyRight()
	{

		if (wRight == null) return;
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			Destroy(wRight.gameObject);
			wRight = null;
		}
	}
	private void DestroyBot()
	{

		if (wBottom == null) return;
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			Destroy(wBottom.gameObject);
			wBottom = null;
		}
	}

	// Update is called once per frame
	void Update()
	{
		transform.eulerAngles = new Vector3(0, 0, 0);
		Move();
		DestroyLeft();
		DestroyRight();
		DestroyBot();
		DetectWall();
	}

	private void Move()
	{
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			if (wLeft == null && wBottom != null)
			{
				started = true;
				transform.Translate(-speed, 0, 0);
				isKeyMove = true;
			}
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			if (wRight == null&&wBottom!=null)
			{
				started = true;
				transform.Translate(speed, 0, 0);
				isKeyMove = true;
			}
		}

		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
		{
			isKeyMove = false;
			posXUp = (int)transform.position.x;
			//transform.position = new Vector3((int)transform.position.x, transform.position.y, transform.position.z);
		}
		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
		{
			isKeyMove = false;
			posXUp = (int)transform.position.x + 1;
			//transform.position = new Vector3((int)transform.position.x + 1, transform.position.y, transform.position.z);
		}
		if (!isKeyMove && started)
		{
			transform.position = Vector3.Lerp(transform.position,
				new Vector3(posXUp, transform.position.y, transform.position.z), 0.5f);
		}
	}


	void DetectWall()
	{
		Collider[] colLeft = Physics.OverlapSphere(pLeft.position, 0.1f, layerOfWall);
		Collider[] colRight = Physics.OverlapSphere(pRight.position, 0.1f, layerOfWall);
		Collider[] colBot= Physics.OverlapSphere(pBottom.position, 0.1f, layerOfWall);

		if (colLeft.Length > 0)
			wLeft = colLeft[0].gameObject;
		else wLeft = null;

		if (colRight.Length > 0)
			wRight = colRight[0].gameObject;
		else wRight = null;

		if (colBot.Length > 0)
			wBottom = colBot[0].gameObject;
		else colBot = null;
	}
}
