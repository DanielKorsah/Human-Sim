using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; private set; }
	public bool Sex { get; private set; } //true = male, false = female
	public Dictionary<string, int> stats { get; private set; }

	public static int AllTimeCount { get; set; }
	private int Id { get; }

	GameObject MC;

	public Person(string first, string last, bool sex, GameObject cont)
	{
		FirstName = first;
		LastName = last;
		Age = 0;
		Sex = sex;
		Id = AllTimeCount;
		AllTimeCount++;

		MC = cont;

		string colourMod = sex ? "#4286f4" : "#ff56ff";

		Notification(string.Format("<{0}>{1} {2}</color> was born. ", colourMod, first, last));

	}

	public void SetStats(Dictionary<string, int> s)
	{
		stats = s;
	}

	public void IncrementAge()
	{
		Age++;
	}

	public void Notification(string message)
	{
		MessageController controller = MC.GetComponent<MessageController>();
		controller.PostMessage(message);
	}
}