using UnityEngine;
using System.Collections;

public class ObjectMoveMaster : MonoBehaviour
{
    public GameObject masterParent;

    public void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        foreach (Transform child in masterParent.transform)
        {
            ObjectMoveClient toMove = child.GetComponent<ObjectMoveClient>();
            if (toMove != null)
            {
                toMove.updateVelocity(-horizontalInput * 2);
            }
            else
            {
                Debug.Log("Move Client fehlt!");
            }
        }
    }
    public void changeGravity()
    {
        foreach (Transform child in masterParent.transform)
        {
            Rigidbody2D phisi = child.GetComponent<Rigidbody2D>();
            phisi.gravityScale = 0;
        }
    }
}
