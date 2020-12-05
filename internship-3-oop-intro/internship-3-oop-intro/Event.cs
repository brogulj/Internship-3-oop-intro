using System;
using System.Collections.Generic;
using System.Text;

namespace internship_3_oop_intro
{
    public class Event
    {
        public Event(string eventName, string eventType, DateTime startTime, DateTime endTime)
        {
            EventName = eventName;
            switch (eventType)
            {
                case "Coffe":
                    EventTypeState = EventType.Coffe;
                    break;
                case "Lecture":
                    EventTypeState = EventType.Lecture;
                    break;
                case "Concert":
                    EventTypeState = EventType.Concert;
                    break;
                case "StudySession":
                    EventTypeState = EventType.StudySession;
                    break;
                default:
                    break;
            }
            StartTime = startTime;
            EndTime = endTime;
        }
        public string EventName { get; set; }
        public enum EventType
        {
            Coffe,
            Lecture,
            Concert,
            StudySession
        }
        public EventType EventTypeState { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public void PrintDetails(List<Person> ListOfPeople)
        {
            Console.WriteLine("Ime eventa: " + EventName);

            Console.WriteLine("Event type: "+ EventTypeState);

            Console.WriteLine("Vrijeme početka eventa: "+ StartTime);

            Console.WriteLine("Vrijeme završetka eventa: " + EndTime);

            Console.WriteLine("Broj ljudi na eventu: " + ListOfPeople.Count);
        }
        public void PrintPeople(List<Person> listOfPeople)
        {
            for(var i=0; i < listOfPeople.Count; i++)
            {
                Console.WriteLine(i+". "+listOfPeople[i].FirstName+" - "+ listOfPeople[i].LastName+" - "+ listOfPeople[i].PhoneNumber);
            }
        }
    }
}
