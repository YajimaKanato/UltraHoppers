using UnityEngine;

public class ModeSelect : MonoBehaviour
{
    static bool _acieve;
    public static bool Achieve { get { return _acieve; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _acieve = false;
    }

    public void Achi()
    {
        _acieve = true;
    }
}
