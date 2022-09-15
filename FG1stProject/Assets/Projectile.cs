
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isActive;


    public void Initialize()
    {
        isActive = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }
}
