using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour
{
    public virtual event UnityAction<Vector2> EventDirection;
    public virtual event UnityAction<float> EventSpeed;
    public virtual event UnityAction Jump;
}