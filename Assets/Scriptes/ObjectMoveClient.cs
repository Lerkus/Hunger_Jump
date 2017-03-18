using UnityEngine;
using System.Collections;

public class ObjectMoveClient : MonoBehaviour
{

    public float horizontalSpeedModifier;
    public Vector2 ownSpeed = new Vector2();

    public void updateVelocity(float horizontalSpeed)
    {
        Rigidbody2D toManipulate = gameObject.GetComponent<Rigidbody2D>();

        toManipulate.velocity = ownSpeed + new Vector2(horizontalSpeed * horizontalSpeedModifier, toManipulate.velocity.y);
    }
}
