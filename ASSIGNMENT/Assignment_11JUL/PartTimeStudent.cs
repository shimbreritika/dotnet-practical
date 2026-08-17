class PartTimeStudent : Student
{
    public override double CalculateFee()
    {
        return TotalCredits() * 800;
    }
}