using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggler : MonoBehaviour
{
	Toggle thisToggle;

	public void Flip()
	{
		thisToggle = gameObject.GetComponent<Toggle>();
		Toggle[] toggles = FindObjectsOfType<Toggle>();

		foreach (Toggle t1 in toggles)
		{
			ifMale(toggles);
			ifFemale(toggles);
		}
	}

	//if the gameobject htis script is attached to is MALE, set isOn to the opposite of the value on the other toggle
	void ifMale(Toggle[] toggles)
	{
		if (gameObject.name == "ToggleMale")
		{
			foreach (Toggle t2 in toggles)
			{
				if (t2.name == "ToggleFemale")
				{
					thisToggle.isOn = !t2.GetComponent<Toggle>().isOn;
				}
			}
		}
	}

	//if the gameobject htis script is attached to is FEMALE, set isOn to the opposite of the value on the other toggle
	void ifFemale(Toggle[] toggles)
	{
		if (gameObject.name == "ToggleFemale")
		{
			foreach (Toggle t2 in toggles)
			{
				if (t2.name == "ToggleMale")
				{
					thisToggle.isOn = !t2.GetComponent<Toggle>().isOn;
				}
			}
		}
	}
}