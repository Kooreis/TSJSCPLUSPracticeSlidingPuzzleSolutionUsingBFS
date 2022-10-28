class Puzzle {
    board: number[][];
    emptySpot: number[];
    size: number;

    constructor(board: number[][]) {
        this.board = board;
        this.size = board.length;
        for (let i = 0; i < this.size; i++) {
            for (let j = 0; j < this.size; j++) {
                if (this.board[i][j] === 0) {
                    this.emptySpot = [i, j];
                }
            }
        }
    }
}