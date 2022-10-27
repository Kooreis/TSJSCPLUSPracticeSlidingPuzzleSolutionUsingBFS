```cpp
#include <iostream>
#include <queue>
#include <vector>
#include <map>
#include <algorithm>

using namespace std;

typedef vector<int> Puzzle;
map<Puzzle, int> dist;

Puzzle move(const Puzzle &p, int i, int j) {
    Puzzle ret(p);
    swap(ret[i], ret[j]);
    return ret;
}

int bfs(Puzzle start) {
    queue<Puzzle> q;
    dist[start] = 0;
    q.push(start);
    while(!q.empty()) {
        Puzzle here = q.front();
        q.pop();
        int cost = dist[here];
        if(is_sorted(here.begin(), here.end())) return cost;
        int zero = find(here.begin(), here.end(), 0) - here.begin();
        int y = zero/3;
        int x = zero%3;
        if(y > 0) {
            Puzzle there = move(here, zero, zero-3);
            if(dist.count(there) == 0) {
                q.push(there);
                dist[there] = cost + 1;
            }
        }
        if(y < 2) {
            Puzzle there = move(here, zero, zero+3);
            if(dist.count(there) == 0) {
                q.push(there);
                dist[there] = cost + 1;
            }
        }
        if(x > 0) {
            Puzzle there = move(here, zero, zero-1);
            if(dist.count(there) == 0) {
                q.push(there);
                dist[there] = cost + 1;
            }
        }
        if(x < 2) {
            Puzzle there = move(here, zero, zero+1);
            if(dist.count(there) == 0) {
                q.push(there);
                dist[there] = cost + 1;
            }
        }
    }
    return -1;
}

int main() {
    Puzzle start(9);
    for(int i=0; i<9; ++i) cin >> start[i];
    cout << bfs(start) << endl;
    return 0;
}
```