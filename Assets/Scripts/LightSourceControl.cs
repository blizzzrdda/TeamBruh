using TMPro;
using UnityEngine;

public class LightSourceControl : MonoBehaviour
{
    public float speed;
    public bool Enabled { get; set; }
    public Transform lightSource;
    public TMP_Text text;
    
    private readonly string[] _textList = {"Press [F] to Control", "[WASDQE] to Move, [F] to Leave"};

    private void Update()
    {
        if (InputManager.Instance.controlState != 2 || !Enabled)
        {
            text.text = _textList[0];
        }
        else
        {
            text.text = _textList[1];
            Control();
        }
    }

    private void Control()
    {
        var x = InputManager.Instance.GetMoveHorizontal();
        var y = InputManager.Instance.GetMoveVertical();
        var z = InputManager.Instance.GetMoveInOut();
        var movement = new Vector3(x, -y, z) * Time.deltaTime * speed;
        lightSource.transform.Translate(movement);
    }
}