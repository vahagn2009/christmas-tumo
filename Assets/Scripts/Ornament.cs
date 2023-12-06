using UnityEngine;

public class Ornament : MonoBehaviour
{
    [SerializeField] private Renderer bodyRenderer;
    [SerializeField] private Rigidbody sphereRigidbody;

    public Renderer BodyRenderer => bodyRenderer;
    public Rigidbody SphereRigidbody => sphereRigidbody;
}