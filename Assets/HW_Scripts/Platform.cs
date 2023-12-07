using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IMover>(out _))
        {
            collision.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IMover>(out _))
        {
            collision.transform.SetParent(null);
        }
    }
}