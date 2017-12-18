#include "stdafx.h"
#include <iostream>
#include <dos.h>
#include <stdio.h>
#include <conio.h>
#include <array>
#include <windows.h>
#include <list>
#include <vector>
#include <stdlib.h>
#include "AutoMaze.h"

#include "Player.h"

using namespace std;

class Player
{
	
public:

	 int index;
	 std::array<Player, 50> mPlayers;
	 enum Directions { Left, Right, Up, Down };
	 std::array<Directions, 4> directions;
	 const int WIDTH = 8, HEIGHT = 8;
	
	char icon;
	int X;
	int Y;
	int name;

	char cLeft = currentMap[X - 1][Y];
	char cRight = currentMap[X + 1][Y];
	char cUp = currentMap[X][Y + 1];
	char cDown = currentMap[X][Y - 1];

	void Player::Check()
	{
		int i = 0;
		if ((cUp != '#') && (cUp !=','))
		{
			directions[i] = Up;
			i++;
		}
		else if ((cDown != '#') && (cDown != ','))
		{
			directions[i] = Down;
			i++;
		}
		else if ((cLeft != '#') && (cLeft != ','))
		{
			directions[i] = Left;
			i++;
		}
		else if ((cRight != '#') && (cRight != ','))
		{
			directions[i] = Right;
			i++;

		}
		else
		{
			Die();
		}

		Act();

	}

	void Player::Act()
	{
		int i = 0;

		int PrevX = X;
		int PrevY = Y;

		this->Move(directions[i]);

		if (directions.size() > 1)
		{
			for (; i < directions.size(); i++)
			{
				mPlayers[index] = Player(PrevX, PrevY);
				mPlayers[index].Move(directions[i]);
				index++;
			}
		}

	}

	void Player::Move(Directions dir)
	{
		int d;
		if (dir == Up) { d = 0; }
		else if (dir == Down) { d = 1; }
		else if (dir == Left) { d = 2; }
		else if (dir == Right) { d = 3; }

		switch (d)
		{
		case 0: Y--;
			map1[X][Y++] = ',';
			break;
		case 1: Y++;
			map1[X][Y--] = ',';
			break;
		case 2: X--;
			map1[X++][Y] = ',';
			break;
		case 3: X++;
			map1[X--][Y] = ',';
			break;
		}

		Check();
	}

	void Die()
	{
		icon = ',';
	}

	Player::Player(int X, int Y)
	{
		this->X = X;
		this->Y = Y;
		this->icon = '@';
		
	}

};

