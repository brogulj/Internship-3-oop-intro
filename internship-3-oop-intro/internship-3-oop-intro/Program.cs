using System;
using System.Collections.Generic;
namespace internship_3_oop_intro
{
    class Program
    {

        static void Main(string[] args)
        {
            var EventList = new Dictionary<Event, List<Person>>();
            MainMenu(EventList);
            
        }
        public static void MainMenu(Dictionary<Event, List<Person>> EventList)
        {
            var flag = true;
            while (flag)
            {
                Console.WriteLine("Main menu");
                Console.WriteLine("1 - Add an event");
                Console.WriteLine("2 - Remove an event");
                Console.WriteLine("3 - Edit an event");
                Console.WriteLine("4 - Add a person to an event");
                Console.WriteLine("5 - Remove a person from an event");
                Console.WriteLine("6 - Print details of an event");
                Console.WriteLine("7 - Exit the program");
                var userChoice =Console.ReadLine();
                int userChoiceParse;
                Event ChosenEvent;
                if(int.TryParse(userChoice, out userChoiceParse))
                {
                    switch (userChoiceParse)
                    {
                        case 1:
                            AddEvent(EventList);
                            break;
                        case 2:
                            Console.WriteLine("Please enter the name of the event that you want to erase:");
                            var name = GetString();
                            Event Event = GetEventByName(EventList, name);
                            EventList.Remove(Event);
                            break;
                        case 3:
                            EditMenu(EventList);
                            break;
                        case 5:
                            Console.WriteLine("Please enter the name of the event that you wish to remove a person from:");
                            ChosenEvent = GetEventByName(EventList,GetString());
                            RemovePersonFromEvent(EventList, ChosenEvent);
                            break;
                        case 4:
                            Console.WriteLine("Please enter the name of the event that you wish to add a person to:");
                            ChosenEvent = GetEventByName(EventList, GetString());
                            AddPersonToEvent(EventList, ChosenEvent);
                            break;
                        case 6:
                            Console.WriteLine("Please enter the name of the event you want to know more about:");
                            ChosenEvent = GetEventByName(EventList, GetString());
                            Console.WriteLine("Select one of the available formats");
                            Console.WriteLine("1. name - event type - start time - end time");
                            Console.WriteLine("2. (list of people attending) name - last name - phone number");
                            Console.WriteLine("3. combination of 1. option  and 1. option ");
                            Console.WriteLine("4. exit");
                            var userChoice2 = GetInt();
                            switch (userChoice2)
                            {
                                case 1:
                                    ChosenEvent.PrintDetails(EventList[ChosenEvent]);
                                    break;
                                case 2:
                                    ChosenEvent.PrintPeople(EventList[ChosenEvent]);
                                    break;
                                case 3:
                                    ChosenEvent.PrintDetails(EventList[ChosenEvent]);
                                    ChosenEvent.PrintPeople(EventList[ChosenEvent]);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 7:
                            flag = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public static void EditMenu(Dictionary<Event, List<Person>> EventList)
        {
            Console.WriteLine("You have chosen the edit menu.");
            Console.WriteLine("Please enter the name of the event that you want to edit:");
            Event ChosenEvent = GetEventByName(EventList, GetString());
            Console.WriteLine("Please select one of the following options");
            Console.WriteLine("1 - Change the name of the event");
            Console.WriteLine("2 - Change the type of the event");
            Console.WriteLine("3 - Change the start time of the event");
            Console.WriteLine("4 - Change the end time of the event");
            var userChoice = GetInt();
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Please enter the new name of the event:");
                    ChosenEvent.EventName = GetString();
                    break;
                case 2:
                    Console.WriteLine("Please enter the new type of the event:");
                    var TypeList = new List<string> { "Coffe", "Lecture", "Concerts", "StudySession" };
                    var EventTypeState = GetType(TypeList);
                    switch (EventTypeState)
                    {
                        case "Coffe":
                            ChosenEvent.EventTypeState = Event.EventType.Coffe;
                            break;
                        case "Lecture":
                            ChosenEvent.EventTypeState = Event.EventType.Lecture;
                            break;
                        case "Concert":
                            ChosenEvent.EventTypeState = Event.EventType.Concert;
                            break;
                        case "StudySession":
                            ChosenEvent.EventTypeState = Event.EventType.StudySession;
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Please enter the new start time of the event:");
                    ChosenEvent.StartTime = GetDateTime();
                    while (DateTime.Compare(ChosenEvent.StartTime, ChosenEvent.EndTime) >= 0)
                    {
                        Console.WriteLine("You have entered a time that is after the end time of this event.\nPlease enter a new time:");
                        ChosenEvent.StartTime = GetDateTime();
                    }
                    break;
                case 4:
                    Console.WriteLine("Please enter the new start time of the event:");
                    ChosenEvent.EndTime = GetDateTime();
                    while (DateTime.Compare(ChosenEvent.StartTime, ChosenEvent.EndTime) >= 0)
                    {
                        Console.WriteLine("You have entered a time that is before the start time of this event.\nPlease enter a new time:");
                        ChosenEvent.EndTime = GetDateTime();
                    }
                    break;
                default:
                    Console.WriteLine("You have entered a wrong number, we are returning you to the main menu");
                    break;
            }
        }
        public static void AddEvent(Dictionary<Event, List<Person>>EventList)
        {
            string eventName;
            string eventType="";
            

           
            Console.WriteLine("Please enter the name of the event: ");
            eventName = GetString();
            while (eventType!="Coffe" && eventType != "Lecture" && eventType != "Concert" && eventType != "StudySession")
            {
                Console.WriteLine("Please enter the type of the event:");
                eventType = GetString();
            }
            Console.WriteLine("Please enter the start time of this event:");
            var startTime = GetDateTime();
            Console.WriteLine("Please enter the end time of this event:");
            var endTime = GetDateTime();
            while (DateTime.Compare(startTime, endTime) >= 0)
            {
                Console.WriteLine("please enter the end time that is after the start time:");
                endTime = GetDateTime();
            }
            var newEvent = new Event(eventName, eventType, startTime, endTime);
            var listOfPeople = new List<Person>();
            EventList[newEvent] = listOfPeople;
        }
        public static void RemovePersonFromEvent(Dictionary<Event,List<Person>> EventList, Event ChosenEvent)
        {
            bool personRemoved = false;
            Console.WriteLine("Please enter the first name of the person that you want to remove");
            var firstName = GetString();
            Console.WriteLine("Please enter the last name of the person that you want to remove");
            var lastName = GetString();
            foreach (Person element in EventList[ChosenEvent]) {
                if(element.FirstName.ToLower()==firstName.ToLower() && element.LastName.ToLower() == lastName.ToLower())
                {
                    EventList[ChosenEvent].Remove(element);
                    personRemoved = true;
                }
            }
            if (!personRemoved)
            {
                Console.WriteLine("Ime i prezime osobe koje ste unijeli ne odgovara nijednoj osobi na listi.");
            }
        }
        public static void AddPersonToEvent(Dictionary<Event,List<Person>> EventList, Event ChosenEvent)
        {
            bool personAdd = true;
            Console.WriteLine("Enter the first name of that person:");
            var firstName=GetString();
            Console.WriteLine("Enter the last name of that person:");
            var lastName = GetString();
            Console.WriteLine("Enter the OIB of that person:");
            var oIB = GetString();
            Console.WriteLine("Enter the phone number of that person:");
            var phoneNumber = GetString();
            Person newPerson = new Person(firstName, lastName, oIB, phoneNumber);
            foreach(Person element in EventList[ChosenEvent])
            {
                if (oIB == element.OIB)
                {
                    Console.WriteLine("Person was not added because a person with the same OIB already exists on the list");
                    personAdd = false;
                }
            }
            if (personAdd)
            EventList[ChosenEvent].Add(newPerson);

            
        }
        public static string GetString()
        {
            string str="";
            while (str == "")
            {
                
                str = Console.ReadLine();
                if (str != "")
                {
                    return str;
                }
                else
                {
                    Console.WriteLine("There has been an error with your input\nPlease enter the required text again");
                }
            }return str;
        }
        public static int GetInt()
        {
            int integer;
            if (int.TryParse(Console.ReadLine(), out integer))
                {
                    return integer;
                }
            while(true)
            {
                Console.WriteLine("There has been an error with your input.\nPlease enter the required number again");
                if (int.TryParse(Console.ReadLine(), out integer))
                {
                    return integer;
                }
            } 
        }
        public static DateTime GetDateTime()
        {
            int year;
            int month=0;
            int day=0;
            int hour=-10;
            int minute=-10;
            int second=0;
            Console.WriteLine("Please enter the year:");
            year = GetInt();
            while (month > 12 || month < 1)
            {
                Console.WriteLine("Please enter the month:");
                month = GetInt();
            }
            while (day > 30 || day < 1)
            {
                Console.WriteLine("Please enter the day:");
                day = GetInt();
            }
            while (!(hour < 24 && hour > -1))
            {
                Console.WriteLine("Please enter the hour:");
                hour = GetInt();
            }
            while (!(minute < 60 && minute > -1))
            {
                Console.WriteLine("Please enter the minute:");
                minute = GetInt();
            }
            DateTime dateTime= new DateTime(year,month,day,hour,minute,second);
            return dateTime;
        }
        public static string GetType(List<string> TypeList)
        {
            var userInput = "";
            while (!TypeList.Contains(userInput))
            {
                userInput = GetString();
            }
            return userInput;
        }
        public static Event GetEventByName(Dictionary<Event, List<Person>> EventList, string name)
        {
            foreach(KeyValuePair<Event,List<Person>> pair in EventList)
            {
                
                if (pair.Key.EventName.ToLower()==(name.ToLower()))
                {
                    return pair.Key;
                }
            }
            while (true)
            {
                Console.WriteLine("You have entered the event name that does not exist.\nPlease enter another event name.");
                name = GetString();
                foreach (KeyValuePair<Event, List<Person>> pair in EventList)
                {

                    if (pair.Key.EventName.ToLower() == (name.ToLower()))
                    {
                        return pair.Key;
                    }
                }
            }
            
        }
    }
}
