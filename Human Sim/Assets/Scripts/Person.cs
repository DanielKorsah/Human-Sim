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

	public static int AllTimeCount { get; private set; }
	private int Id { get; }

	public Person(string first, string last, bool sex)
	{
		FirstName = first;
		LastName = last;
		Age = 0;
		Sex = sex;
		Id = AllTimeCount;
		AllTimeCount++;
	}

	public void SetStats(Dictionary<string, int> s)
	{
		stats = s;
	}

	public void IncrementAge()
	{
		Age++;
	}
}