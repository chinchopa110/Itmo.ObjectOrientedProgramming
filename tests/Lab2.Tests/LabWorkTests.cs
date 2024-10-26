using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Labs.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class LabWorkTests
{
    [Fact]
    public void UpdateName_ShouldReturnResultOfUpdate_WhenNotAuthor()
    {
        // Arrange
        var repo = new UniversalRepository<IEducationalObject>();
        var user = new SingleUser(repo.GenerateId(), "Bob");
        var labWorkBuilder = new LabWorkBuilder();
        labWorkBuilder.SetName("L1")
            .SetId(repo.GenerateId())
            .SetBalls(10)
            .SetDescription("This is a test")
            .SetCriteria("This is a criteria")
            .SetAuthor(user);
        LabWork labWork = labWorkBuilder.Build();

        // Act
        var user2 = new SingleUser(repo.GenerateId(), "Tom");
        UpdateResult result = labWork.UpdateName(user2, "qwert");

        // Assert
        Assert.IsType<UpdateResult.Failure>(result);
    }

    [Fact]
    public void UpdateDescription_ShouldReturnResultOfUpdate_WhenNotAuthor()
    {
        // Arrange
        var repo = new UniversalRepository<IEducationalObject>();
        var user = new SingleUser(repo.GenerateId(), "Bob");
        var labWorkBuilder = new LabWorkBuilder();
        labWorkBuilder.SetName("L1")
            .SetId(repo.GenerateId())
            .SetBalls(10)
            .SetDescription("This is a test")
            .SetCriteria("This is a criteria")
            .SetAuthor(user);
        LabWork labWork = labWorkBuilder.Build();

        // Act
        var user2 = new SingleUser(repo.GenerateId(), "Tom");
        UpdateResult result = labWork.UpdateDescription(user2, "qwertqchnhufnhun");

        // Assert
        Assert.IsType<UpdateResult.Failure>(result);
    }

    [Fact]
    public void UpdateCriteria_ShouldReturnResultOfUpdate_WhenNotAuthor()
    {
        // Arrange
        var repo = new UniversalRepository<IEducationalObject>();
        var user = new SingleUser(repo.GenerateId(), "Bob");
        var labWorkBuilder = new LabWorkBuilder();
        labWorkBuilder.SetName("L1")
            .SetId(repo.GenerateId())
            .SetBalls(10)
            .SetDescription("This is a test")
            .SetCriteria("This is a criteria")
            .SetAuthor(user);
        LabWork labWork = labWorkBuilder.Build();

        // Act
        var user2 = new SingleUser(repo.GenerateId(), "Tom");
        UpdateResult result = labWork.UpdateCriteria(user2, "qwertqchnhufnhun");

        // Assert
        Assert.IsType<UpdateResult.Failure>(result);
    }

    [Fact]
    public void SetLabWork_ShouldReturnNewLab_WithParentId()
    {
        // Arrange
        var repo = new UniversalRepository<IEducationalObject>();
        var user = new SingleUser(repo.GenerateId(), "Bob");
        var labWorkBuilder = new LabWorkBuilder();
        labWorkBuilder.SetName("L1")
            .SetId(repo.GenerateId())
            .SetBalls(10)
            .SetDescription("This is a test")
            .SetCriteria("This is a criteria")
            .SetAuthor(user);
        LabWork labWork = labWorkBuilder.Build();

        // Act
        LabWork labWork2 = labWork.Inherit(repo.GenerateId());

        // Assert
        Assert.Equal(labWork.Id, labWork2.ParentId);
    }
}