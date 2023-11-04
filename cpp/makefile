CPP=g++
CXX_FLAGS=-W

target: main.o board.o
	$(CPP) -o tiktaktoe main.o board.o $(CXX_FLAGS)

main.o: main.cpp board.h
	$(CPP) -c main.cpp -o main.o $(CXX_FLAGS)

board.o: board.h board.cpp
	$(CPP) -c board.cpp board.o $(CXX_FLAGS)

clean:
	rm tiktaktoe board.o main.o