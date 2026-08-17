class RegularStudent : Student
{
    public override double CalculateFee()
    {
        return TotalCredits() * 1000;
    }
}