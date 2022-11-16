namespace BowlingGameScore;

public class Game
{
    private readonly int[] _rolls = new int [21];
    private int _currentRoll;

    private bool IsStrike(int frameIndex) => _rolls[frameIndex] == 10;
    private bool IsSpare(int frameIndex) => _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;

    public void Roll(int pins)
    {
        if (pins is < 0 or > 10)
        {
            throw new ArgumentException("Pin value must be between 0 and 10");
        }

        _rolls[_currentRoll++] = pins;
    }

    public void Roll(IEnumerable<int> pins)
    {
        foreach (var pin in pins)
        {
            _rolls[_currentRoll++] = pin;
        }
    }

    public int GetScore()
    {
        var score = 0;
        var frameIndex = 0;
        for (var frame = 0; frame < 10; frame++)
        {
            if (IsStrike(frameIndex))
            {
                score += 10 + _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
                frameIndex++;
            }
            else if (IsSpare(frameIndex))
            {
                score += 10 + _rolls[frameIndex + 2];
                frameIndex += 2;
            }
            else
            {
                score += _rolls[frameIndex] + _rolls[frameIndex + 1];
                frameIndex += 2;
            }
        }

        return score;
    }
}