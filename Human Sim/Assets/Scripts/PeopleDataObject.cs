using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleDataObject
{
    //<Singleton Boilerplate>
    private static PeopleDataObject instance = null;
    private static readonly object padlock = new object();

    PeopleDataObject() {}

    public static PeopleDataObject Instance
    {
        get
        {
            lock(padlock)
            {
                if (instance == null)
                {
                    instance = new PeopleDataObject();
                }
                return instance;
            }
        }
    }
    //</Singletone Boilerplate>

    public List<Person> People { get; set; }
    public int Count { get; set; }
}