using System;

public interface IScoreAdder
{
    static Action<int> OnAddScore { get; set; }

    int Score { get; protected set; }

    void AddScore()
    {
        OnAddScore?.Invoke(Score);
    }
}