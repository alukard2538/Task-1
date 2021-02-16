using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Family
{
    class Person
    {
        public string name { get; }
        private Person spouse { get; set; }
        private Person parent { get; }
        private List<Person> parents_list = new List<Person>();
        private List<Person> childs_list = new List<Person>();

        public Person(string name, Person parent = null, Person spouse = null)
        {
            this.name = name;
            this.parent = parent;
            this.spouse = spouse;

            if (parent != null)
            {
                this.parent.childs_list.Add(this);
                this.parents_list.Add(this.parent);
                if (this.parent.spouse != null)
                {
                    this.parent.spouse.childs_list.Add(this);
                    this.parents_list.Add(this.parent.spouse);
                }                
            }
        }

        public List<Person> GetChilds()
        {
            return this.childs_list;
        }

        public List<Person> GetParents()
        {            
            return this.parents_list;
        }

        public List<Person> GetSiblings()
        {
            List<Person> siblings_list = new List<Person>();
            if (this.parent != null)
            {
                foreach (Person parent in this.GetParents())
                {
                    foreach (Person sibling in parent.GetChilds())
                    {
                        if (sibling != null)
                        {
                            if (sibling != this)
                            {
                                if (!siblings_list.Contains(sibling))
                                    siblings_list.Add(sibling);
                            }
                        }

                    }
                }
                return siblings_list;
            }
            else
                return null;
            
        }

        public List<Person> GetUncles()
        {
            List<Person> uncles_list = new List<Person>();
            if (this.parent != null)
            {
                foreach (Person parent in this.GetParents())
                {
                    if (parent.parent != null)
                    {
                        foreach (Person uncle in parent.GetSiblings())
                        {
                            if (uncle != null)
                            {
                                if (!uncles_list.Contains(uncle))
                                    uncles_list.Add(uncle);
                                if (uncle.spouse != null)
                                {
                                    if (!uncles_list.Contains(uncle.spouse))
                                        uncles_list.Add(uncle.spouse);
                                }
                            }
                        }
                    }                    
                }
                return uncles_list;
            }
            else
                return null;
        }

        public List<Person> GetCousins()
        {
            List<Person> cousins_list = new List<Person>();
            if (this.parent != null)
            {
                foreach (Person uncle in this.GetUncles())
                {
                    if (uncle != null)
                    {
                        foreach (Person cousine in uncle.GetChilds())
                        {
                            if (cousine != null)
                            {
                                if (!cousins_list.Contains(cousine))
                                    cousins_list.Add(cousine);
                            }
                        }
                    }

                }
                return cousins_list;
            }
            else
                return null;            
        }

        public List<Person> GetInLaw()
        {
            List<Person> inlaw_list = new List<Person>();
            if (this.spouse != null)
            {
                if (this.spouse.parent != null)
                {
                    foreach (Person inlaw in this.spouse.GetParents())
                    {
                        if (inlaw != null)
                            inlaw_list.Add(inlaw);
                    }
                }                
                return inlaw_list;
            }
            else
                return null;            
        }

        public static void Wedding(Person a, Person b)
        {
            if (a == b)
                Console.WriteLine(a.name + " can't marry himself");
            else if (a.spouse != null)
                Console.WriteLine(a.name + " already has a spouse - " + a.spouse.name);
            else if (b.spouse != null)
                Console.WriteLine(b.name + " already has a spouse - " + b.spouse.name);
            else 
            {
                a.spouse = b;
                b.spouse = a;
            }                       
        }              
    }
}