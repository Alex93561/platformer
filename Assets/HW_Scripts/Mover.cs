using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour
{
    public virtual event UnityAction<Vector2> DirectionChanged;
    public virtual event UnityAction<float> SpeedChanged;
    public virtual event UnityAction Jump;
}