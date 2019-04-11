#pragma once
#include<iostream>
using namespace std;
class Dijstra
{
public:
	Dijstra() {};
	Dijstra(int point, int edge)
	{
		this->point = point;
		this->edge = edge;
		//		cout << point << edge;
	}
	void innit()
	{
		a = new int*[point];
		for (int i = 0; i < point; i++)
		{
			a[i] = new int[point]();
			memset(a[i], 999999, point * sizeof(int));//当sizeof一个指针时，返回值为指针本身的大小而不是指针指向区域的大小，
													  //所以第三个要明确空间大小，不能sizeof(d[i]).
		}
		for (int i = 0; i < edge; i++)
		{
			int p1, p2;
			cin >> p1 >> p2;
			cin >> a[p1][p2];
			cout << a[p1][p2];
		}
	}
	void setPoint(int point)
	{
		this->point = point;
	}
	int getPoint() {
		return point;
	}
	void setEdge(int edge)
	{
		this->edge = edge;
	}
	int getEdge()
	{
		return this->edge;
	}
	~Dijstra() {
		for (int i = 0; i < point; i++) 
		{
			delete[] a[i];
		}
		delete[]a;
	}

private:
	int point = 0;
	int edge = 0;
	int **a;


};