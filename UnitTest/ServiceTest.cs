using AutoFixture;
using Moq;
using Non_database_Project.Controllers;
using Non_database_Project.Model;
using Non_database_Project.Repolayer;
using Non_database_Project.Servicelayer;

namespace UnitTest
{
    public class Tests
    {
        private Fixture _fixture;
        private Mock<ICricketerRepo> _cricketServiceMock;
        private CricketController _sut;
        // private Mock<IMapper> _mapperMock
        [SetUp]
        public void TestInitialize()
        {
            _fixture = new Fixture();
            _cricketServiceMock = new Mock<ICricketerRepo>();
            //_mapperMock = new Mock<IMapper>();

             _sut = new CricketController(_cricketServiceMock.Object);
        }

        [Test]
        public void Call_Repo_Layer()
        {

            // int id = 1;
            var cricketTeams = new CricketTeam
            {
                Playerage = 1,
                Jerseyname = "sanjeev",
                Jerseynumber = 23,
                Average = 80
            };
            _cricketServiceMock.Setup(x => x.Get(2)).Returns(cricketTeams);
            _cricketServiceMock.Verify(x=>x.Get(2),Times.Never);
        }

        [Test]
        public void Insert_Call_Repo_Layer()
        {

            // int id = 1;
            var cricketTeams = new CricketTeam
            {
                Playerage = 1,
                Jerseyname = "sanjeev",
                Jerseynumber = 23,
                Average = 80
            };
            _cricketServiceMock.Setup(x => x.Add(cricketTeams)).Returns(cricketTeams);
            _cricketServiceMock.Verify(x => x.Add(cricketTeams), Times.Never);
        }
    }
}