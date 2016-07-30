using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public HealthComponent hp;

    private RectTransform health_bar_rect;
    private Text hp_text;
    private Image img;

    void Start()
    {
        health_bar_rect = this.GetComponent<RectTransform>();
        img = this.GetComponent<Image>();

        hp_text = GameObject.Find("HP_Text").GetComponent<Text>();
    }

    void Update()
    {
        hp_text.text = ((int)hp.current_health) + "\\" + ((int)hp.max_health);       

        float hp_percent = hp.current_health / hp.max_health;

        if (hp_percent > 0.5)
            img.color = Color.Lerp(Color.yellow, Color.green, (hp_percent - 0.5f) * 2);
        else
            img.color = Color.Lerp(Color.red, Color.yellow, hp_percent * 2);
        health_bar_rect.localScale = new Vector2(hp_percent, 1);
    }
}
