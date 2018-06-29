using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
	[SerializeField]
	TextMeshProUGUI textBox;

	private int lineCount = 0;

	//
	public void PostMessage(string text)
	{
		lineCount++;
		if (lineCount > 18)
			gameObject.GetComponent<TextOffsetBump>().Bump();
		textBox.text += "\n" + text;
	}

}