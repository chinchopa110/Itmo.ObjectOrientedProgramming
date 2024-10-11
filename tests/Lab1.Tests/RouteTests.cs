using Itmo.ObjectOrientedProgramming.Lab1.Path;
using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using System.Collections.Immutable;
using Xunit;

namespace Lab1.Tests;

public class RouteTests
{
    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationOne()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMagneticPath(150, 400);
        var conventionalMp = new ConventionalMagneticPath(100);
        var sections = ImmutableArray.Create<ISection>(acceleratingMp, conventionalMp);

        var route = new Route(20, sections);

        Result result = route.Pass(train);

        Assert.True(result is Result.Success);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationTwo()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMagneticPath(150, 800);
        var conventionalMp = new ConventionalMagneticPath(100);
        var sections = ImmutableArray.Create<ISection>(acceleratingMp, conventionalMp);

        var route = new Route(20, sections);

        Result result = route.Pass(train);

        Assert.True(result is Result.Failure);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationThree()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMagneticPath(150, 400);
        var station = new Station(15, 20);
        var conventionalMp = new ConventionalMagneticPath(100);
        var sections = ImmutableArray.Create<ISection>(acceleratingMp, station, conventionalMp);

        var route = new Route(20, sections);

        Result result = route.Pass(train);

        Assert.True(result is Result.Success);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationFour()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMagneticPath(350, 400);
        var station = new Station(15, 20);
        var conventionalMp = new ConventionalMagneticPath(100);
        var sections = ImmutableArray.Create<ISection>(acceleratingMp, station, conventionalMp);

        var route = new Route(20, sections);

        Result result = route.Pass(train);

        Assert.True(result is Result.Failure);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationFive()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMagneticPath(150, 400);
        var station = new Station(15, 17);
        var conventionalMp = new ConventionalMagneticPath(100);
        var sections =
            ImmutableArray.Create<ISection>(acceleratingMp, conventionalMp, station, conventionalMp);

        var route = new Route(16, sections);

        Result result = route.Pass(train);

        Assert.True(result is Result.Failure);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationSix()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp1 = new AcceleratingMagneticPath(150, 800);
        var conventionalMp = new ConventionalMagneticPath(100);
        var acceleratingMp2 = new AcceleratingMagneticPath(150, -600);
        var station = new Station(15, 30);

        var sections = ImmutableArray.Create<ISection>(
            acceleratingMp1,
            conventionalMp,
            acceleratingMp2,
            station,
            conventionalMp,
            acceleratingMp1,
            conventionalMp,
            acceleratingMp2);

        var route = new Route(30, sections);

        Result result = route.Pass(train);

        Assert.True(result is Result.Success);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationSeven()
    {
        var train = new Train(400, 1000, 1);
        var conventionalMp = new ConventionalMagneticPath(100);
        var sections = ImmutableArray.Create<ISection>(conventionalMp);

        var route = new Route(20, sections);

        Result result = route.Pass(train);

        Assert.True(result is Result.Failure);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationEight()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp1 = new AcceleratingMagneticPath(150, 100);
        var acceleratingMp2 = new AcceleratingMagneticPath(150, -200);
        var sections = ImmutableArray.Create<ISection>(acceleratingMp1, acceleratingMp2);

        var route = new Route(20, sections);

        Result result = route.Pass(train);

        Assert.True(result is Result.Failure);
    }
}