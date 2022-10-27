```typescript
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

    toString(): string {
        return this.board.map(row => row.join(' ')).join('\n');
    }

    swap([x1, y1]: number[], [x2, y2]: number[]): void {
        [this.board[x1][y1], this.board[x2][y2]] = [this.board[x2][y2], this.board[x1][y1]];
        this.emptySpot = [x2, y2];
    }

    getNeighbors(): number[][] {
        const [x, y] = this.emptySpot;
        const neighbors = [[x - 1, y], [x + 1, y], [x, y - 1], [x, y + 1]];
        return neighbors.filter(([x, y]) => x >= 0 && x < this.size && y >= 0 && y < this.size);
    }

    clone(): Puzzle {
        const newBoard = this.board.map(row => [...row]);
        return new Puzzle(newBoard);
    }
}

function bfs(start: Puzzle, target: string): string[] {
    const queue: { puzzle: Puzzle, path: string[] }[] = [{ puzzle: start, path: [] }];
    const visited = new Set([start.toString()]);

    while (queue.length > 0) {
        const { puzzle, path } = queue.shift()!;
        if (puzzle.toString() === target) {
            return path;
        }

        for (const neighbor of puzzle.getNeighbors()) {
            const newPuzzle = puzzle.clone();
            newPuzzle.swap(puzzle.emptySpot, neighbor);
            const newPuzzleStr = newPuzzle.toString();
            if (!visited.has(newPuzzleStr)) {
                visited.add(newPuzzleStr);
                queue.push({ puzzle: newPuzzle, path: [...path, newPuzzleStr] });
            }
        }
    }

    return [];
}

const start = new Puzzle([[1, 2, 3], [5, 0, 6], [7, 8, 4]]);
const target = '1 2 3\n5 8 6\n7 0 4';
const path = bfs(start, target);
console.log(path);
```