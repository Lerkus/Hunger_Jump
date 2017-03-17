using UnityEngine;
using System.Collections;

public class ObjectMoveClient : MonoBehaviour
{

    public float horizontalSpeedModifier;


    public void updateVelocity(float horizontalSpeed)
    {
        Rigidbody2D toManipulate = gameObject.GetComponent<Rigidbody2D>();

        toManipulate.velocity = new Vector2(horizontalSpeed * horizontalSpeedModifier, toManipulate.velocity.y);
    }
}
