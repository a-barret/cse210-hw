public class Checklist : Goal
{
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

    public override string DisplayGoal()
    {
        string baseGoal = base.DisplayGoal();
        return baseGoal + $" -- Currently completed: {_timesCompleted}/{_timesToComplete}";
    }
    public override void MarkComplete()
    {
        _timesCompleted += 1;

        if (_timesCompleted >= _timesToComplete)
            base.MarkComplete();
    }
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
}