using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _player;
    public Vector3 offset;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        gameObject.transform.Rotate(Vector3.up, 180);
    }

    private void LateUpdate()
    {
        gameObject.transform.position = _player.position + offset;
    }
}
