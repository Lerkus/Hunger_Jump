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
                toMove.updateVelocity(horizontalInput);
            }
            else
            {
                print("Move Client fehlt!");
            }

        }
    }
}
