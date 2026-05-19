using System.Diagnostics.Contracts;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.Models;

namespace TicTacToe;

public partial class MainWindow : Window
{
    Juego juego;
    public MainWindow()
    {
        InitializeComponent();

        juego = new Juego();
    }

    private void ReiniciarJuego(){
        juego = new Juego();

        Button[] botones = { B0, B1, B2, B3, B4, B5, B6, B7, B8 };

        foreach (Button boton in botones)
        {
            boton.Content = "";     
            boton.IsEnabled = true; 
        }

        juego.JugadorActual = juego.Jugador1;
}

    private void IA(){
        string simbolo_IA = juego.JugadorActual.Simbolo;
        Button[] botones = { B0, B1, B2, B3, B4, B5, B6, B7, B8 };
        Random random = new Random();
        int randomNumber = random.Next(9);
        bool Jugado = false;

        do{
            if(botones[randomNumber].Content == "X" || botones[randomNumber].Content == "O"){
                randomNumber = random.Next(9); 
            }
            else{
                Jugado = true;
            } 
        }while(Jugado == false);

        juego.Jugar(randomNumber);
        botones[randomNumber].Content = simbolo_IA;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button boton = sender as Button;
        int posicion = int.Parse(boton.Name.Replace("B", ""));

        bool movimientoValido = juego.Jugar(posicion);

        if (!movimientoValido)
        {
            MessageBox.Show("Casilla ocupada");
            return;
        }

        boton.Content = juego.JugadorActual.Simbolo;

        if (juego.HayGanador()){
            MessageBox.Show($"{juego.JugadorActual.Nombre} ganó");
            DesactivarBotones();
            ReiniciarJuego();
            return;
        }
        else if (juego.HayEmpate()){
            MessageBox.Show("El juego terminó en un empate");
            DesactivarBotones();
            ReiniciarJuego();
            return;
        }

        juego.CambiarTurno();
        
        if (juego.JugadorActual == juego.Jugador2){
            IA();

            if (juego.HayGanador()){
                MessageBox.Show($"{juego.JugadorActual.Nombre} ganó");
                DesactivarBotones();
                ReiniciarJuego();
                return;
            }

            juego.CambiarTurno();
        }
    }

    private void DesactivarBotones(){
        B0.IsEnabled = false;
        B1.IsEnabled = false;
        B2.IsEnabled = false;
        B3.IsEnabled = false;
        B4.IsEnabled = false;
        B5.IsEnabled = false;
        B6.IsEnabled = false;
        B7.IsEnabled = false;
        B8.IsEnabled = false;
    }
}