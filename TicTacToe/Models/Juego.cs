namespace TicTacToe.Models;
public class Juego{
    public Jugador JugadorActual { get; set; }
    public Jugador Jugador1 { get; set; }
    public Jugador Jugador2 { get; set; }
    public Tablero Tablero { get; set; }
    public Juego(){
        Jugador1 = new Jugador("Jugador 1", "X");
        Jugador2 = new Jugador("Jugador 2", "O");
        JugadorActual = Jugador1;
        Tablero = new Tablero();
    }
    public bool Jugar(int posicion){
        return Tablero.ColocarSimbolo(posicion, JugadorActual.Simbolo);
    }
    public bool HayGanador(){
        return Tablero.VerificarGanador(JugadorActual.Simbolo);
    }
    public bool HayEmpate(){
        return Tablero.VerificarEmpate();
    }
    public void CambiarTurno(){
        if (JugadorActual == Jugador1)
        JugadorActual = Jugador2;
        else
        JugadorActual = Jugador1;
    }
}