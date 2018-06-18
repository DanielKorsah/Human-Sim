using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{

	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
	public bool Sex { get; set; } //true = male, false = female
	public Dictionary<string, int> Stats { get; set; }

	public static int AllTimeCount { get; set; }

	private GameObject messageController;

	public Person(string first, string last, bool sex, GameObject controller)
	{
		Debug.Log(" overload 1");
		FirstName = first;
		LastName = last;
		Age = 0;
		Sex = sex;
		Id = AllTimeCount;
		AllTimeCount++;

		if (controller != null)
			messageController = controller;
		else
			messageController = GameObject.Find("PersonManager");

		//if sex is true (male) colour modifier is blue, else colour modifier is pink
		string colourMod = sex ? "#4286f4" : "#ff56ff";

		Notification(string.Format("<{0}>{1} {2}</color> was born. ", colourMod, first, last));

	}

	public Person(int id, string first, string last, bool sex, Dictionary<string, int> stats)
	{
		Debug.Log("overload 2");
		Id = id;
		FirstName = first;
		LastName = last;
		Sex = sex;
		Stats = stats;

		messageController = GameObject.Find("PersonManager");
	}

	public Person()
	{
		Debug.Log("overload 3");
		messageController = GameObject.Find("PersonManager");
	}

	public void SetStats(Dictionary<string, int> s)
	{
		Stats = s;
	}

	public void IncrementAge()
	{
		Age++;
	}

	public void Notification(string message)
	{
		MessageController controller = messageController.GetComponent<MessageController>();
		controller.PostMessage(message);
	}
}