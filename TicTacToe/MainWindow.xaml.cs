using System.Diagnostics.Contracts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using TicTacToe.Models;

namespace TicTacToe;

public partial class MainWindow : Window
{   
    Selector selector;
    Juego juego;
    public MainWindow()
    {
        InitializeComponent();
        MessageBox.Show($"Elige el tipo de oponente deseado");
        MessageBox.Show($"1.- Jugador\n2.- Bot aleatorio\n3.- Bot que prioriza el centro");
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

    private void IACentro(){
        string simbolo_IA = juego.JugadorActual.Simbolo;
        Button[] botones = { B0, B1, B2, B3, B4, B5, B6, B7, B8 };
        Random random = new Random();
        int randomNumber = random.Next(9);
        bool Jugado = false;

        if(botones[4].Content != "X" && botones[4].Content != "O"){
            juego.Jugar(4);
            botones[4].Content = simbolo_IA;
        }
        else{
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
        
        switch (juego.Jugador2.Nombre){
            case "Jugador 2":
                juego.CambiarTurno();
            break;

            case "Jugador aleatorio":
                IA();
                    if (juego.HayGanador()){
                    MessageBox.Show($"{juego.JugadorActual.Nombre} ganó");
                    DesactivarBotones();
                    ReiniciarJuego();
                    return;
                }
            break;

            case "Jugador centro":
                IACentro();
                if (juego.HayGanador()){
                    MessageBox.Show($"{juego.JugadorActual.Nombre} ganó");
                    DesactivarBotones();
                    ReiniciarJuego();
                    return;
                }
            break;
        }

            juego.CambiarTurno();
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