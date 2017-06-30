using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public float progress_percent = 1f;

    private RectTransform progress_bar_rect;
    private Image img;

    void Start()
    {
        progress_bar_rect = this.GetComponent<RectTransform>();
        img = this.GetComponent<Image>();
    }

    void Update()
    {
        progress_bar_rect.localScale = new Vector2(progress_percent, 1);
    }

    public void SetProgress(float new_progress)
    {
        if (new_progress > 1f)
            new_progress = 1f;
        else if (new_progress < 0f)
            new_progress = 0f;
        progress_percent = new_progress;
    }
}
