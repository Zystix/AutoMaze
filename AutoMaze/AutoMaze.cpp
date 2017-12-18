// AutoMaze.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <dos.h>
#include <stdio.h>
#include <conio.h>
#include  <windows.h>
#include <stdlib.h>
#include<list>
#include <array>
#include <vector>
#include "Player.h"

#include "AutoMaze.h"

using namespace std;

unsigned char map1[8][8] = {
	'#', '#', '#', '#', '#', '#', '#', '#',
	'#', ' ', ' ', ' ', ' ', '#', '$', '#',
	'#', ' ', '#', ' ', ' ', ' ', ' ', '#',
	'#', ' ', '#', '#', '#', ' ', ' ', '#',
	'#', ' ', ' ', ' ', ' ', '#', ' ', '#',
	'#', ' ', '#', ' ', ' ', ' ', ' ', '#',
	'#', ' ', '#', ' ', '#', ' ', '#', '#',
	'#', '#', '#', '#', '#', '#', '#', '#',
};

unsigned char currentMap[8][8];


void DrawMap()
{
	Sleep(500);
	for (int i = 0; i < Player::HEIGHT; i++)
	{
		for (int u = 0; u < Player::WIDTH; u++)
		{
			currentMap[u][i] = map1[u][i];
		}

	}


	for (int i = 0; i < Player::mPlayers.size(); i++)
	{
		currentMap[Player::mPlayers[i].X][Player::mPlayers[i].Y] = Player::mPlayers[i].icon;
	}

	for (int i = 0; i < Player::HEIGHT; i++)
	{
		cout << endl;
		for (int u = 0; u < Player::WIDTH; u++)
		{
			cout << currentMap[u][i];
		}
		
	}
}
	
int main()
{

	Player::index = 0;
	Player parent = Player(1, 1);
	Player::mPlayers[Player::index] = parent;
	Player::index++;

	DrawMap();

	
	int a;
	cin >> a;
}


