using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ZooDB.DataBase;
using ZooDB.Models;

namespace Zoo.ViewModel
{
    internal class TicketsViewModel : BaseViewModel
    {
        private List<Event> Events { get; set; }
        private string _name;
        private string _type;
        private DateTime _date;
        private int _cost;
        private string _ticketVariant;
        private int _amount;
        private int _price;
        private string _myname;
        private string _mycost;
        private int dummy;
        private Visibility _ticketVisibility;

        public ObservableCollection<string> MyNames { get; private set; }
        public ObservableCollection<string> MyTicketTypes { get; private set; }
        public Command ShowCommand { get; private set; }
        public Command TicketCommand { get; private set; }
        public Command CalculateCommand { get; private set; }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged(); } }
        public DateTime Date { get { return _date; } set { _date = value; OnPropertyChanged(); } }
        public int Cost { get { return _cost; } set { _cost = value; OnPropertyChanged(); } }
        public int Amount { get { return _amount; } set { _amount = value; OnPropertyChanged(); } }
        public int Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }
        public string TicketVariant { get { return _ticketVariant; } set { _ticketVariant = value; OnPropertyChanged(); } }
        public string MyName
        {
            get { return _myname; }
            set
            {
                _myname = value; OnPropertyChanged();
                if (Events == null)
                {
                    Events = DBService.FillEvents();
                }
                for (int i = 0; i < Events.Count; i++)
                {
                    if (Events[i].Name == value)
                    {

                        Name = Events[i].Name;
                        Type = Events[i].EventType.TypeName;
                        Date = Events[i].Date;
                        dummy = Events[i].Cost;
                        MyCost = "Standard Ticket";
                        TicketVisibility = Visibility.Visible;
                        break;
                    }
                }
            }
        }
        public string MyCost
        {
            get { return _mycost; }
            set
            {
                _mycost = value; OnPropertyChanged();
                if (value == "Standard Ticket")
                {
                    Cost = dummy;
                }
                if (value == "Family Ticket")
                {
                    Cost = dummy + 5;
                }
                if (value == "Student Ticket")
                {
                    Cost = dummy - 5;
                }
                TicketVariant = value;
            }
        }
        public Visibility TicketVisibility
        {
            get { return _ticketVisibility; }
            set { _ticketVisibility = value; OnPropertyChanged(); }
        }

        public TicketsViewModel()
        {
            TicketVisibility = Visibility.Hidden;
            MyTicketTypes = new ObservableCollection<string>()
            {
                "Standard Ticket",
                "Family Ticket",
                "Student Ticket"
            };
            MyNames = new ObservableCollection<string>(DBService.GetEventName());
            MyName = MyNames[0];
            CalculateCommand = new Command(Calc);

        }
        public void Calc(object message)
        {
            Price = Cost * Amount;
        }
    }
}
