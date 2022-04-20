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

        public RestCollection<Actor> Actors { get; set; }
        public RestCollection<Director> Directors { get; set; }
        public RestCollection<Film> Films { get; set; }


        private Film selectedFilm;
        public Film SelectedFilm
        {
            get { return selectedFilm; }
            set 
            { 
                SetProperty(ref selectedFilm, value);
                (DeleteFilm as RelayCommand).NotifyCanExecuteChanged();
                (UpdateFilm as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        private Actor selectedActor;
        public Actor SelectedActor
        {
            get { return selectedActor; }
            set 
            { 
                SetProperty(ref selectedActor, value);
                (DeleteActor as RelayCommand).NotifyCanExecuteChanged();
                (UpdateActor as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Director selectedDirector;
        public Director SelectedDirector
        {
            get { return selectedDirector; }
            set 
            { 
                SetProperty(ref selectedDirector, value);
                (DeleteDirector as RelayCommand).NotifyCanExecuteChanged();
                (UpdateDirector as RelayCommand).NotifyCanExecuteChanged();
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
            Actors = new RestCollection<Actor>("http://localhost:4472/", "actor");
            Directors = new RestCollection<Director>("http://localhost:4472/", "director");
            Films = new RestCollection<Film>("http://localhost:4472/", "film");

            CreateFilm = new RelayCommand(
                () => Films.Add(new Film())
                );
            CreateActor = new RelayCommand(
                () => Actors.Add(new Actor())
                );
            CreateDirector = new RelayCommand(
                () => Directors.Add(new Director())
                );

            UpdateFilm = new RelayCommand(
                () => Films.Add(new Film()),
                () => SelectedFilm != null
                );
            UpdateActor = new RelayCommand(
                () => Actors.Add(new Actor()),
                () => SelectedActor != null
                );
            UpdateDirector = new RelayCommand(
                () => Directors.Add(new Director()),
                () => SelectedDirector != null
                );


            DeleteFilm = new RelayCommand(
                () => Films.Delete(SelectedFilm.FilmId),
                () => SelectedFilm != null
                );
            DeleteActor = new RelayCommand(
                () => Actors.Delete(SelectedActor.ActorId),
                () => SelectedActor != null
                );
            DeleteDirector = new RelayCommand(
                () => Directors.Delete(SelectedDirector.DirectorId),
                () => SelectedDirector != null
                );
        }
    }
}
