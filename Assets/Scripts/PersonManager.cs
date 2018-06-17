using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

	[SerializeField]
	private float saveDelay = 5;
	private float timer;

	void Start()
	{
		timer = saveDelay;

		button = spawnButtonObject.GetComponent<Button>();
		first = GameObject.Find("Name1").GetComponentInChildren<TMP_InputField>();
		last = GameObject.Find("Name2").GetComponentInChildren<TMP_InputField>();

		if (!Directory.Exists(Application.streamingAssetsPath))
			Directory.CreateDirectory(Application.streamingAssetsPath);
		//try to load people from file, if fails people list is unchanged from default empty
		Debug.Log("Preload");
		LoadRoster();
		Debug.Log("PostLoad");

	}

	void Update()
	{
		button.interactable = Validate();

		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			SaveRoster();
			timer = saveDelay;
		}

	}

	private void SaveRoster()
	{

		PeopleDataObject allPeople = PeopleDataObject.Instance;
		allPeople.People = People;
		allPeople.Count = Person.AllTimeCount;

		//serialise list of people, indented, with type info
		var jsonString = JsonConvert.SerializeObject(allPeople, Formatting.Indented, new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.Auto
		});

		string path = Path.Combine(Application.streamingAssetsPath, "PeopleData.json");
		if (!File.Exists(path))
		{
			File.Create(path).Dispose();
		}

		File.WriteAllText(path, jsonString);
		Debug.Log("Saved");
	}

	private void LoadRoster()
	{
		string path = Path.Combine(Application.streamingAssetsPath, "PeopleData.json");
		string debug = Path.Combine(Application.streamingAssetsPath, "debug.json");
		if (!File.Exists(path))
		{
			Debug.Log("NO SAVE FILE RECOGNISED");
		}
		else
		{
			PeopleDataObject allPeople = PeopleDataObject.Instance;
			string jsonString = File.ReadAllText(path);

			//check that the file is read correctly
			File.WriteAllText(debug, jsonString);

			allPeople = JsonConvert.DeserializeObject<PeopleDataObject>(jsonString, new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.Auto
			});
			People = allPeople.People;
			Person.AllTimeCount = allPeople.Count;
			Debug.Log("Loaded");
		}
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
		if (Stats.Count != 6)
		{
			Debug.Log("invalid player stats");
			return false;
		}
		return true;
	}

	//instantiate new person 
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

	//assign rolled numbers to person's attributes
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

	//TODO - implement a point buy option
	public Dictionary<string, int> PointBuy()
	{
		Dictionary<string, int> d = new Dictionary<string, int>();

		return d;
	}

	//return list of top 3 results of 4 rolls
	List<int> BestThreeOfFour()
	{
		//roll 4 times
		List<int> rolls = new List<int>();
		for (int i = 0; i < 4; i++)
		{
			rolls.Add(Random.Range(1, 6));
		}

		List<int> best = new List<int>();

		//take top 3
		for (int i = 0; i < 3; i++)
		{

			best.Add(rolls.ToArray().Max());
			rolls.RemoveAt(rolls.IndexOf(rolls.ToArray().Max()));
		}

		return best;
	}

	//set the numbers on the interface to match those of the current person
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