
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        otherObject.GetComponent<MeshRenderer>().material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        Color color = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f), Random.Range(0f, 1f),1f);
        return color;
    }
}
