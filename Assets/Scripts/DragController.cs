using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private GameObject selectedObject;

   
    void Update()
    {
		if (GameController.instance.isContinue)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (selectedObject == null)
				{
					RaycastHit hit = CastRay();

					if (hit.collider != null)
					{
						if (!hit.collider.CompareTag("drag"))
						{
							return;
						}
						if(LevelController.instance.totalLevelNo == 1)
						{
							UIController.instance.onBoarding.SetActive(false);
						}
						GameController.instance.ActivateZones();
						selectedObject = hit.collider.gameObject;
						selectedObject.GetComponent<GuestController>().targetPosition = selectedObject.transform.position;
						selectedObject.GetComponent<GuestController>().tempY = selectedObject.transform.position.y;

					}
				}
				//else
				//{
				//	Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
				//	Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
				//	selectedObject.transform.position = new Vector3(worldPosition.x, 1, worldPosition.z);
				//	selectedObject = null;
				//}
			}

			if (Input.GetMouseButtonUp(0))
			{
				if (selectedObject != null)
				{
					if (LevelController.instance.totalLevelNo == 1)
					{
						UIController.instance.onBoarding.SetActive(true);
						if(GameController.instance.onboardingSirasi == 0)
						{
							UIController.instance.onBoardingAnim.SetTrigger("iki");
						}
						else if (GameController.instance.onboardingSirasi == 1)
						{
							UIController.instance.onBoardingAnim.SetTrigger("uc");
						}
						else if (GameController.instance.onboardingSirasi == 2)
						{
							UIController.instance.onBoardingAnim.SetTrigger("dort");
						}
						else
						{
							UIController.instance.onBoarding.SetActive(false);
						}
					}
					Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
					Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
					selectedObject.transform.position = new Vector3(worldPosition.x, selectedObject.GetComponent<GuestController>().tempY, worldPosition.z);
					selectedObject.GetComponent<Collider>().enabled = false;
					StartCoroutine(selectedObject.GetComponent<GuestController>().ControlSandalye());
					selectedObject = null;
					GameController.instance.DeactivateZones();
				}

			}

			if (selectedObject != null)
			{
				Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
				Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
				selectedObject.transform.position = new Vector3(worldPosition.x, selectedObject.GetComponent<GuestController>().tempY + 1.5f, worldPosition.z);
			}
		}
		
    }


	private RaycastHit CastRay()
	{
		Vector3 screenMousePosFar = new Vector3(
			Input.mousePosition.x,
			Input.mousePosition.y,
			Camera.main.farClipPlane
			);

		Vector3 screenMousePosNear = new Vector3(
			Input.mousePosition.x,
			Input.mousePosition.y,
			Camera.main.nearClipPlane
			);

		Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
		Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

		RaycastHit hit;

		Physics.Raycast(worldMousePosNear,worldMousePosFar - worldMousePosNear,out hit);

		return hit;
	}
}
