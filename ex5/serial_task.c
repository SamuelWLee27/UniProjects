#include "wramp.h"

//global count variable
int count = 0;

/**
 * Prints a character to SP2.
 *
 * Parameters:
 *   c		The character to print.
 **/
void printChar(int c) {
	//Loop while the TDR bit is not set
	while(!(WrampSp2->Stat & 2));
	
	//Write the character to the Tx register
	WrampSp2->Tx = c;
}

/**
* serial_task() class
*
* prints kernal uptime to sp2 in correct format
*/
void serial_main()
{
	while(1)
	{
		int readValue = 0;
		int printValue = 0;
		int value = 0;
		int minsSec = 0;
		int divide = 100000;
		int i = 0;
		//Loop while the receive bit is not set
		while(!(WrampSp1->Stat & 1));
		
		readValue = WrampSp1->Rx;
		
		count = count % 1000000;
	
		if(readValue == '1')
		{
			
			//get first two values
			for(i = 0; i < 4; i++)
			{
				value = count / divide;
				printValue = value % 10;
				printValue = printValue + '0';
				printChar(printValue);
				divide = divide / 10;
			}
			
			//print dot
			printChar('.');
			
			//get last values
			for(i = 0; i < 2; i++)
			{
				value = count / divide;
				printValue = value % 10;
				printValue = printValue + '0';
				printChar(printValue);
				divide = divide / 10;
			}
			
			//print \r
			printChar('\r');
		}
		else if (readValue == '2')
		{
			//get seconds and mins
			value = count/100;
			value = value/60;
			
			//print first min
			minsSec = value / 10;
			printValue = minsSec % 10;
			printValue = printValue + '0';
			printChar(printValue);
			
			//print second min
			printValue = value % 10;
			printValue = printValue + '0';
			printChar(printValue);
			
			//print dot 
			printChar('.');
			
			//get secs
			value = count/100;
			value = value % 60;
			
			//print seconds
			minsSec = value / 10;
			printValue = minsSec % 10;
			printValue = printValue + '0';
			printChar(printValue);
			
			
			printValue = value % 10;
			printValue = printValue + '0';
			printChar(printValue);
			
			printChar(' ');
			printChar(' ');
			
			//print \r
			printChar('\r');
		}
		else if(readValue == '3')
		{
			//get all values
			for(i = 0; i < 6; i++)
			{
				value = count / divide;
				printValue = value % 10;
				printValue = printValue + '0';
				printChar(printValue);
				divide = divide / 10;
			}
			
			//print \r
			printChar('\r');
		}
		else if(readValue == 'q')
			return;
	}	
		
}
