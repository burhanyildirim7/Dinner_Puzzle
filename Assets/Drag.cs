using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
	private Vector3 mOffset;
	private float mzCoord;
	private void OnMouseDown()
	{
		mzCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		mOffset = gameObject.transform.position - GetMouseWorldPos();
	}

	private void OnMouseDrag()
	{
		Debug.Log(GetMouseWorldPos());
		transform.position = new Vector3(GetMouseWorldPos().x,2,GetMouseWorldPos().z);
	}

	private Vector3 GetMouseWorldPos()
	{
		Vector3 mousePoint = Input.mousePosition;

		mousePoint.z = mzCoord;

		return Camera.main.ScreenToWorldPoint(mousePoint);
	}
}
