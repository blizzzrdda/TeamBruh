using TMPro;
using UnityEngine;

public class LightSourceControl : MonoBehaviour
{
    public float speed;
    public bool Enabled { get; set; }
    public Transform lightSource;
    public Transform instructionCanvas;

    private TMP_Text text;
    private readonly string[] _textList = {"Press [F] to Control", "Press [F] to Leave"};

    private void Awake()
    {
        text = instructionCanvas.GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        instructionCanvas.transform.LookAt(Camera.main.transform);
        
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