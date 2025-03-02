public class Activity
{
    protected string _type;
    protected string _introduction;
    private int _duration;
    private string _prepMessage;
    private string _completeMessage;
    private string _exitMessage;
    private int _pauseLength;

    public Activity()
    {
        _prepMessage = "Get ready...";
        _completeMessage = "\nWell done!";
        _pauseLength = 5;
    }

    public string GetIntroduction()
    {
        return _introduction + "How long (in seconds) would you like to do this activity? ";
    }
    public int GetDuration()
    {
        return _duration;
    }
    public void SetDuration(int duration)
    {
        _duration = duration;
        SetExitMessage($"You have completed another {_duration} seconds of the {_type}.");
    }
    public string GetPrepMessage()
    {
        return _prepMessage;
    }
    public string GetCompleteMessage()
    {
        return _completeMessage;
    }
    public void SetExitMessage(string exitMessage)
    {
        _exitMessage = exitMessage;
    }
    public string GetExitMessage()
    {
        return _exitMessage;
    }
    public int GetPauseLength()
    {
        return _pauseLength;
    }
}