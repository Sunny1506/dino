namespace dino;

public class Animacao
{
    protected List<String> animacao1 = new List<String>();
    protected List<String> animacao2 = new List<String>();
    protected List<String> animacao3 = new List<String>();
    protected bool loop = true;
    protected int AnimacaoAtiva = 1;
    bool parado = true;
    int frameAtual = 1;
    protected Image compImage;
    public Animacao(Image a)
    {
        compImage = a;
    }
    public void Stop()
    {
        parado = true;
    }
    public void Play()
    {
        parado = false;
    }
    public void SetAnimacaoAtiva(int a)
    {
        AnimacaoAtiva = a;
    }
    public void Desenha()
    {
        if (parado)
            return;
        string NomeArquivo = "";
        int TamanhoAnimacao = 0;
        if (AnimacaoAtiva == 1)
        {
            NomeArquivo = animacao1[frameAtual];
            TamanhoAnimacao = animacao1.Count;
        }
        else if (AnimacaoAtiva == 2)
        {
            NomeArquivo = animacao2[frameAtual];
            TamanhoAnimacao = animacao2.Count;
        }
        else if (AnimacaoAtiva == 3)
        {
            NomeArquivo = animacao3[frameAtual];
            TamanhoAnimacao = animacao3.Count;
        }
        compImage.Source = ImageSource.FromFile(NomeArquivo);
        frameAtual++;
        if (frameAtual >= TamanhoAnimacao)
        {
            if (loop)
                frameAtual = 0;
            else
            {
                parado = true;
                QuandoParar();
            }
        }

    }
    public virtual void QuandoParar()
    {

    }

}