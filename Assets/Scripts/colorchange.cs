using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
    public float duration = 1.0F;
    public Color color0 = Color.red;
    public Color color1 = Color.blue;
    void Update() {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        light.color = Color.Lerp(color0, color1, t);
    }
}
