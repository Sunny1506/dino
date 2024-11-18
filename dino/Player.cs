
namespace dino;
public delegate void Callback();
public class Player : Animacao
{
    public Player(CachedImageView a) : base(a)
    {
        for (int i = 1; i <= 4; ++i)
            animacao1.Add($"player{i.ToString("D2")}.png");
        for (int i = 1; i <= 6; ++i)
            animacao2.Add($"playerdead{i.ToString("D2")}.png");
    }
    public void Run()
    {
        loop = true;
        SetAnimacaoAtiva(1);
        Play();
    }

    public void Die()
    {
        loop = false;
        SetAnimacaoAtiva(2);
    }
    public void MoveY (int s)
	{
		compImage.TranslationY += s;	
	}
	public double GetY ()
	{
		return compImage.TranslationY;
	}
	public void SetY (double a)
	{
		compImage.TranslationY = a;
	}

}
