using UnityEngine;
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

	//variables for health and hunger
	private float minXValue;
	private float maxXValue;

	//Public setters. 
	public void setCurrentHealth(float delta){
		currentHealthXValue = currentHealthXValue - (delta * healthBarUnit);
		healthTransform.localPosition = new Vector3(currentHealthXValue, healthYValue);
	}
	public void setCurrentHunger(float delta){
		currentHungerXValue = currentHungerXValue - (delta * hungerBarUnit);
		hungerTransform.localPosition = new Vector3(currentHungerXValue, hungerYValue);
	}

	void Start () {
	
		//set barUnits. (Should be called if increase/decrease in max hunger and/or health is enabled @runtime)
		minXValue = healthTransform.localPosition.x - healthTransform.rect.width;
		maxXValue = healthTransform.localPosition.x;
		healthYValue = healthTransform.localPosition.y;
		hungerYValue = hungerTransform.localPosition.y;
		healthBarUnit = (maxXValue - minXValue) / maxHealth;
		hungerBarUnit = (maxXValue - minXValue) / maxHunger;

	}



	// Update is called once per frame
	void Update () {

	}
}
