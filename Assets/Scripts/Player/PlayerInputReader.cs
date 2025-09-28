using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    public Vector3 ReadHorizontalInput()
    {
        Vector3 input = Vector3.zero;

        input.x = Input.GetAxis(Horizontal);

        return input;
    }

    public bool IsJumpKeyDown()
    {
        KeyCode jump = KeyCode.Space;

        return Input.GetKeyDown(jump);
    }

    public bool IsVampirismKeyDown()
    {
        KeyCode vampirism = KeyCode.Q;

        return Input.GetKeyDown(vampirism);
    }
}