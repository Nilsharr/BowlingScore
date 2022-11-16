using BowlingGameScore;

namespace BowlingGameScoreTests;

public class GameTests
{
    private readonly Game _game;

    private void RollMany(int rolls, int pins)
    {
        for (var i = 0; i < rolls; i++)
        {
            _game.Roll(pins);
        }
    }

    public GameTests()
    {
        // Arrange
        _game = new Game();
    }

    [Fact]
    public void Roll_ValidPins_ShouldAdd()
    {
        // Act
        const int expectedScore = 7;
        _game.Roll(7);

        // Assert
        Assert.Equal(expectedScore, _game.GetScore());
    }


    [Fact]
    public void GetCurrentScore_AllGutter_ShouldReturnZeroPoints()
    {
        // Act
        const int expectedResult = 0;
        RollMany(20, 0);

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }

    [Fact]
    public void GetCurrentScore_AllStrikes_ShouldReturnMaxPoints()
    {
        // Act
        const int expectedResult = 300;
        RollMany(12, 10);

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }

    [Fact]
    public void GetCurrentScore_AllSparesFives_ShouldReturn150Points()
    {
        // Act
        const int expectedResult = 150;
        RollMany(21, 5);

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }

    [Fact]
    public void GetCurrentScore_StrikesAlternatelySparesFives_ShouldReturn200Points()
    {
        // Act
        const int expectedResult = 200;
        for (var i = 0; i < 4; i++)
        {
            _game.Roll(10);
            RollMany(2, 5);
        }

        _game.Roll(new[] {10, 5, 10});

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }

    [Fact]
    public void GetCurrentScore_OpenFrames_ShouldReturnCorrectPoints()
    {
        // Act
        const int expectedResult = 24;
        _game.Roll(new[] {5, 3, 1, 7, 0, 4, 2, 2});

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }

    [Fact]
    public void GetCurrentScore_OpenFramesAndStrike_ShouldReturnCorrectPoints()
    {
        // Act
        const int expectedResult = 35;
        _game.Roll(new[] {0, 0, 1, 3, 10, 3, 4, 5, 2});

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }

    [Fact]
    public void GetCurrentScore_OpenFramesAndSpare_ShouldReturnCorrectPoints()
    {
        // Act
        const int expectedResult = 32;
        _game.Roll(new[] {4, 2, 7, 3, 3, 2, 4, 4});

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }

    [Fact]
    public void GetCurrentScore_MoreThanOneSpare_ShouldReturnCorrectPoints()
    {
        // Act
        const int expectedResult = 43;
        _game.Roll(new[] {3, 7, 3, 7, 4, 4, 4, 4});

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }

    [Fact]
    public void GetCurrentScore_MoreThanOneStrike_ShouldReturnCorrectPoints()
    {
        // Act
        const int expectedResult = 51;
        _game.Roll(new[] {10, 10, 3, 4, 2, 2});

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }

    [Fact]
    public void GetCurrentScore_StrikesAndSparesOnly_ShouldReturnCorrectPoints()
    {
        // Act
        const int expectedResult = 215;
        RollMany(5, 10);
        RollMany(10, 5);
        _game.Roll(10);

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }

    [Fact]
    public void GetCurrentScore_ExampleGame_ShouldReturnCorrectPoints()
    {
        //Act
        const int expectedResult = 129;

        _game.Roll(new[] {2, 3, 10, 4, 5, 3, 7, 5, 4, 10, 10, 3, 2, 9, 0, 10, 3, 7});

        // Assert
        Assert.Equal(expectedResult, _game.GetScore());
    }
}