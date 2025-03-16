public class Goal
{
    private int _goalID;
    private static int _nextID = 1;
    private string _goalName;
    private string _goalDescription;
    private int _points;
    private string _isComplete;

    public Goal(string goalName, string goalDescription, int points)
    {
        _goalID = _nextID;
        _nextID++;
        _goalName = goalName;
        _goalDescription = goalDescription;
        _points = points;
        _isComplete = "[ ]"; // [ ] means false. [X] means true.
    }

    public Goal(string goalName, string goalDescription, int points, int goalID, string isComplete)
    {
        _goalID = goalID;
        if (_nextID <= _goalID) {
            _nextID = _goalID + 1;
        }
        _goalName = goalName;
        _goalDescription = goalDescription;
        _points = points;
        _isComplete = isComplete;
    }

    public virtual string DisplayGoal()
    {
        return $"{_goalID}. {_isComplete} {_goalName} ({_goalDescription})";
    }
    public virtual string SaveGoal()
    {
        return $"{_goalName}|{_goalDescription}|{_points}|{_goalID}|{_isComplete}";
    }
    public int GetID()
    {
        return _goalID;
    }
    public string GetName()
    {
        return $"{_goalID}. {_goalName}";
    }
    public virtual void MarkComplete()
    {
        _isComplete = "[X]";
    }
    public virtual int GetPoints()
    {
        return _points;
    }
}