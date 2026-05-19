namespace TicTacToe.Models;
public class Tablero{
    public string[] Casillas { get; set; }
    public Tablero(){
        Casillas = new string[9];
        for(int i = 0; i < Casillas.Length; i++){
            Casillas[i] = "";
        }
    }
    public bool ColocarSimbolo(int posicion, string simbolo){
        if (Casillas[posicion] == ""){
            Casillas[posicion] = simbolo;
            return true;
        }
        return false;
    }
    public bool VerificarGanador(string simbolo){
        int[,] combinaciones =
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
        };
        for(int i = 0; i < combinaciones.GetLength(0); i++){
            if(
                Casillas[combinaciones[i,0]] == simbolo &&
                Casillas[combinaciones[i,1]] == simbolo &&
                Casillas[combinaciones[i,2]] == simbolo
            ){
                return true;
            }
        }
        return false;
    }

    public bool VerificarEmpate(){
        int cont = 0;

        for(int i = 0; i<9; i++){
            if (Casillas[i] != ""){
                cont++;
            }
        }

        if (cont == 9){
            return true;
        }
        else{
            return false;
        }
    }
}