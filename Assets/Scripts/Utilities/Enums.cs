namespace HiddenTrail.Utilities
{
    public enum GameState
    {
        Idle,
        Playing,
        Win,
        Fail
    }

    public enum SwipeDirection
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    public enum TileState
    {
        Hidden,     // not yet visited
        Revealed,   // player has touched; passable briefly
        Blocked,    // player left; impassable
        Wall        // static obstacle
    }

    public enum TileType
    {
        Normal,
        Wall,
        Start
    }
}