using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Labs.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.FinalControl;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class SubjectTests
{
    [Fact]
    public void Name_ShouldReturnResultOfUpdate_WhenNotAuthor()
    {
        // Arrange
        Subject? subject = Create();

        // Act
        var repo = new UniversalRepository<IEducationalObject>();
        var user2 = new SingleUser(repo.GenerateId() + 1, "Bob");
        if (subject != null)
        {
            UpdateResult result = subject.UpdateName(user2, "qwertqchnhufnhun");

            // Assert
            Assert.IsType<UpdateResult.Failure>(result);
        }
    }

    [Fact]
    public void SetSubject_ShouldReturnSubject_WithParentId()
    {
        // Arrange
        var repo = new UniversalRepository<IEducationalObject>();
        Subject? subject = Create();

        // Act
        if (subject != null)
        {
            Subject subject2 = subject.Inherit(repo.GenerateId());

            // Assert
            Assert.Equal(subject2.ParentId, subject.Id);
        }
    }

    [Fact]
    public void Build_ShouldReturnError_WhenTotalPointsIsNotCorrect()
    {
        // Arrange
        var repo = new UniversalRepository<IEducationalObject>();
        var user = new SingleUser(repo.GenerateId(), "Bob");
        var labWorkBuilder = new LabWorkBuilder();
        labWorkBuilder.SetName("L1")
            .SetId(repo.GenerateId())
            .SetBalls(45)
            .SetDescription("This is a test")
            .SetCriteria("This is a criteria")
            .SetAuthor(user);
        LabWork labWork1 = labWorkBuilder.Build();
        LabWork labWork2 = labWork1.Inherit(repo.GenerateId());

        var lectureBuilder = new LectureBuilder();
        lectureBuilder.SetName("L1")
            .SetId(repo.GenerateId())
            .SetDescription("Math")
            .SetContent("dcfvgtbyh,kol")
            .SetAuthor(user);
        Lecture lecture = lectureBuilder.Build();

        var subjectBuilder = new SubjectBuilder();
        subjectBuilder.SetName("Math")
            .SetId(repo.GenerateId())
            .AddLab(labWork1)
            .AddLab(labWork2)
            .AddLecture(lecture)
            .SetVerification(new Exam(20))
            .SetAuthor(user);

        // Act
        SubjectBuildResult subjectres = subjectBuilder.Build();

        // Assert
        Assert.IsType<SubjectBuildResult.Failure>(subjectres);
    }

    private Subject? Create()
    {
        var repo = new UniversalRepository<IEducationalObject>();
        var user = new SingleUser(repo.GenerateId(), "Bob");
        var labWorkBuilder = new LabWorkBuilder();
        labWorkBuilder.SetName("L1")
            .SetId(repo.GenerateId())
            .SetBalls(40)
            .SetDescription("This is a test")
            .SetCriteria("This is a criteria")
            .SetAuthor(user);
        LabWork labWork1 = labWorkBuilder.Build();
        LabWork labWork2 = labWork1.Inherit(1337);

        var lectureBuilder = new LectureBuilder();
        lectureBuilder.SetName("L1")
            .SetId(123)
            .SetDescription("Math")
            .SetContent("dcfvgtbyh,kol")
            .SetAuthor(user);
        Lecture lecture = lectureBuilder.Build();

        var subjectBuilder = new SubjectBuilder();
        subjectBuilder.SetName("Math")
            .SetId(123)
            .AddLab(labWork1)
            .AddLab(labWork2)
            .AddLecture(lecture)
            .SetVerification(new Exam(20))
            .SetAuthor(user);
        SubjectBuildResult subjectres = subjectBuilder.Build();
        Subject? subject = null;
        if (subjectres is SubjectBuildResult.Success success) subject = success.Subject;

        return subject;
    }
}