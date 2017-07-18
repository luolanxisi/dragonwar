using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpBar : MonoBehaviour {
	private float rate = 1f;
	private Image progressBarUi;

	// Use this for initialization
	void Start () {
		progressBarUi = transform.GetChild(1).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		progressBarUi.fillAmount = rate;
	}

	public void setRate(float value) {
		rate = value;
	}
}
