
using HBSJ64_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HBSJ64_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {

        public RestCollection<Actor> RestActors { get; set; }
        public RestCollection<Director> RestDirectors { get; set; }
        public RestCollection<Film> RestFilms { get; set; }


        private Film selectedFilm;
        public Film SelectedFilm
        {
            get { return selectedFilm; }
            set 
            {
                if (value != null)
                {
                    selectedFilm = new Film()
                    {
                        FilmId = value.FilmId,
                        Title = value.Title,
                        Genre = value.Genre,
                        DateOfPublish= value.DateOfPublish,
                    };
                    OnPropertyChanged();
                    (DeleteFilm as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateFilm as RelayCommand).NotifyCanExecuteChanged();
                }
                
            }
        }


        private Actor selectedActor;
        public Actor SelectedActor
        {
            get { return selectedActor; }
            set 
            {
                if (value != null)
                {
                    selectedActor = new Actor()
                    {
                        ActorId = value.ActorId,
                        Name = value.Name,
                        Age = value.Age,
                        Awards = value.Awards
                    };
                    OnPropertyChanged();
                    (DeleteActor as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateActor as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private Director selectedDirector;
        public Director SelectedDirector
        {
            get { return selectedDirector; }
            set 
            {
                if (value != null)
                {
                    selectedDirector = new Director()
                    {
                        DirectorId = value.DirectorId,
                        Name = value.Name,
                        Age = value.Age,
                        Award = value.Award
                    };
                    OnPropertyChanged();
                    (DeleteDirector as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateDirector as RelayCommand).NotifyCanExecuteChanged();
                }
                
            }
        }




        public ICommand CreateFilm { get; set; }
        public ICommand UpdateFilm { get; set; }
        public ICommand DeleteFilm { get; set; }
        public ICommand CreateActor { get; set; }
        public ICommand UpdateActor { get; set; }
        public ICommand DeleteActor { get; set; }
        public ICommand CreateDirector { get; set; }
        public ICommand UpdateDirector { get; set; }
        public ICommand DeleteDirector { get; set; }



        public MainWindowViewModel()
        {
            RestActors = new RestCollection<Actor>("http://localhost:4472/", "actor", "hub");
            RestDirectors = new RestCollection<Director>("http://localhost:4472/", "director", "hub");
            RestFilms = new RestCollection<Film>("http://localhost:4472/", "film", "hub");

            CreateFilm = new RelayCommand(
                () => RestFilms.Add(new Film()
                {
                    Title = SelectedFilm.Title,
                    DateOfPublish = SelectedFilm.DateOfPublish,
                    Genre = SelectedFilm.Genre,
                    ActorId = SelectedFilm.ActorId,
                    DirectorId = SelectedFilm.DirectorId,
                })
                );
            CreateActor = new RelayCommand(
                () => RestActors.Add(new Actor()
                {
                    Name = SelectedActor.Name,
                    Age = SelectedActor.Age,
                    Awards = SelectedActor.Awards,
                })
                );
            CreateDirector = new RelayCommand(
                () => RestDirectors.Add(new Director()
                {
                    Name = SelectedDirector.Name,
                    Age = SelectedDirector.Age,
                    Award = SelectedDirector.Award
                })
                );

            UpdateFilm = new RelayCommand(
                () => RestFilms.Update(SelectedFilm),
                () => SelectedFilm != null
                );
            UpdateActor = new RelayCommand(
                () => RestActors.Update(SelectedActor),
                () => SelectedActor != null
                );
            UpdateDirector = new RelayCommand(
                () => RestDirectors.Update(SelectedDirector),
                () => SelectedDirector != null
                );


            DeleteFilm = new RelayCommand(
                () => RestFilms.Delete(SelectedFilm.FilmId),
                () => SelectedFilm != null
                );
            DeleteActor = new RelayCommand(
                () => RestActors.Delete(SelectedActor.ActorId),
                () => SelectedActor != null
                );
            DeleteDirector = new RelayCommand(
                () => RestDirectors.Delete(SelectedDirector.DirectorId),
                () => SelectedDirector != null
                );
        }
    }
}
