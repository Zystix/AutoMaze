#pragma once

#include "Player.cpp"

using namespace std;


class Player {

public:

	 int X;
	 int Y;
	 char icon;

	 static int index;
	 static std::array<Player, 50> mPlayers;
	 static enum Directions { Left, Right, Up, Down };
	 static std::array<Directions, 4> directions;
	 static const int WIDTH = 8, HEIGHT = 8;


	 Player(int X, int Y);

	 void Check();
	 void Act();
	 void Move(Directions dir);

};
