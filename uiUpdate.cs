﻿using UnityEngine;
using System.Collections;

public class uiUpdate : MonoBehaviour {

	//Variables for health
	public int maxHealth;
	public RectTransform healthTransform;
	private int currentHealth;
	private float healthBarUnit;
	private float currentHealthXValue;
	private float healthYValue;

	//Variables for hunger
	public int maxHunger;
	public RectTransform hungerTransform;
	private int currentHunger;
	private float hungerBarUnit;
	private float currentHungerXValue;
	private float hungerYValue;

	//Variables for drugs
	public int maxDrugs;
	public RectTransform drugsTransform;
	private int currentDrugs;
	private float drugsBarUnit;
	private float currentDrugsXValue;
	private float drugsYValue;

	//variables for health and hunger
	private float minXValue;
	private float maxXValue;

	//Public setters. 
	public void setCurrentHealth(float delta){
		currentHealthXValue = currentHealthXValue - (delta * healthBarUnit);
        if (currentHealthXValue > maxXValue) {
            healthTransform.localPosition = new Vector3(maxXValue, healthYValue);
        }
        else if (currentHealthXValue < minXValue) {
            healthTransform.localPosition = new Vector3(minXValue, healthYValue);
        }
        else {
            healthTransform.localPosition = new Vector3(currentHealthXValue, healthYValue);
        }
	}
	public void setCurrentHunger(float delta){
		currentHungerXValue = currentHungerXValue - (delta * hungerBarUnit);
        if (currentHungerXValue > maxXValue) {
            hungerTransform.localPosition = new Vector3(maxXValue, hungerYValue);
        }
        else if (currentHungerXValue < minXValue) {
            hungerTransform.localPosition = new Vector3(minXValue, hungerYValue);
        }
        else {
            hungerTransform.localPosition = new Vector3(currentHungerXValue, hungerYValue);
        }
	}
	public void setCurrentDrug(float delta){
		currentDrugsXValue = currentDrugsXValue - (delta * drugsBarUnit);
        if (currentDrugsXValue > maxXValue){
            drugsTransform.localPosition = new Vector3(maxXValue, drugsYValue);
        }
        else if (currentDrugsXValue < minXValue) {
            drugsTransform.localPosition = new Vector3(minXValue, drugsYValue);
        }
        else
        {
            drugsTransform.localPosition = new Vector3(currentDrugsXValue, drugsYValue);
        }
	}

	void Start () {
	
		//set coordinates
		minXValue = healthTransform.localPosition.x - healthTransform.rect.width;
		maxXValue = healthTransform.localPosition.x;
		healthYValue = healthTransform.localPosition.y;
		hungerYValue = hungerTransform.localPosition.y;
		drugsYValue = drugsTransform.localPosition.y;
		//set barUnits. (Should be called if increase/decrease in max hunger and/or health is enabled @runtime)
		healthBarUnit = (maxXValue - minXValue) / maxHealth;
		hungerBarUnit = (maxXValue - minXValue) / maxHunger;
		drugsBarUnit = (maxXValue - minXValue) / maxDrugs;

	}



	// Update is called once per frame
	void Update () {

	}
}
