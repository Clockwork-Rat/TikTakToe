using System.Security.Cryptography.X509Certificates;

enum CellState {
    EMPTY,
    X,
    O
}

enum AcceptInput {
    Reject,
    Tie,
    WinX,
    WinO,
    Accept
}

class Board {

    public CellState[] BoardState = new CellState[9];

    public Board() {
        for (int i = 0; i < BoardState.Length; ++i) {
            BoardState[i] = CellState.EMPTY;
        }
    }

    public AcceptInput Update(CellState state, byte cell) {
        if (BoardState[cell] != CellState.EMPTY || cell > 8) {
            return AcceptInput.Reject;
        }

        BoardState[cell] = state;
        AcceptInput win = CheckWin();
        if (win != AcceptInput.Reject) {
            return win;
        }
        else if (CheckTie()) {
            return AcceptInput.Tie;
        }
        else {
            return AcceptInput.Accept;
        }
    }

    AcceptInput CheckWin() {
        
        // check all possible states for a win and return winner
        // if none have win, return empty

        //possible win states
        // X X X / vertical version

        // X - -
        // - X -
        // - - X / or mirror

        for (int i = 0; i < BoardState.Length; i += 3 ) {
            //check horizantal
            if (BoardState[i] == BoardState[i + 1] && 
                BoardState[i] == BoardState[i + 2]) {
                    if (BoardState[i] == CellState.X) {
                        return AcceptInput.WinX;
                    }

                    else if (BoardState[i] == CellState.O) {
                        return AcceptInput.WinO;
                    }
            }
        }

        for (int i = 0; i < 3; ++i ) {
            if(BoardState[i] == BoardState[i + 3] &&
                BoardState[i] == BoardState[i + 6]) {
                if (BoardState[i] == CellState.X) {
                    return AcceptInput.WinX;
                }

                else if (BoardState[i] == CellState.O) {
                    return AcceptInput.WinO;
                }
            }
        }

        if ( BoardState[0] == BoardState[4] &&
            BoardState[0] == BoardState[8]) {
            if (BoardState[0] == CellState.X) {
                return AcceptInput.WinX;
            }

            else if (BoardState[0] == CellState.O) {
                return AcceptInput.WinO;
            }
        }

        if ( BoardState[2] == BoardState[4] &&
            BoardState[2] == BoardState[6]) {
            if (BoardState[2] == CellState.X) {
                return AcceptInput.WinX;
            }

            else if (BoardState[2] == CellState.O) {
                return AcceptInput.WinO;
            }
        }

        return AcceptInput.Reject; // there is no win
    }

    bool CheckTie() {
        if (!BoardState.Contains(CellState.EMPTY))
            return true;

        return false;
    }

    public override string ToString() {
        string s  = "";

        for (int i = 0; i < BoardState.Length; ++i) {
            string boardState = "-";
            if (BoardState[i] == CellState.X) {
                boardState = "X";
            }
            else if (BoardState[i] == CellState.O) {
                boardState = "O";
            }
            s += boardState + " ";
            if (i % 3 == 2) {
                s += "\n";
            }
        }

        return s;
    }
}