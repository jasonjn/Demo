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
			printf("������������Ʒ����ʵ�۸�");
			scanf_s("%d", &oldprice);

			system("cls");
			printf("�������Բµļ۸�\n");
			while (oldprice != price)
			{
				i++;
				printf("������:");
				scanf_s("%d", &price);
				printf("������:");
				if (price>oldprice)
				{
					printf("����\n");
				}
				else if (price<oldprice)
				{
					printf("����\n");
				}
				else
				{
					printf("��ϲ�㣬 ����ˣ� ����Ʒ�������ˣ� \r\n ��һ���Բ���%d�Ρ�\n", i);
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
		 printf("%d������������%d \n", i, fib[i]);
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
		 printf("��%d��ĩ�����ϼƣ�%.2f\n", i, corpus[i]);
	 }
	 _getch();
 }
