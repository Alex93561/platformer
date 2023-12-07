using UnityEngine;
using UnityEngine.Events;

interface IMover
{
    public event UnityAction<Vector2> DirectionChanged;
    public event UnityAction<float> SpeedChanged;
    public event UnityAction Jump;
}