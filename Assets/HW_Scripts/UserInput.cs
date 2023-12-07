using UnityEngine;
using UnityEngine.Events;

public class UserInput : MonoBehaviour, IMover
{
    [SerializeField] private float _speed = 5;

    public event UnityAction<Vector2> DirectionChanged;
    public event UnityAction<float> SpeedChanged;
    public event UnityAction Jump;

    private void Update()
    {
        CheakingButtonPress(KeyCode.D, Vector2.right);
        CheakingButtonPress(KeyCode.A, Vector2.left);
        CheakingButtonDown(KeyCode.Space, Jump);
    }

    private void CheakingButtonPress(KeyCode keyCode, Vector2 direction)
    {
        if (Input.GetKey(keyCode))
        {
            DirectionChanged?.Invoke(direction);
            SpeedChanged?.Invoke(_speed);
        }
        else if (Input.GetKeyUp(keyCode))
        {
            DirectionChanged?.Invoke(Vector2.zero);
            SpeedChanged?.Invoke(0);
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