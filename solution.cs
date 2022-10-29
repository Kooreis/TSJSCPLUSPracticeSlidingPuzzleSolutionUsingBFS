isSolved() {
        let correct = 1;
        for(let i = 0; i < 3; i++) {
            for(let j = 0; j < 3; j++) {
                if(this.board[i][j] !== correct % 9) {
                    return false;
                }
                correct++;
            }
        }
        return true;
    }

    swap([x1, y1], [x2, y2]) {
        [this.board[x1][y1], this.board[x2][y2]] = [this.board[x2][y2], this.board[x1][y1]];
        this.empty = [x2, y2];
    }

    clone() {
        return new Puzzle(this.board);
    }