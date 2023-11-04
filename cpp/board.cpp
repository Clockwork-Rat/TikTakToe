#include "board.h"

Board::Board() {
    for (int i = 0; i < 9; ++i ) {
        board_state[i] = EMPTY;
    }
}

int Board::update(int state, int cell) {
    if (cell > 8 || board_state[cell] != EMPTY ) {
        return REJECT;
    }

    board_state[cell] = state;
    int win = check_win();
    if (win != REJECT) {
        return win;
    }
    if (check_tie()) {
        return TIE;
    }
    else {
        return ACCEPT;
    }
}

int Board::check_win() {
    for( int i = 0; i < 9; i += 3) {
        if (board_state[i] == board_state[i + 1] &&
            board_state[i] == board_state[i + 2]) {
            if(board_state[i] == X) {
                return WIN_X;
            }

            if (board_state[i] == O) {
                return WIN_O;
            }
        }
    }

    for (int i = 0; i < 3; ++i ) {
        if (board_state[i] == board_state[i + 3] &&
            board_state[i] == board_state[i + 6]) {
            if (board_state[i] == X) {
                return WIN_X;
            }
            
            if (board_state[i] == O) {
                return WIN_O;
            }
        }
    }


}

bool Board::check_tie() {
    
}

Board::operator std::string() {
    return "Niets";
}