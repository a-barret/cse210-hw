public class BreathingActivity : Activity
{
    private int _breathDuration;
    private bool _onBreathIn;
    private string _breathInMessage;
    private string _breathOutMessage;

    public BreathingActivity() 
    {
        _breathDuration = 5;
        _onBreathIn = true;
        _breathInMessage = "\nBreath in...";
        _breathOutMessage = "Breath out...";

        base._type = "Breathing Activity";
        base._introduction = @"Welcome to the Breathing Activity!

This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.

";
    }

    public int GetBreathDuration()
    {
        return _breathDuration;
    }
    public string GetBreathMessage()
    {
        if (_onBreathIn) {
            _onBreathIn = false;
            return _breathInMessage;
        } else {
            _onBreathIn = true;
            return _breathOutMessage;
        }
    }
}