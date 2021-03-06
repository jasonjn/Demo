#pragma once

#include "conio.h"
#include "stdlib.h" 
#include "stdafx.h" 

class BasicStudy
{
public:
	BasicStudy();
	~BasicStudy(); 
	//假设有一辆实际价格为640的自行车要参与者猜价格，提示是该自行车的价格在1000元以下，用程序模拟过程
	void Test1();
	/*
	递推实例
	斐波那契数列： 如果一对兔子每月能生1对小兔子，而每对小兔在它出生后的第3个月里，又能开始生1对小兔子，
	假定在不发生死亡的情况下，由1对初生的兔子开始，1年后能繁殖出多少对兔子
	*/
	void Test2();
	/*
	逆推实例
	父亲准备为小龙的4年大学生活一次性在银行储蓄一笔钱，使用整存整取的方式，控制小龙每月的月底只能提取1000元准备下月使用。
	假设银行一年整存零取的年利息为1.71%，请编程算出父亲至少一次性存入多少钱才够小龙4年大学生活
	*/
	void Test3();

 

};

