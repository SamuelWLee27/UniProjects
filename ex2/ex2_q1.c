#include "/courses/compx203/ex2/lib_ex2.h"

/**
* Counts from "start" to "end" (inclusive),
* showing progress on the seven segment displays.
**/
void count(int start, int end)
{
	//checks if resonable number
	if (start >= 0 && start <= 1000 && end >= 0 && end <= 1000)
	{//checks if start is less then end
		if (start < end) 
		{ //loops and counts up displaying the count until start equals end
			while (start <= end) 
			{
				writessd(start);
				
				start++;
				
				delay();
			}
		}	 
		else
		{//loops and counts down displaying the count until start equals end
			while (start >= end)
			{
				writessd(start);
				
				start--;
				
				delay();
			}
		}
	}
}
