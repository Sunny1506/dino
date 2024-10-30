namespace dino;

public partial class MainPage : ContentPage
{
	bool estaMorto = false;
	const int gravidade = 5;
	const int ForcaPulo = 30;
	int Score = 0;
	double larguraJanela = 0;
	double AlturaJanela = 0;
	int velocidade = 10;
	bool EstaPulando = false;
	int TempoPulando = 0;
	const int MaximoTempoPulando = 3;

	public MainPage()
	{
		InitializeComponent();
	}
	void OnGridClicked(object s, TappedEventArgs a)
	{
		EstaPulando = true;
	}
	void AplicaGravidade()
	{
		Dino.TranslationY += gravidade;
	}
	 public async void Desenha()
	{
		while (!estaMorto)
		{
			if (EstaPulando)
				AplicaPulo();
			else
				AplicaGravidade();

		}
	}
	void AplicaPulo()
	{
		Dino.TranslationY -= ForcaPulo;
		TempoPulando++;
		if (TempoPulando >= MaximoTempoPulando)
		{
			EstaPulando = false;
			TempoPulando = 0;
		}
	}
	async void Oi(object s, TappedEventArgs e)
	{

		FrameGameOver.IsVisible = false;
		estaMorto = false;
		Inicializar();
		LabelObstaculos.Text = "Você passou por " + Score.ToString("D3") + " Obstáculos!!";
	}

	void Inicializar()
	{
		imgcacto.TranslationX = -larguraJanela;
		Dino.TranslationX = 0;
		Dino.TranslationY = 0;
		Score = 0;
	}


	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		larguraJanela = w;
		AlturaJanela = h;
	}
	void GerenciaCacto()
	{
		imgcacto.TranslationX -= velocidade;
		if (imgcacto.TranslationX < -larguraJanela)
		{
			imgcacto.TranslationX = 0;
			Score++;
			LabelScore.Text = "Canos: " + Score.ToString("D3");
			if (Score % 2 == 0)
				velocidade++;

		}


	}
	



}



