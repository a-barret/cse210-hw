public class Eternal : Goal
{
    string _goalType = "eternal";

    public Eternal(string goalName, string goalDescription, int points)
        :base(goalName, goalDescription, points) {}
    public Eternal(string goalName, string goalDescription, int points, int goalID, string isComplete)
        :base(goalName, goalDescription, points, goalID, isComplete) {}

    public override void MarkComplete() {}
    public override string SaveGoal()
    {
        return base.SaveGoal() + $"|{_goalType}";
    }
}