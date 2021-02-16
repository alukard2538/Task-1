using System;
using System.Collections.Generic;

namespace Family
{
    class Program
    {
        static List<string> GetNames(List<Person> members)
        {
            List<string> names = new List<string>();
            if (members.Count != 0)
            {
                foreach (Person member in members)
                {
                    if (member != null)
                        names.Add(member.name);
                }
                return names;
            }
            else
                return null;

        }

        static void PrintNames(List<Person> members)
        {
            if (members.Count != 0)
            {
                foreach (Person member in members)
                {
                    if (member != null)
                        Console.Write(member.name + " ");
                }
            }
            else
                Console.Write("There aren't members");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////////////////
            ////////////////////////Making Family////////////////////////////
            /////////////////////////////////////////////////////////////////
            //First Generation
            Person Earendil = new Person("Earendil");
            Person Elwing = new Person("Elwing");
            Person.Wedding(Earendil, Elwing);

            Person Celeborn = new Person("Celeborn");
            Person Galadriel = new Person("Galadriel");
            Person.Wedding(Celeborn, Galadriel);
                       
            //Second Generation
            Person Elros = new Person("Elros", Earendil);
            Person Elrond = new Person("Elrond", Earendil);

            Person Celebrian = new Person("Celebrian", Celeborn);

            Person ElrosWife = new Person("ElrosWife");

            Person.Wedding(Elrond, Celebrian);
            Person.Wedding(Elros, ElrosWife);

            //Third Generation
            Person Elladan = new Person("Elladan", Elrond);
            Person Elrohir = new Person("Elrohir", Elrond);
            Person Arwen = new Person("Arwen", Elrond);

            Person Vardamir = new Person("Vardamir", Elros);
            Person Atanalcar = new Person("Atanalcar", Elros);
            Person Tindomiel = new Person("Tindomiel", Elros);
            /////////////////////////////////////////////////////////////////



            ///////////////////////////TEST//////////////////////////////////
            Person Sauron = new Person("Sauron");
            Person.Wedding(Sauron, Sauron);
            Person Morgot = new Person("Morgot");
            Person.Wedding(Sauron, Morgot);
            Person Saruman = new Person("Saruman");
            Person.Wedding(Sauron, Saruman);            
            PrintNames(Saruman.GetParents());
            PrintNames(Arwen.GetParents());
            PrintNames(Elrohir.GetUncles());
            PrintNames(Vardamir.GetCousins());
            PrintNames(Elrond.GetInLaw());
            PrintNames(Elrond.GetParents());
            PrintNames(Elrond.GetParents());
            PrintNames(Arwen.GetCousins());
            PrintNames(Arwen.GetCousins());
            Console.ReadLine();
        }
    }
}