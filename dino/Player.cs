

public delegate void Callback();
public class Player: Animacao
{
    public Player(Image a) : base(a)
    {
        for (int i = 1; i <= 4; ++i)
            Animacao1.Add($"player { i.ToString("D2")}.png");
        for (int i = 1; i <= 6; ++i)
            Animacao1.Add($"playerdead { i.ToString("D2")}.png");
    }
}
