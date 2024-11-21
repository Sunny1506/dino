using Microsoft.Maui.Platform;

public class Enemy
{
    public Inimigo(imagem a)
    {
        imageView = a;
    }
    public void MoveX(double s)
    {
        imageView.TranslationX -= s;

    }
    public double GetX()
    {
        return imageView.TranlationX;
    }
    public void Reset()
    {
        imageView.TranlationX = 500;
    }
}