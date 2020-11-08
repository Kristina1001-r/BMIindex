
using System;
using System.Collections.Generic;
using System.Linq;

using System.Diagnostics;

public class Person
{
    private string name;
    private double weight;
    private double height;

    // constructor
    public Person(string name, double weight, double height)
    {
        this.name = name;
        this.weight = weight;
        this.height = height;
    }
    // utility functions for the class
    public string getName
    {
        get { return name; }
    }
    public double getWeight
    {
        get { return weight; }
    }
    public double getHeight
    {
        get { return height; }
    }

    public void calcBMI()
    {
        double bmi = (this.weight / (this.height / 100 * this.height / 100));

        Console.WriteLine($"Your BMI based on your height and weight  is: {Math.Round(bmi, 1)}");
        if (bmi < 18.5)
            Console.WriteLine("You're underweight.");
        else if (bmi > 18.5 && bmi < 23)
            Console.WriteLine("You're normal weight.");
        else if (bmi > 23)
            Console.WriteLine("You're Overweight.");
    }

}

public class main 
{

    //Created a addPerson method, takes data items needed for a person , along with the list and adds to the list
    static void addPerson(String name, double weight, double height, List<Person> personList)
{
        //Unit Test #1 - check if weight value is not 0 for bmi calculation, the same is done with height

        foreach (var item in personList)
        {
            if (item.getWeight == 0)
                throw new Exception("Weight in kg has to be entered");
            if (item.getHeight == 0)
                throw new Exception("Height in cm has to be entered");

        }

        personList.Add(new Person(name, weight, height));
}

//Created a removePerson method, takes the name of the person to delete and the list.
//Searches the list and if the person is found it removes them from the list
static void removePerson(String nameOfPersonToBeRemoved, List<Person> personList)
{

    Person personToRemove = null;
    foreach (var item in personList)
    {
        if (item.getName == nameOfPersonToBeRemoved)
        {
            // personList.Remove(item);
            personToRemove = (item);
        }
    }
    if (personToRemove != null)
        personList.Remove(personToRemove);
}

//Created a list method, passes a list and loops it for each person, showing their details and the BMI calculation
//returned a count of the number displayed so that I could create a unit test
private static int list(List<Person> personList)
{
    int listCount = 0;
    foreach (var item in personList)
    {
        Console.WriteLine("Name: {0}, Weight: {1}, Height: {2}", item.getName, item.getWeight, item.getHeight);
        item.calcBMI();
        listCount = listCount + 1;
    }
    return listCount;
}


public static void Main()
{
    // create a list of type 'person'
    List<Person> personList = new List<Person>();
   addPerson("John", 55, 165, personList);
    addPerson("Mike", 120, 190, personList);
    addPerson("Alex", 85, 185, personList);
    addPerson("Smith", 85, 195, personList);
    addPerson("Saragh", 55, 165, personList);


        // Unit Test #2 below I check that the list count is 5, just a test unit...
        if (personList.Count() != 5)
        throw new Exception("There should be 5 people on the list");

    int personCountBeforeAdd = personList.Count();
    addPerson("Denis", 99, 195, personList);

    //Unit Test #3 -  I check that the list count has added by one because I added a new person
    if (personList.Count() != personCountBeforeAdd + 1)
        throw new Exception("Something went wrong, person list should have incremented by 1");

    int personCountBeforeDelete = personList.Count();
    removePerson("Denis", personList);
    //Unit Test #4 -  I check that the list count is one list because I removed a new person
    if (personList.Count() != personCountBeforeDelete - 1)
        throw new Exception("Something went wrong, person list should have decremented by 1");

    int listCount = list(personList);
    //Unit Test #5 -  I check that the count of people displayed = number of people in the list
    if (listCount != personList.Count())
        throw new Exception("Something went wrong, person list and the count of number of people displayed do not match");
        // exit prompt
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        
    }
}