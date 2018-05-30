using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextOffsetBump : MonoBehaviour
{

	[SerializeField]
	TextMeshProUGUI TextBlock;

	public void Bump()
	{
		RectTransform offset = TextBlock.GetComponent<RectTransform>();
		offset.offsetMax += new Vector2(0, 50);
	}
}