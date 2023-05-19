using AutoFixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Non_database_Project.Controllers;
using Non_database_Project.Model;
using Non_database_Project.Repolayer;

namespace UnitTest
{
    public class ControllerTest
    {

        public Fixture _fixture;
        public Mock<ICricketerRepo> _cricketServiceMock;
        public CricketController _sut;
        [SetUp]
        public void TestInitialize()
        {
            _fixture = new Fixture();
            _cricketServiceMock = new Mock<ICricketerRepo>();

            _sut = new CricketController(_cricketServiceMock.Object);
        }
        [Test]
        public void GetId_Call_Repo_Layer_Once()
        {
            var cricketTeams = _fixture.Create<CricketTeam>();
            int id = 1;
            //var cricketTeams = new CricketTeam
            //{
            //    Playerage = 1,
            //    Jerseyname = "sanjeev",
            //    Jerseynumber = 23,
            //    Average = 80
            //};
            _cricketServiceMock.Setup(x => x.Get(id)).Returns(cricketTeams);

            var result = _sut.GetId(id);

            _cricketServiceMock.Verify(x => x.Get(id), Times.Once);
        }

        [Test]
        public void GetId_Call_Repo_Layer_404_NotFound()
        {
            var cricketTeams = _fixture.Create<CricketTeam>();
            int id = 1;

            _cricketServiceMock.Setup(x => x.Get(id)).Returns((CricketTeam)null);

            var result = _sut.GetId(id);

            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.As<NotFoundResult>().StatusCode.Should().Be(StatusCodes.Status404NotFound);
            };
        }

        [Test]
        public void GetId_Call_Repo_Layer_200_ok()
        {
            int id = 3;
            var cricketTeams = _fixture.Create<CricketTeam>();
            _cricketServiceMock.Setup(x => x.Get(id)).Returns(cricketTeams);
            var result = _sut.GetId(id);
            using (new AssertionScope())
            {
                result.As<OkObjectResult>().StatusCode.Should().Be(StatusCodes.Status200OK);
            }
        }

        [Test]
        public void GetId_IsNull()
        {
            int id = 0;
            var cricketTeams = _fixture.Create<CricketTeam>();
            _cricketServiceMock.Setup(x => x.Get(id)).Returns(cricketTeams);
            var result = _sut.GetId(id);
            using (new AssertionScope())
            {
                result.As<NotFoundResult>().StatusCode.Should().Be(StatusCodes.Status404NotFound);
            }
        }
        [Test]
        public void Insert_Call_Repo_Layer_200_ok()
        {
            var cricketTeams = _fixture.Create<CricketTeam>();

            _cricketServiceMock.Setup(x => x.Add(cricketTeams)).Returns(cricketTeams);

            var result = _sut.Insert(cricketTeams);
            var okbject = result.As<OkObjectResult>();
            using (new AssertionScope())
            {
                okbject.StatusCode.Should().Be(StatusCodes.Status200OK);
                okbject.Value.Should().BeOfType<CricketTeam>();
            }
        }

        [Test]
        public void Insert_IsNull()
        {
            var id = _fixture.Create<int>();
            var cricketTeams = _fixture.Create<CricketTeam>();
            _cricketServiceMock.Setup(x => x.Add(cricketTeams)).Returns((CricketTeam)null);
            var result = _sut.Insert(cricketTeams);
            using (new AssertionScope())
            {
                result.As<NotFoundResult>().StatusCode.Should().Be(StatusCodes.Status404NotFound);
            }
        }

        [Test]
        public void Insert_Call_service_Layer_Once()
        {
            var id = _fixture.Create<int>();
            var cricketTeams = _fixture.Create<CricketTeam>();
            _cricketServiceMock.Setup(x => x.Add(cricketTeams)).Returns((CricketTeam)null);
            var result = _sut.Insert(cricketTeams);
            _cricketServiceMock.Verify(x => x.Add(cricketTeams), Times.Once);
        }


        [Test]
        public void Remove_Return_200_ok()
        {
            var id = _fixture.Create<int>();
            var cricketTeams = _fixture.Create<CricketTeam>();
            _cricketServiceMock.Setup(x => x.Remove(id));
            var result = _sut.Remove(id) as OkResult;
            using(new AssertionScope())
            {
                result.StatusCode.Should().Be(StatusCodes.Status200OK);
            }
        }

        [Test]
        public void Remove_Call_service_Layer_Once()
        {
            var id = _fixture.Create<int>();
            var cricketTeams = _fixture.Create<CricketTeam>();
            _cricketServiceMock.Setup(x => x.Remove(id));
            var result = _sut.Remove(id);
            _cricketServiceMock.Verify(x=>x.Remove(id), Times.Once);
        }

        [Test]
        public void Update_Call_service_Layer_Once()
        {
            var id = _fixture.Create<int>();
            var cricketTeams = _fixture.Create<CricketTeam>();
            _cricketServiceMock.Setup(x => x.Update(cricketTeams)).Returns(true);
            var result = _sut.Update(cricketTeams);
            _cricketServiceMock.Verify(x => x.Update(cricketTeams), Times.Once);
        }

        [Test]
        public void Update_Return_200_ok()
        {
            var id = _fixture.Create<int>();
            var cricketTeams = _fixture.Create<CricketTeam>();
            _cricketServiceMock.Setup(x => x.Update(cricketTeams)).Returns(true);
            var result = _sut.Update(cricketTeams) as OkObjectResult;

            using (new AssertionScope())
            {
                result.StatusCode.Should().Be(StatusCodes.Status200OK);
            }
        }

        [Test]
        public void GetAll_Call_Repo_Layer_Once()
        {
            // var cricketTeams = _fixture.Create<CricketTeam>();
            var cricketTeams = new List<CricketTeam>()
            {
                new CricketTeam
                {
                Playerage = 1,
                Jerseyname = "sanjeev",
                Jerseynumber = 23,
                Average = 80
                }
            };
            _cricketServiceMock.Setup(x => x.GetAll()).Returns(cricketTeams);

            var result = _sut.GetAll();

            _cricketServiceMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void GetAll_Call_Repo_Layer_200_ok()
        {
            var cricketTeams = new List<CricketTeam>()
            {
                new CricketTeam
                {
                Playerage = 1,
                Jerseyname = "sanjeev",
                Jerseynumber = 23,
                Average = 80
                }
            };
            _cricketServiceMock.Setup(x => x.GetAll()).Returns(cricketTeams);
            var result = _sut.GetAll();
            using (new AssertionScope())
            {
                result.As<OkObjectResult>().StatusCode.Should().Be(StatusCodes.Status200OK);
            }
        }

    }
}

