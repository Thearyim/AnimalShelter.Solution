using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace AnimalShelter.Models
{
  public class Animal
  {
    private string _name;
    private string _type;
    private string _sex;
    private DateTime _dateOfAdmittance;
    private string _breed;

    public Animal(string AnimalName, string AnimalType, string AnimalSex, DateTime AnimalDateOfAdmittance, string AnimalBreed)
    {
      _name = AnimalName;
      _type = AnimalType;
      _sex = AnimalSex;
      _dateOfAdmittance = AnimalDateOfAdmittance;
      _breed = AnimalBreed;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetType()
    {
      return _type;
    }

    public string GetSex()
    {
      return _sex;
    }

    public DateTime GetDateOfAdmittance()
    {
      return _dateOfAdmittance;
    }

    public string GetBreed()
    {
      return _breed;
    }

    public static List<Animal> GetAll()
    {
      List<Animal> allAnimals = new List<Animal> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM Animal;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string AnimalName = rdr.GetString(0);
        string AnimalType = rdr.GetString(1);
        string AnimalSex = rdr.GetString(2);
        DateTime AnimalDateOfAdmittance = rdr.GetDateTime(3);
        string AnimalBreed = rdr.GetString(4);
        Animal newAnimal = new Animal(AnimalName, AnimalType, AnimalSex, AnimalDateOfAdmittance, AnimalBreed);
        allAnimals.Add(newAnimal);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allAnimals;
    }

    // public static Animal Find(int searchId)
    // {
    //   return _instances[searchId-1];
    // }

  //   public List<Animal> GetAnimals()
  //   {
  //     return _Animals;
  //   }
  //
  //   public void AddAnimal(Animal animal)
  //   {
  //     _animals.Add(animal);
  //   }
  }
}
