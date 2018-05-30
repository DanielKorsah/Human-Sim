﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonManager : MonoBehaviour
{

	public bool RollForStats;
	public List<Person> People = new List<Person>();

	private Dictionary<string, int> Stats = new Dictionary<string, int>();

	[SerializeField]
	Dictionary<string, int> h;

	[SerializeField]
	private List<int> vals;

	[SerializeField]
	private GameObject messageController;

	[SerializeField]
	private GameObject spawnButtonObject;

	private Button button;
	private TMP_InputField first;
	private TMP_InputField last;

	void Start()
	{
		button = spawnButtonObject.GetComponent<Button>();
		first = GameObject.Find("Name1").GetComponentInChildren<TMP_InputField>();
		last = GameObject.Find("Name2").GetComponentInChildren<TMP_InputField>();
	}

	void Update()
	{
		button.interactable = Validate();
	}

	private bool Validate()
	{
		if (ValidNames() && HasStats())
			return true;
		else
			return false;
	}

	private bool ValidNames()
	{
		if (first.text != "" && last.text != "")
			return true;
		else
			return false;
	}

	private bool HasStats()
	{
		foreach (var stat in Stats)
		{
			if (stat.Value == 0)
			{
				Debug.Log("invalid player stats");
				return false;
			}
		}
		return true;
	}

	public void Spawn()
	{

		bool male = GameObject.Find("ToggleMale").GetComponent<Toggle>().isOn;
		Person newborn = new Person(first.text, last.text, male, messageController);
		if (RollForStats)
			newborn.SetStats(Stats);
		else
			newborn.SetStats(Stats);

		People.Add(newborn);

	}

	public void RollStats()
	{
		Dictionary<string, int> d = new Dictionary<string, int>();
		List<string> Attributes = new List<string> { "str", "dex", "con", "int", "wis", "cha" };
		for (int i = 0; i < 6; i++)
		{

			List<int> topThree = BestThreeOfFour();
			d.Add(Attributes[i], topThree.Sum());

		}

		Stats = d;
		SetGUINums();

		vals = d.Values.ToList();
	}

	public Dictionary<string, int> PointBuy()
	{
		Dictionary<string, int> d = new Dictionary<string, int>();

		return d;
	}

	List<int> BestThreeOfFour()
	{
		List<int> rolls = new List<int>();
		for (int i = 0; i < 4; i++)
		{
			rolls.Add(Random.Range(1, 6));
		}

		List<int> best = new List<int>();

		for (int i = 0; i < 3; i++)
		{

			best.Add(rolls.ToArray().Max());
			rolls.RemoveAt(rolls.IndexOf(rolls.ToArray().Max()));
		}

		return best;
	}

	void SetGUINums()
	{
		GameObject numberContainer = GameObject.Find("Numbers");
		Transform[] children = numberContainer.GetComponentsInChildren<Transform>();
		foreach (Transform slot in children)
		{
			if (slot.name == "StrNum")
				slot.GetComponent<TMP_Text>().text = Stats["str"].ToString();
			if (slot.name == "DexNum")
				slot.GetComponent<TMP_Text>().text = Stats["dex"].ToString();
			if (slot.name == "ConNum")
				slot.GetComponent<TMP_Text>().text = Stats["con"].ToString();
			if (slot.name == "IntNum")
				slot.GetComponent<TMP_Text>().text = Stats["int"].ToString();
			if (slot.name == "WisNum")
				slot.GetComponent<TMP_Text>().text = Stats["wis"].ToString();
			if (slot.name == "ChaNum")
				slot.GetComponent<TMP_Text>().text = Stats["cha"].ToString();
		}

	}
}