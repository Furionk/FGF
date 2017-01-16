// Solution Name: FGF
// Project: FGF
// File: Ball.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using Entitas;

[Core]
public class Ball : IComponent {
    #region Fields
    public string BallName;
    #endregion
}

[Core]
public class HP : IComponent {
    #region Fields
    public int Point;
    #endregion
}

[Core]
public class SpecialBall : IComponent {
}