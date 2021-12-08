using HBSJ64_HFT_2021221.Logic;
using HBSJ64_HFT_2021221.Models;
using HBSJ64_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HBSJ64_HFT_2021221.Test
{
    public class Tester
    {
        FilmLogic fl;
        ActorLogic al;
        DirectorLogic dl;

        [SetUp]
        public void Init()
        {
            Actor fakeActor = new Actor();
            fakeActor.ActorId = 1;
            fakeActor.Name = "Uma Thurman";
            fakeActor.Age = 51;
            fakeActor.Awards = 7;
            Director fakeDirector = new Director();
            fakeDirector.DirectorId = 1;
            fakeDirector.Name = "Quentin Tarantino";
            fakeDirector.Age = 58;
            fakeDirector.Award = 7;

            /////////////////////////////////////////////////////////////

            var mockFilmRepository = new Mock<IFilmRepository>();
            fl = new FilmLogic(mockFilmRepository.Object);
            var films = new List<Film>()
            {
                new Film()
                {
                    FilmId = 1,
                    Title = "Ponyvaregény",
                    Genre = "Gengszter film",
                    DateOfPublish = 1994,
                    Actor = fakeActor,
                    Director = fakeDirector
                },
                new Film()
                {
                    FilmId = 2,
                    Title = "Kill Bill 1.",
                    Genre = "Akcióthriller",
                    DateOfPublish = 2003,
                    Actor = fakeActor,
                    Director = fakeDirector
                }
            }.AsQueryable();
            mockFilmRepository.Setup((t) => t.GetAll()).Returns(films);
            fl = new FilmLogic(mockFilmRepository.Object);

            /////////////////////////////////////////////////////////////

            var actors = new List<Actor>()
            {
                new Actor()
                {
                    ActorId = fakeActor.ActorId,
                    Name = fakeActor.Name,
                    Age = fakeActor.Age,
                    Awards = fakeActor.Awards,
                    Films = films.ToList()
                }
            }.AsQueryable();
            var mockActorRepository = new Mock<IActorRepository>();
            mockActorRepository.Setup((t) => t.GetAll()).Returns(actors);
            al = new ActorLogic(mockActorRepository.Object);


            /////////////////////////////////////////////////////////////
            
            var directors = new List<Director>()
            {
                new Director()
                {
                    DirectorId = fakeDirector.DirectorId,
                    Name = fakeDirector.Name,
                    Age = fakeDirector.Age,
                    Award = fakeDirector.Award,
                    Films = films.ToList()
                }
            }.AsQueryable();
            var mockDirectorRepository = new Mock<IDirectorRepository>();
            mockDirectorRepository.Setup((t) => t.GetAll()).Returns(directors);
            dl = new DirectorLogic(mockDirectorRepository.Object);

            /////////////////////////////////////////////////////////////
            
        }
        [Test]
        public void FilmActors()
        {
            var res = fl.FilmActors(1);
            var exp = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Ponyvaregény", "Uma Thurman")
            };
            Assert.That(res, Is.EqualTo(exp));
        }
        [Test]
        public void FilmDirector()
        {
            var res = fl.FilmDirectors(2);
            var exp = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Kill Bill 1.", "Quentin Tarantino")
            };
            Assert.That(res, Is.EqualTo(exp));
        }
        [Test]
        public void CountOfDirectedFilms()
        {
            List<int> exp = new List<int>();
            exp.Add(2);
            var res = dl.HowManyFilmDoesHeSheHave(1);
            Assert.That(res, Is.EqualTo(exp));

        }
        [Test]
        public void CountOfFilmWhereActed()
        {
            List<int> exp = new List<int>();
            exp.Add(2);
            var res = al.HowManyFilmDoesHeSheActedOn(1);
            Assert.That(res, Is.EqualTo(exp));
        }
        [Test]
        public void DirectorsGenres()
        {
            var res = dl.GenreOfDirectedFilms(1);
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Ponyvaregény", "Gengszter film"),
                new KeyValuePair<string, string>("Kill Bill 1.", "Akcióthriller")
            };
            Assert.That(res, Is.EqualTo(expected));
        }
        [Test]
        public void CountOfActorAwards()
        {
            List<int> exp = new List<int>();
            exp.Add(7);
            var res = fl.CountOfActorAwards(1);
            Assert.That(res, Is.EqualTo(exp));
        }
        [Test]
        public void CountOfDirectorAwards()
        {
            List<int> exp = new List<int>();
            exp.Add(7);
            var res = fl.CountOfDirectorAwards(1);
            Assert.That(res, Is.EqualTo(exp));
        }
        [Test]
        public void DirectorWorkedWithActor()
        {
            var res = dl.ActorsWorkedWith(1);
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Ponyvaregény", "Uma Thurman"),
                new KeyValuePair<string, string>("Kill Bill 1.", "Uma Thurman")
            };
            Assert.That(res, Is.EqualTo(expected));
        }
        [Test]
        public void ActorWorkedWithDirector()
        {
            var res = al.DirectorsWorkedWith(1);
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Ponyvaregény", "Quentin Tarantino"),
                new KeyValuePair<string, string>("Kill Bill 1.", "Quentin Tarantino")
            };
            Assert.That(res, Is.EqualTo(expected));
        }


        [Test]
        public void ActorCreate()
        {
            Assert.That(() => al.Create(new Actor()
            {
                ActorId = 4,
                Name = null,
                Age = 15,
                Awards = 0
            }), Throws.ArgumentNullException);
        }
        [Test]
        public void DirectorCreate()
        {
            Assert.That(() => dl.Create(new Director()
            {
                DirectorId = 4,
                Name = null,
                Age = 15,
                Award = 5
            }), Throws.ArgumentNullException);
        }
        [Test]
        public void Filmreate()
        {
            Assert.That(() => fl.Create(new Film()
            {
                Title = null,
                Genre = "Sci-fi",
                DateOfPublish = 1994
            }), Throws.ArgumentNullException);
        }
    }
}
