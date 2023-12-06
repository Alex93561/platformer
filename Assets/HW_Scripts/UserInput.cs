using UnityEngine;
using UnityEngine.Events;

public class UserInput : Mover
{
    [SerializeField] private float _speed = 5;

    public override event UnityAction<Vector2> EventDirection;
    public override event UnityAction<float> EventSpeed;
    public override event UnityAction Jump;

    void Update()
    {
        CheakingButtonDown(KeyCode.D, Vector2.right);
        CheakingButtonDown(KeyCode.A, Vector2.left);

        CheakingButtonDown(KeyCode.Space, Jump);
    }

    private void CheakingButtonDown(KeyCode keyCode, Vector2 direction)
    {
        if (Input.GetKey(keyCode))
        {
            EventDirection?.Invoke(direction);
            EventSpeed?.Invoke(_speed);
        }
        else if (Input.GetKeyUp(keyCode))
        {
            EventDirection?.Invoke(Vector2.zero);
            EventSpeed?.Invoke(0);
        }
    }

    private void CheakingButtonDown(KeyCode keyCode, UnityAction unityAction)
    {
        if (Input.GetKeyDown(keyCode))
        {
            unityAction?.Invoke();
        }
    }
}