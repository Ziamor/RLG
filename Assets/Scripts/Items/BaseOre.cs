
public class BaseOre : BaseIngredient
{
    private float purity;

    public float Purity
    {
        get { return purity; }
        set
        {
            if (value < 0)
                purity = 0;
            else if (value > 1)
                purity = 1;
            else
                purity = value;
        }
    }
}

