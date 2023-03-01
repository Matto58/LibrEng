# LibrEng
A simple chess engine in C#.

# [WIP] Get started
1. Download LibrEng and put all files in a directory.
2. Navigate to the directory in a terminal of your choice.
## Play against LibrEng
To play against LibrEng, just run `libreng -pf "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR"` and get playing!

## Evaluate with LibrEng
To evaluate a board with LibrEng, run `libreng -ef (fen of board)` and get an eval value!

## Set analyze depth
Use the parameter `-d` to set depth (default: 6), for example: `libreng -pf "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR" -d 10`
