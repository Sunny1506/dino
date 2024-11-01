using Microsoft.VisualBasic;

namespace dino;

public partial class MainPage : ContentPage
{
	bool estaMorto = false;
	bool estaPulando = false;
	const int tempoEntreFrames = 25;
	int velocidade1 = 0;
	int velocidade2 = 0;
	int velocidade3 = 0;
	int velocidade = 0;
	int larguraJanela = 0;
	int alturaJanela = 0;



	public MainPage()
	{
		InitializeComponent();
	}

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);
	}
	void CalculaVelocidade(double w)
	{
		velocidade1 = (int)(w * 0.001);
		velocidade2 = (int)(w * 0.004);
		velocidade3 = (int)(w * 0.008);
		velocidade = (int)(w * 0.01);

	}
	void CorrigeTamanhoCenario (double w, double h)
	{
		foreaach (var A in Layer1.Children)
		(A as Image).WidthRequest = w;
		foreaach (var A in Layer2.Children)
		(A as Image).WidthRequest = w;
		foreaach (var A in Layer3.Children)
		(A as Image).WidthRequest = w;
		
		Layer1.WidthRequest = w * 1.5;
		Layer2.WidthRequest = w * 1.5;
		Layer3.WidthRequest = w * 1.5;
	}

}



