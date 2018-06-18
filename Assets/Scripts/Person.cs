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