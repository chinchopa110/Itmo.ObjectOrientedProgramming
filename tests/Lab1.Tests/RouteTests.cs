using Itmo.ObjectOrientedProgramming.Lab1.Path;
using Itmo.ObjectOrientedProgramming.Lab1.Processing;
using Itmo.ObjectOrientedProgramming.Lab1.TrackSection;
using Itmo.ObjectOrientedProgramming.Lab1.Transport;
using Xunit;

namespace Lab1.Tests;

public class RouteTests
{
    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationOne()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMp(150, 400);
        var conventionalMp = new ConventionalMp(100);
        ResultTypes expresult = new ResultTypes.Success();

        var route = new Route(train, 20, acceleratingMp, conventionalMp);

        ResultTypes result = route.Passing();

        Assert.Equal(expresult, result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationTwo()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMp(150, 800);
        var conventionalMp = new ConventionalMp(100);
        ResultTypes expresult = new ResultTypes.FailureBigSpeed();

        var route = new Route(train, 20, acceleratingMp, conventionalMp);

        ResultTypes result = route.Passing();

        Assert.Equal(expresult, result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationThree()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMp(150, 400);
        var station = new Station(15, 20);
        var conventionalMp = new ConventionalMp(100);
        ResultTypes expresult = new ResultTypes.Success();

        var route = new Route(train, 30, acceleratingMp, conventionalMp, station, conventionalMp);

        ResultTypes result = route.Passing();

        Assert.Equal(expresult, result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationFour()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMp(350, 400);
        var station = new Station(15, 20);
        var conventionalMp = new ConventionalMp(100);
        ResultTypes expresult = new ResultTypes.FailurePass();

        var route = new Route(train, 100, acceleratingMp, station, conventionalMp);

        ResultTypes result = route.Passing();

        Assert.Equal(expresult, result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationFive()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp = new AcceleratingMp(150, 400);
        var station = new Station(15, 30);
        var conventionalMp = new ConventionalMp(100);
        ResultTypes expresult = new ResultTypes.FailureBigSpeed();

        var route = new Route(train, 16, acceleratingMp, conventionalMp, station, conventionalMp);

        ResultTypes result = route.Passing();

        Assert.Equal(expresult, result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationSix()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp1 = new AcceleratingMp(150, 800);
        var conventionalMp = new ConventionalMp(100);
        var acceleratingMp2 = new AcceleratingMp(150, -600);
        var station = new Station(15, 30);
        ResultTypes expresult = new ResultTypes.Success();

        var route = new Route(
            train,
            30,
            acceleratingMp1,
            conventionalMp,
            acceleratingMp2,
            station,
            conventionalMp,
            acceleratingMp1,
            conventionalMp,
            acceleratingMp2);

        ResultTypes result = route.Passing();

        Assert.Equal(expresult, result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationSeven()
    {
        var train = new Train(400, 1000, 1);
        var conventionalMp = new ConventionalMp(100);
        ResultTypes expresult = new ResultTypes.FailurePass();

        var route = new Route(train, 20, conventionalMp);

        ResultTypes result = route.Passing();

        Assert.Equal(expresult, result);
    }

    [Fact]
    public void Passing_ShouldReturnTrainPassResult_WhenSituationEight()
    {
        var train = new Train(400, 1000, 1);
        var acceleratingMp1 = new AcceleratingMp(150, 100);
        var acceleratingMp2 = new AcceleratingMp(150, -200);
        ResultTypes expresult = new ResultTypes.FailurePass();

        var route = new Route(train, 20, acceleratingMp1, acceleratingMp2);

        ResultTypes result = route.Passing();

        Assert.Equal(expresult, result);
    }
}