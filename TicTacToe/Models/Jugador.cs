namespace TicTacToe.Models;
public class Jugador{
    public string Nombre { get; set; }
    public string Simbolo { get; set; }
    public Jugador(string nombre, string simbolo){
        Nombre = nombre;
        Simbolo = simbolo;
    }
}