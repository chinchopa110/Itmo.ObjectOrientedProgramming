namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgramRepository
{
    private readonly List<EducationalProgram> _educationalPrograms;

    public EducationalProgramRepository()
    {
        _educationalPrograms = new List<EducationalProgram>();
    }

    public EducationalProgram? GetIt(int educationalprogramId)
    {
        EducationalProgram? res =
            _educationalPrograms.FirstOrDefault(educationalprogram => educationalprogram.Id == educationalprogramId);
        if (res != null) _educationalPrograms.Remove(res);
        return res;
    }

    public void Add(EducationalProgram educationalprogram)
    {
        _educationalPrograms.Add(educationalprogram);
    }
}