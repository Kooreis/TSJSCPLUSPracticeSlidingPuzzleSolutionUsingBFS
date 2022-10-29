Puzzle move(const Puzzle &p, int i, int j) {
    Puzzle ret(p);
    swap(ret[i], ret[j]);
    return ret;
}