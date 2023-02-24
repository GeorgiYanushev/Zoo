using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ZooDB.DataBase;
using ZooDB.Models;

namespace Zoo.ViewModel
{
    internal class EventsViewModel : BaseViewModel
    {

        public List<Event> Events { get; set; }
        public ObservableCollection<Event> FilteredEvents { get; set; }
        public ObservableCollection<Event> SemiFilteredEvets { get; set; }
        public ObservableCollection<DateTime> MyDates { get; private set; }
        public ObservableCollection<string> MyTypes { get; private set; }
        public Command ClearFiltersCommand { get; private set; }

        private string _name;
        private string _type;
        private DateTime? _date;
        private int _cost;

        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged(); } }
        public DateTime? Date { get { return _date; } set { _date = value; OnPropertyChanged(); } }
        public int Cost { get { return _cost; } set { _cost = value; OnPropertyChanged(); } }
        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; } set { _isEnabled = value; OnPropertyChanged(); } 
        }

        private string _mytype;

        public string MyType
        {
            get { return _mytype; }
            set
            {

                    _mytype = value;                
                    if (Events == null)
                    {
                        Events = DBService.FillEvents();
                    }
                    FilterByType(value);
                    OnPropertyChanged(nameof(MyType));
                    OnPropertyChanged(nameof(FilteredEvents));
                    Name =FilteredEvents[0].Name;
                    Cost = FilteredEvents[0].Cost;
                    Type= FilteredEvents[0].EventType.TypeName;
                    Date= FilteredEvents[0].Date;
                
            }
        }
        private DateTime _mydate;
        public DateTime MyDate
        {
            get { return _mydate; }
            set
            {
                if(_mydate!=value)
                {
                    _mydate=value;
                    OnPropertyChanged();
                    if (Events==null)
                    {
                        Events = DBService.FillEvents();
                    }
                    FilterByDate(value);
                    OnPropertyChanged(nameof(FilteredEvents));                 
                    Name = FilteredEvents[0].Name;
                    Cost = FilteredEvents[0].Cost;
                    Type = FilteredEvents[0].EventType.TypeName;
                    Date = FilteredEvents[0].Date;
                }
            }
        }

        private Event _myinfo;

        public Event MyInfo
        {
            get { return _myinfo; }
            set
            {
                _myinfo = value; OnPropertyChanged();
                if (Events == null)
                {
                    Events = DBService.FillEvents();
                }
                if (value != null)
                {
                    Name = value.Name;
                    Cost = value.Cost;
                    Type = value.EventType.TypeName;
                    Date = value.Date;
                }
            }
        }
        public EventsViewModel()
        {
            MyDates = new ObservableCollection<DateTime>(DBService.GetEventDate());
            MyTypes =new ObservableCollection<string>(DBService.GetEventType());
            MyTypes.Add("All");
            MyType = MyTypes.Last();
            ClearFiltersCommand = new Command(ClearFilter);
            IsEnabled = false;
        }

        public void FilterByType(string type)
        {
            if (type == "All")
            {
                FilteredEvents = new ObservableCollection<Event>(Events);
                MyDates = new ObservableCollection<DateTime>(DBService.GetEventDate());
                MyDates.Add(DateTime.MinValue);
                OnPropertyChanged(nameof(MyDates));
            }
            else
            {
               FilteredEvents = new ObservableCollection<Event>(Events.Where(x=>x.EventType.TypeName==type));
               SemiFilteredEvets = new ObservableCollection<Event>(FilteredEvents);
               MyDates.Clear();
               foreach (DateTime e in FilteredEvents.Select(x => x.Date).Distinct())
                {
                    MyDates.Add(e.Date);
                }
               IsEnabled = true;
            }

        }
        public void FilterByDate(DateTime date)
        {
            DateTime blank = new();
            if (date == blank)
            {
                FilteredEvents = new ObservableCollection<Event>(Events);
            }
            else
            {
                FilteredEvents = new ObservableCollection<Event>(SemiFilteredEvets.Where(x => x.Date == date));
            }
        }
       public void ClearFilter(object command)
        {
            MyType = "All";
            MyDate = DateTime.MinValue;
            IsEnabled = false;
        }
    }
}
