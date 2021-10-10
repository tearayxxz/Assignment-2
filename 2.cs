using System;
using System.Collections.Generic;
enum Menu
{
    Register = 1,
    Login = 2
}
namespace ConsoleApp3
{
    class EquipmentStore
    {
        public List<string> BuyingList = new List<string>();
        List<string> Buying = new List<string>();
        public EquipmentStore()
        {
            BuyingList.Add("Pencil");
            BuyingList.Add("Pen");
            BuyingList.Add("Eraser");
            BuyingList.Add("Liquid Paper");
        }
        public void AddCart(string name)
        {
            Buying.Add(name);
        }

        public void GetList()
        {
            if (Buying.Count == 0)
            {
                Console.WriteLine("Nothing in cart");
            }
            else
            {
                Console.WriteLine("Buying List:");
                foreach (string i in Buying)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
    class Person
    {
        public string User;
        public string PassWord;
        public string Type;
        public string StudentID;
        public string TeacherID;
        public string Address;
    }
    class Registor : Person
    {
        private List<Person> PERSON;
        public Registor() 
        {
            PERSON = new List<Person>();
        }
        public void AddNewPerson(Person account)
        {
            PERSON.Add(account);
        }
        public void FetchPersonsList()

        {
            foreach (Person person in PERSON)
            {
                if (person.Type == "1")
                {
                    Console.WriteLine("");
                    Console.WriteLine("------------------");
                    Console.WriteLine("Student Management");
                    Console.WriteLine("------------------");
                    Console.WriteLine("Name:{0}", person.User);
                    Console.WriteLine("Student ID:{0}", person.StudentID);
                    Console.WriteLine("Address :{0}", person.Address);
                }
                else if (person.Type == "2")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Teacher Management");
                    Console.WriteLine("------------------");
                    Console.WriteLine("Name:{0}", person.User);
                    Console.WriteLine("Employee ID:{0}", person.TeacherID);
                    Console.WriteLine("Address :{0}", person.Address);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string decide = "y";
            string selectBook = "";
            EquipmentStore store = new EquipmentStore();
            Registor ListUser = new Registor();
            Person person = new Person();
            Menuscreen();
            InputMenu(ListUser, selectBook, decide, store, person);
        }
        static void Menuscreen()
        {
            Console.WriteLine("Welcome to school supplies store");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1.Register");
            Console.WriteLine("2.Login");
        }
        static void InputMenu(Registor ListUser, string selectBook, string decide, EquipmentStore store, Person person) //สร้างmethod InputMenu ใส่ค่าเมนูแรก
        {
            Console.Write("Select Menu: ");
            Menu menu = (Menu)int.Parse(Console.ReadLine());
            PresentMenu(menu, ListUser, selectBook, decide, store, person);
        }
        static void PresentMenu(Menu menu, Registor ListUser, string selectBook, string decide, EquipmentStore store, Person person)
        {
            if (menu == Menu.Register)
            {
                Registoration(ListUser, selectBook, decide, store, person);
            }
            else if (menu == Menu.Login)
            {
                Login(ListUser, selectBook, decide, store, person);
            }
        }
        static void Registoration(Registor ListUser, string selectBook, string decide, EquipmentStore store, Person person)
        {
            Console.Clear();

            Console.WriteLine("Register new Person");
            Console.WriteLine("------------------");
            Console.WriteLine("Are you a student or teacher");
            Console.Write("Input User Type 1 = Student, 2 = Employee: ");
            person.Type = Console.ReadLine();
            Console.WriteLine("------------------");
            Console.Write("Input name: ");
            person.User = Console.ReadLine();

            Console.Write("Input Password: ");
            person.PassWord = Console.ReadLine();

            Console.Write("Input Address: ");
            person.Address = Console.ReadLine();

            if (person.Type == "1")
            {
                Console.Write("Student ID: ");
                person.StudentID = Console.ReadLine();
            }
            else if (person.Type == "2")
            {
                Console.Write("Employee ID: ");
                person.TeacherID = Console.ReadLine();
            }
            ListUser.AddNewPerson(person);
            Console.WriteLine("Done");

            Console.Clear();
            Menuscreen();
            InputMenu(ListUser, selectBook, decide, store, person);
        }
        static void Login(Registor ListUser, string selectBook, string decide, EquipmentStore store, Person person)
        {
            Console.Clear();
            Console.WriteLine("Login Screen");
            Console.WriteLine("------------------");
            Console.Write("Input Name: ");
            string LoginUser = Console.ReadLine();
            Console.Write("Input Password: ");
            string LoginPass = Console.ReadLine();
            if (LoginUser == person.User)
            {
                if (LoginPass == person.PassWord)
                {
                    ListUser.FetchPersonsList();
                    Console.WriteLine("------------------");
                    Console.ReadLine();
                    Book(selectBook, decide, store);
                }
            }
            else
            {
                Console.WriteLine("------------------");
                Console.WriteLine("  Worng!!!");
                Console.WriteLine("------------------");
                Console.WriteLine("Please Enter to continue");
                Console.ReadLine();
                Console.Clear();
                Menuscreen();
                InputMenu(ListUser, selectBook, decide, store, person);
            }
        }
        static void Book(string selectBook, string decide, EquipmentStore store)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Book List");
                Console.WriteLine("------------");
                foreach (string i in store.BuyingList) 
                {
                    Console.WriteLine("Book ID: {0}", (store.BuyingList.IndexOf(i) + 1) + " ");
                    Console.Write("Book name: ");
                    Console.WriteLine(i);
                }
                Console.Write("Input book ID : ");
                selectBook = Console.ReadLine();
                switch (selectBook)
                {
                    case "1":
                        store.AddCart(store.BuyingList[0]);
                        Console.WriteLine("Added " + store.BuyingList[0]);
                        break;
                    case "2":
                        store.AddCart(store.BuyingList[1]);
                        Console.WriteLine("Added " + store.BuyingList[1]);
                        break;
                    case "3":
                        store.AddCart(store.BuyingList[2]);
                        Console.WriteLine("Added " + store.BuyingList[2]);
                        break;
                    case "4":
                        store.AddCart(store.BuyingList[3]);
                        Console.WriteLine("Added " + store.BuyingList[3]);
                        break;
                    default:
                        Console.WriteLine("Not Added to cart.");
                        break;
                }
                Console.WriteLine("Type exit or press Enter for continue");
                decide = Console.ReadLine();
                Console.Clear();
            }
            while (decide != "exit");
            store.GetList();
        }
    }
}
