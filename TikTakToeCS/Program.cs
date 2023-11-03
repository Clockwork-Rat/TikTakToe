
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;


Board board = new Board();

Console.WriteLine("Hello! Welcome to TikTakToe!");
Console.WriteLine("Type the Player you would like to be. (X/O).\nX(default) Goes First: ");
string? input = Console.ReadLine();
if (input == null) {
    return;
}
char player = input[0];

Console.WriteLine();

List<byte> options = new List<byte>();

for (byte i = 0; i < 9; ++i) {
    options.Add(i);
}

if (player == 'O' || player == 'o' ) {
    player = 'O';
}
else {
    player = 'X';
}

//start game loop
char turn = 'X';

AcceptInput boardState = AcceptInput.Accept;
Random random = new Random();

while(boardState == AcceptInput.Accept ||
    boardState == AcceptInput.Reject) {
    
    if (player == turn) {
        Console.WriteLine("Enter a Position:");
        Console.WriteLine("0 1 2\n3 4 5\n6 7 8");
        string? s = Console.ReadLine();
        if (s == null) {
            return;
        }
        Console.WriteLine(s[0]);
        byte position = Convert.ToByte(s[0].ToString());
        options.Remove(Convert.ToByte(s[0].ToString()));
        CellState state = player == 'X' ? CellState.X : CellState.O;
        boardState = board.Update(state, position);
    }
    else {
        int position = random.Next(options.Count);
        CellState state = player == 'X' ? CellState.O : CellState.X;
        boardState = board.Update(state, options[position]);
        options.Remove(options[position]);
    }

    if (boardState == AcceptInput.Accept){
        if (turn == 'X') {
            turn = 'O';
        }
        
        else {
            turn = 'X';
        }
    }
    

    Console.WriteLine(board);
}

if (boardState == AcceptInput.WinX) {
    Console.WriteLine("X has Won!");
}

else if (boardState == AcceptInput.WinO) {
    Console.WriteLine("O has Won!");
}

else {
     Console.WriteLine("There was a Tie :(");
}