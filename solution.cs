class Puzzle {
    constructor(board) {
        this.board = board.map(row => row.slice());
        this.empty = [];
        for(let i = 0; i < 3; i++) {
            for(let j = 0; j < 3; j++) {
                if(this.board[i][j] === 0) {
                    this.empty = [i, j];
                }
            }
        }
    }
}