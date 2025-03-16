public class Checklist : Goal
{
    private string _goalType = "checklist";
    private int _timesToComplete;
    private int _timesCompleted;
    private int _bonusPoints;

    public Checklist(string goalName, string goalDescription, int points,
                     int timesToComplete, int bonusPoints)
        :base(goalName, goalDescription, points)
    {
        _timesToComplete = timesToComplete;
        _timesCompleted = 0;
        _bonusPoints = bonusPoints;
    }

    public Checklist(string goalName, string goalDescription, int points, int goalID, string isComplete,
                     int bonusPoints, int timesCompleted, int timesToComplete)
        :base(goalName, goalDescription, points, goalID, isComplete)
    {
        _timesToComplete = timesToComplete;
        _timesCompleted = timesCompleted;
        _bonusPoints = bonusPoints;
    }

    public override string DisplayGoal()
    {
        string baseGoal = base.DisplayGoal();
        return baseGoal + $" -- Currently completed: {_timesCompleted}/{_timesToComplete}";
    }
    public override string SaveGoal()
    {
        return base.SaveGoal() + $"|{_goalType}|{_bonusPoints}|{_timesCompleted}|{_timesToComplete}";
    }
    public override void MarkComplete()
    {
        _timesCompleted += 1;

        if (_timesCompleted >= _timesToComplete)
            base.MarkComplete();
    }
    public override int GetPoints()
    {
        int points = base.GetPoints();

        if (_timesCompleted == _timesToComplete)
        {
            points += _bonusPoints;
            _bonusPoints = 0;
        }
        return points;
    }
}