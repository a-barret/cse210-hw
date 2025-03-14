public class Goal
{
    private string _goalName;
    private string _goalDescription;
    private int _points;
    private string _isComplete;

    public Goal(string goalName, string goalDescription, int points)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _points = points;
        _isComplete = "[ ]"; // [ ] means false. [X] means true.
    }

    public virtual string DisplayGoal()
    {
        return $" {_isComplete} {_goalName} ({_goalDescription})";
    }
    public virtual void MarkComplete()
    {
        _isComplete = "[X]";
    }
    public int GetPoints()
    {
        return _points;
    }
}