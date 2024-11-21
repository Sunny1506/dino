using Microsoft.Maui.Platform;


public class Enemy
{
    Image imageView;
    public Enemy (Image a)
    {
        imageView = a;
    }
    public void MoveX(double s)
    {
        imageView.TranslationX -= s;

    }
    public double GetX()
    {
        return imageView.TranslationX;
    }
    public void Reset()
    {
        imageView.TranslationX = 500;
    }
}