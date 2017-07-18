using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 2;
	}
	
	// Update is called once per frame
	void Update () {
		// User pressed the left mouse up
		if (Input.GetMouseButtonUp(0))
		{
			MouseButtonUp(0);
		}
		// User pressed the right mouse up
		else if (Input.GetMouseButtonUp(1))
		{
			MouseButtonUp(1);
		}
	}

	// Toggle Open or lock
	void MouseButtonUp(int Button) {
		FCMain pMain = GetHitChest(Input.mousePosition);
		if (pMain != null)
		{
			if (Button == 0)
			{
				pMain.ToggleOpen();
			}
			else if (Button == 1)
			{
				pMain.ToggleLock();
			}
		}
	}

	FCMain GetHitChest(Vector3 hitPosition) {
		// We need to actually hit an object
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(hitPosition);
		if (Physics.Raycast(ray, out hit, 1000, Gob.LAYER_MASK_CHEST))
		{
			if (hit.collider)
			{
				// Return FCMain of the chest that was hit
				return hit.collider.gameObject.GetComponent<FCMain>();
			}
		}

		return null;
	}
}
