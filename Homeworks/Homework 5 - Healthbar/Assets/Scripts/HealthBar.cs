using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Image barImage;

	public Color barColor = Color.white;

	float currentFraction = 1.0f;
	float targetFill = 0.0f;


	public void UpdateBar(float currentValue, float maxValue)
	{
		if (barImage == null)
			return;

		currentFraction = currentValue / maxValue;

		if (currentFraction < 0 || currentFraction > 1)
			currentFraction = currentFraction < 0 ? 0 : 1;

		targetFill = currentFraction;

		barImage.fillAmount = targetFill;

	}
}