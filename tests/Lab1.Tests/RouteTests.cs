using Itmo.ObjectOrientedProgramming.Lab1.Path;
using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using Xunit;

namespace Lab1.Tests;

public class RouteTests
{
    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationOne()
    {
        // arrange
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMagneticPath(150, 400);
        var conventionalMp = new ConventionalMagneticPath(100);

        var sections = new List<ISection> { acceleratingMp, conventionalMp };
        var route = new Route(20, sections);

        // act
        TheResultOfThePassageRoute result = route.Pass(train);

        // assert
        Assert.IsType<TheResultOfThePassageRoute.Success>(result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationTwo()
    {
        // arrange
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMagneticPath(150, 800);
        var conventionalMp = new ConventionalMagneticPath(100);

        var sections = new List<ISection> { acceleratingMp, conventionalMp };

        var route = new Route(20, sections);

        // act
        TheResultOfThePassageRoute result = route.Pass(train);

        // assert
        Assert.IsType<TheResultOfThePassageRoute.Failure>(result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationThree()
    {
        // arrange
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMagneticPath(150, 400);
        var station = new Station(15, 30);
        var conventionalMp = new ConventionalMagneticPath(100);
        var sections = new List<ISection> { acceleratingMp, station, conventionalMp };

        var route = new Route(30, sections);

        // act
        TheResultOfThePassageRoute result = route.Pass(train);

        // assert
        Assert.IsType<TheResultOfThePassageRoute.Success>(result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationFour()
    {
        // arrange
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMagneticPath(350, 400);
        var station = new Station(15, 20);
        var conventionalMp = new ConventionalMagneticPath(100);

        var sections = new List<ISection> { acceleratingMp, station, conventionalMp };

        var route = new Route(20, sections);

        // act
        TheResultOfThePassageRoute result = route.Pass(train);

        // assert
        Assert.IsType<TheResultOfThePassageRoute.Failure>(result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationFive()
    {
        // arrange
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMagneticPath(150, 400);
        var station = new Station(15, 17);
        var conventionalMp = new ConventionalMagneticPath(100);
        var sections = new List<ISection> { acceleratingMp, conventionalMp, station, conventionalMp };

        var route = new Route(16, sections);

        // act
        TheResultOfThePassageRoute result = route.Pass(train);

        // assert
        Assert.IsType<TheResultOfThePassageRoute.Failure>(result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationSix()
    {
        // arrange
        var train = new Train(400, 1000, 1);
        var acceleratingMp1 = new AcceleratingMagneticPath(150, 800);
        var conventionalMp = new ConventionalMagneticPath(100);
        var acceleratingMp2 = new AcceleratingMagneticPath(150, -600);
        var station = new Station(15, 30);

        var sections = new List<ISection>
        {
            acceleratingMp1,
            conventionalMp,
            acceleratingMp2,
            station,
            conventionalMp,
            acceleratingMp1,
            conventionalMp,
            acceleratingMp2,
        };

        var route = new Route(30, sections);

        // act
        TheResultOfThePassageRoute result = route.Pass(train);

        // assert
        Assert.IsType<TheResultOfThePassageRoute.Success>(result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationSeven()
    {
        // arrange
        var train = new Train(400, 1000, 1);
        var conventionalMp = new ConventionalMagneticPath(100);
        var sections = new List<ISection> { conventionalMp };

        var route = new Route(20, sections);

        // act
        TheResultOfThePassageRoute result = route.Pass(train);

        // assert
        Assert.IsType<TheResultOfThePassageRoute.Failure>(result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationEight()
    {
        // arrange
        var train = new Train(400, 1000, 1);
        var acceleratingMp1 = new AcceleratingMagneticPath(150, 100);
        var acceleratingMp2 = new AcceleratingMagneticPath(150, -200);
        var sections = new List<ISection> { acceleratingMp1, acceleratingMp2 };

        var route = new Route(20, sections);

        // act
        TheResultOfThePassageRoute result = route.Pass(train);

        // assert
        Assert.IsType<TheResultOfThePassageRoute.Failure>(result);
    }
}