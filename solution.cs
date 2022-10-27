Here is a JavaScript solution using Breadth-First Search (BFS) to solve the sliding puzzle problem:

```javascript
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

    possibleMoves() {
        let [x, y] = this.empty;
        let moves = [];
        if(x > 0) moves.push([x - 1, y]);
        if(x < 2) moves.push([x + 1, y]);
        if(y > 0) moves.push([x, y - 1]);
        if(y < 2) moves.push([x, y + 1]);
        return moves;
    }
}

function solve(board) {
    let puzzle = new Puzzle(board);
    let queue = [puzzle];
    let seen = new Set([puzzle.board.toString()]);

    while(queue.length > 0) {
        let current = queue.shift();
        if(current.isSolved()) {
            return true;
        }

        for(let move of current.possibleMoves()) {
            let clone = current.clone();
            clone.swap(clone.empty, move);
            if(!seen.has(clone.board.toString())) {
                queue.push(clone);
                seen.add(clone.board.toString());
            }
        }
    }

    return false;
}

console.log(solve([[1, 2, 3], [4, 0, 6], [7, 5, 8]])); // true
console.log(solve([[1, 2, 3], [4, 5, 6], [7, 8, 0]])); // true
console.log(solve([[1, 2, 3], [5, 4, 6], [7, 8, 0]])); // false
```

This code defines a `Puzzle` class to represent the state of the puzzle board. The `solve` function uses BFS to explore all possible states of the puzzle until it finds a solution. The `seen` set is used to avoid revisiting the same state.