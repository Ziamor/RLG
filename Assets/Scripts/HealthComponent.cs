using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour
{

    public float current_health = 100;
    public float max_health = 100;

    public void SetHealth(float value)
    {
        if (value < 0)
            current_health = 0;
        else if (value > max_health)
            current_health = max_health;
        else
            current_health = value;
    }

    public void Damage(float value)
    {
        SetHealth(current_health - value);
    }

    public void Heal(float value)
    {
        SetHealth(current_health + value);
    }
}
