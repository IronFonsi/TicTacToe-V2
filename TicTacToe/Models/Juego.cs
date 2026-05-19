namespace TicTacToe.Models;
public class Juego{
    public Jugador JugadorActual { get; set; }
    public Jugador Jugador1 { get; set; }
    public Jugador Jugador2 { get; set; }
    public Tablero Tablero { get; set; }
    public Juego(){
        string tipo = Console.ReadLine();
        Jugador1 = new Jugador("Jugador 1", "X");
        switch (tipo){
            case "1":
                Jugador2 = new Jugador("Jugador 2", "O");
                break;
            case "2":
                Jugador2 = new Jugador("Jugador aleatorio", "O");
                break;
            case "3":
                Jugador2 = new Jugador("Jugador centro", "O");
                break;
            default:
                Jugador2 = new Jugador("Jugador centro", "O");
                break;
        }
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