using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class LectureTests
{
    [Fact]
    public void UpdateName_ShouldReturnResultOfUpdate_WhenNotAuthor()
    {
        // Arrange
        var user = new SingleUser("Bob", 1111);
        var lectureBuilder = new LectureBuilder();
        lectureBuilder.SetName("L1")
            .SetId(123)
            .SetDescription("Math")
            .SetContent("dcfvgtbyh,kol")
            .SetAuthor(user);
        Lecture lecture = lectureBuilder.Build();

        // Act
        var user2 = new SingleUser("Tom", 2222);
        UpdateResult result = lecture.UpdateName(user2, "qwert");

        // Assert
        Assert.IsType<UpdateResult.Failure>(result);
    }

    [Fact]
    public void UpdateDescription_ShouldReturnResultOfUpdate_WhenNotAuthor()
    {
        // Arrange
        var user = new SingleUser("Bob", 1111);
        var lectureBuilder = new LectureBuilder();
        lectureBuilder.SetName("L1")
            .SetId(123)
            .SetDescription("Math")
            .SetContent("dcfvgtbyh,kol")
            .SetAuthor(user);
        Lecture lecture = lectureBuilder.Build();

        // Act
        var user2 = new SingleUser("Tom", 2222);
        UpdateResult result = lecture.UpdateDescription(user2, "qwert");

        // Assert
        Assert.IsType<UpdateResult.Failure>(result);
    }

    [Fact]
    public void UpdateСontent_ShouldReturnResultOfUpdate_WhenNotAuthor()
    {
        // Arrange
        var user = new SingleUser("Bob", 1111);
        var lectureBuilder = new LectureBuilder();
        lectureBuilder.SetName("L1")
            .SetId(123)
            .SetDescription("Math")
            .SetContent("dcfvgtbyh,kol")
            .SetAuthor(user);
        Lecture lecture = lectureBuilder.Build();

        // Act
        var user2 = new SingleUser("Tom", 2222);
        UpdateResult result = lecture.UpdateContent(user2, "qwert");

        // Assert
        Assert.IsType<UpdateResult.Failure>(result);
    }

    [Fact]
    public void SetLecture_ShouldReturnNewLecture_WithParentId()
    {
        // Arrange
        var user = new SingleUser("Bob", 1111);
        var lectureBuilder = new LectureBuilder();
        lectureBuilder.SetName("L1")
            .SetId(123)
            .SetDescription("Math")
            .SetContent("dcfvgtbyh,kol")
            .SetAuthor(user);
        Lecture lecture = lectureBuilder.Build();

        // Act
        Lecture lecture2 = lecture.Inherit(228);

        // Assert
        Assert.Equal(lecture.Id, lecture2.ParentId);
    }
}