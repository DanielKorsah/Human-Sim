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

	public static GameObject messageController;

	public Person(string first, string last, int age, bool sex, Dictionary<string, int> stats)
	{
		Debug.Log("overload 1");
		Id = AllTimeCount;
		AllTimeCount++;

		FirstName = first;
		LastName = last;
		Age = age;
		Sex = sex;
		Stats = stats;

		if (messageController == null)
			messageController = GameObject.Find("PersonManager");
	}

	public Person()
	{
		Debug.Log("overload 2");
		if (messageController == null)
			messageController = GameObject.Find("PersonManager");
	}

	public void IncrementAge()
	{
		Age++;
	}

	private string colourMod()
	{
		//if sex is true (male) colour modifier is blue, else colour modifier is pink
		return Sex ? "#4286f4" : "#ff56ff";
	}

	public void Notification(string input)
	{
		MessageController controller = messageController.GetComponent<MessageController>();

		string message = string.Format("<{0}>{1} {2}</color> ", colourMod(), FirstName, LastName);
		message += input;
		controller.PostMessage(message);
	}
}