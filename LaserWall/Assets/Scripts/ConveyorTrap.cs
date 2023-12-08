using UnityEngine;

public class ConveyorTrap : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    private Transform tf;

    private void Start()
    {
        tf = GetComponent<Transform>();
    }

    private void Update()
    {
        tf.Translate(0, 0, moveSpeed * Time.deltaTime);
    }
}
