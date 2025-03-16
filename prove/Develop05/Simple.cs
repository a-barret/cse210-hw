public class Simple : Goal
{
    string _goalType = "simple";

    public Simple(string goalName, string goalDescription, int points)
        :base(goalName, goalDescription, points) {}
    public Simple(string goalName, string goalDescription, int points, int goalID, string isComplete)
        :base(goalName, goalDescription, points, goalID, isComplete) {}

    public override string SaveGoal()
    {
        return base.SaveGoal() + $"|{_goalType}";
    }
}