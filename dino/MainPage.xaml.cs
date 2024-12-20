﻿using Microsoft.VisualBasic;
using FFImageLoading.Maui;

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
	const int forcaGravidade = 10;
	bool estanoChao = true;
	bool estanoAr = false;
	int tempoPulando = 0;
	int temponoAr = 0;
	const int forcaPulo = 15;
	const int maxTempoPulando = 12;
	const int maxTemponoAr = 8;
	Player player;




	public MainPage()
	{
		InitializeComponent();
		player = new Player(imgPlayer);
		player.Run();
	}
	Enemies enemies;
	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);
		enemies = new Enemies(-w);
		enemies.Add(new Enemy(imgEnemy1));
		enemies.Add(new Enemy(imgEnemy2));
		enemies.Add(new Enemy(imgEnemy3));
		enemies.Add(new Enemy(imgEnemy4));
	}
	void CalculaVelocidade(double w)
	{
		velocidade1 = (int)(w * 0.001);
		velocidade2 = (int)(w * 0.004);
		velocidade3 = (int)(w * 0.008);
		velocidade = (int)(w * 0.01);

	}
	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach (var a in Layer1.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in Layer2.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in Layer3.Children)
			(a as Image).WidthRequest = w;

		Layer1.WidthRequest = w * 1.5;
		Layer2.WidthRequest = w * 1.5;
		Layer3.WidthRequest = w * 1.5;
	}
	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenarios(Layer1);
		GerenciaCenarios(Layer2);
		GerenciaCenarios(Layer3);

	}
	void MoveCenario()
	{
		Layer1.TranslationX -= velocidade1;
		Layer2.TranslationX -= velocidade2;
		Layer3.TranslationX -= velocidade3;
	}
	void GerenciaCenarios(HorizontalStackLayout horizontalStackLayout)
	{
		var view = (horizontalStackLayout.Children.First() as Image);
		if (view.WidthRequest + horizontalStackLayout.TranslationX < 0)
		{
			horizontalStackLayout.Children.Remove(view);
			horizontalStackLayout.Children.Add(view);
			horizontalStackLayout.TranslationX = view.TranslationX;
		}
	}

	async Task Desenha()
	{
		while (!estaMorto)
		{
			GerenciaCenarios();
			if (enemies != null)
				enemies.Desenha(velocidade);
			if (!estaPulando && !estanoAr)
			{
				AplicaGravidade();
				player.Desenha();
			}
			else
				AplicaPulo();
			await Task.Delay(tempoEntreFrames);
		}


	}
	void AplicaGravidade()
	{
		if (player.GetY() < 0)
			player.MoveY(forcaGravidade);
		else if (player.GetY() >= 0)
		{
			player.SetY(0);
			estanoChao = true;
		}
	}
	void AplicaPulo()
	{
		estanoChao = false;
		if (estaPulando && tempoPulando >= maxTempoPulando)
		{
			estaPulando = false;
			estanoAr = true;
			temponoAr = 0;
		}
		else if (estanoAr && temponoAr >= maxTemponoAr)
		{
			estaPulando = false;
			estanoAr = false;
			tempoPulando = 0;
			temponoAr = 0;
		}
		else if (estaPulando && tempoPulando < maxTempoPulando)
		{
			player.MoveY(-forcaPulo);
			tempoPulando++;
		}
		else if (estanoAr)
			temponoAr++;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
	}

	void OnGridClicked(object o, TappedEventArgs a)
	{
		if (estanoChao)
			estaPulando = true;
	}


}



