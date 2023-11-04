#ifndef BOARD_HH
#define BOARD_HH

#include <string>

enum cell_state {
    EMPTY,
    X,
    O
};

enum accept {
    ACCEPT,
    REJECT,
    WIN_O,
    WIN_X,
    TIE
};

class Board {
public:
    Board();
    int board_state[9];
    int update(int state, int cell);
    operator std::string();
private:
    int check_win();
    bool check_tie();
};

#endif