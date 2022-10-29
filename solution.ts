toString(): string {
        return this.board.map(row => row.join(' ')).join('\n');
    }

    swap([x1, y1]: number[], [x2, y2]: number[]): void {
        [this.board[x1][y1], this.board[x2][y2]] = [this.board[x2][y2], this.board[x1][y1]];
        this.emptySpot = [x2, y2];
    }