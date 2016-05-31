#include "BasicStudy.h"
 

BasicStudy::BasicStudy()
{
}


BasicStudy::~BasicStudy()
{
}

 void BasicStudy::Test1()
{
			int oldprice, price = 0, i = 0;
			printf("请首先设置商品的真实价格：");
			scanf_s("%d", &oldprice);

			system("cls");
			printf("请输入试猜的价格：\n");
			while (oldprice != price)
			{
				i++;
				printf("参与者:");
				scanf_s("%d", &price);
				printf("主持人:");
				if (price>oldprice)
				{
					printf("高了\n");
				}
				else if (price<oldprice)
				{
					printf("低了\n");
				}
				else
				{
					printf("恭喜你， 答对了， 该商品属于你了！ \r\n 你一共试猜了%d次。\n", i);
				}
			}
			_getch();
 
}
#define NUM 13
 void BasicStudy::Test2()
 {
	 int i;
	 long fib[NUM] = { 1,1 };

	 for (i = 2; i < NUM; i++)
	 {
		 fib[i] = fib[i - 1] + fib[i - 2];
	 }
	 for (i = 0; i < NUM; i++)
	 {
		 printf("%d月兔子总数：%d \n", i, fib[i]);
	 }
	 _getch();
 }
#define FETCH 1000
#define RATE 0.0171
 void BasicStudy::Test3()
 {
	 double corpus[49];
	 int i;
	 corpus[48] = (double)FETCH;
	 for (i = 47; i >0; i--)
	 {
		 corpus[i] = (corpus[i + 1] + FETCH) / (1 + RATE / 12);
	 }

	 for (i = 48; i >0; i--)
	 {
		 printf("第%d月末本利合计：%.2f\n", i, corpus[i]);
	 }
	 _getch();
 }
