class ScholarshipStudent : Student
{
    public override double CalculateFee()
    {
        return TotalCredits() * 500;
    }
}