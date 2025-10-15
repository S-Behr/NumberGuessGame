namespace AzubiDemo;

public enum Status
{
    Idle,
    WhatDifficulty_Running,
    GameLogic_Running,
    Win_Running,
    Lose_Running,
    LastChance_Running,
    Finished
}

public static class GlobalStatus
{
    public static Status CurrentStatus = Status.Idle;
}
