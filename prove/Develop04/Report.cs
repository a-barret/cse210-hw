public class Report
{
    private string _generationMessage;
    private int _breathingSeconds;
    private int _reflectionSeconds;
    private int _listingSeconds;
    private int _totalSeconds;

    public Report()
    {
        _generationMessage = "Generating your report. Please wait a moment...";
        _breathingSeconds = 0;
        _reflectionSeconds = 0;
        _listingSeconds = 0;
        _totalSeconds = 0;
    }

    public string GetGenerationMessage()
    {
        return _generationMessage;
    }
    public string GetReport()
    {
        return $@" --- Mindfulness Activity Report ---

Breathing Activity: {_breathingSeconds} seconds
Reflection Activty: {_reflectionSeconds} seconds
Listing Activity: {_listingSeconds} seconds

Total Activity: {_totalSeconds} seconds

Great work!

Press ENTER to continue";
    }
    public void SetSeconds(Activity activity)
    {
        switch (activity)
        {
            case BreathingActivity breathingActivity:
                _breathingSeconds += breathingActivity.GetDuration();
                break;
            case ReflectionActivity reflectionActivity:
                _reflectionSeconds += reflectionActivity.GetDuration();
                break;
            case ListingActivity listingActivity:
                _listingSeconds += listingActivity.GetDuration();
                break;
        }
        _totalSeconds += activity.GetDuration();
    }
}