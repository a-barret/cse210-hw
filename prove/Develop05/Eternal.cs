public class Eternal : Goal
{
    public Eternal(string goalName, string goalDescription, int points)
        :base(goalName, goalDescription, points) {}

    public override void MarkComplete() {}
}