using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZooDB.Models;
using ZooDB.DataBase;
namespace Zoo.ViewModel
{
    internal class AnimalsViewModel : BaseViewModel
    {

        private string _bio;
        private byte[] _picture;
        private Animal _animalinfo;
        private string _myspecie;

        public ObservableCollection<string> MySpecies { get; private set; }
        public List<Animal> Animals { get; set; }
        public ObservableCollection<Animal> FilteredAnimals { get; set; }


        public string Bio
        {
            get { return _bio; }
            set { _bio = value; OnPropertyChanged(); }
        }
        public byte[] Picture
        {
            get { return _picture; }
            set { _picture = value; OnPropertyChanged(); }
        }
        public Animal AnimalInfo
        {
            get { return _animalinfo; }
            set
            {
                _animalinfo = value; OnPropertyChanged();
                if (value != null)
                {
                    Bio = value.Bio;
                    Picture = value.Picture;
                }
            }
        }
        public string MySpecie
        {
            get { return _myspecie; }
            set
            {

                if (_myspecie != value)
                {
                    _myspecie = value; OnPropertyChanged();
                    if (Animals == null)
                    {
                        Animals = DBService.FillAnimals();
                    }
                    if (value == "All")
                    {
                        FilteredAnimals = new ObservableCollection<Animal>(Animals);
                    }
                    else
                    { FilteredAnimals = new ObservableCollection<Animal>(Animals.Where(x => x.Species == value)); }
                    OnPropertyChanged(nameof(FilteredAnimals));
                    Bio = FilteredAnimals[0].Bio;
                    Picture = FilteredAnimals[0].Picture;
                }
            }
        }
        public AnimalsViewModel()
        {
            MySpecies = new ObservableCollection<string>(DBService.GetAnimalSpecies());
            MySpecie=MySpecies.First();
            
        }

    }
}
