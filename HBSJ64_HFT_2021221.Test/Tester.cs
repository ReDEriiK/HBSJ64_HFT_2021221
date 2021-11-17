using HBSJ64_HFT_2021221.Logic;
using HBSJ64_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;

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
            var mockFilmRepository = new Mock<IFilmRepository>();


        }
    }
}
