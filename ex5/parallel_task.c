#include "wramp.h"

/**
*parallel_task() class
*
*check what button is press then puts switches value in ssd as base 10, 16 or exits
*/
void parallel_main()
{
	int switches = 0;
	int button = 0;
	int remi = 0;
	
	while(1)
	{
		//Read current switch value from parallel switch register
		switches = WrampParallel->Switches;
		//Read current button value from parallel switch register
		button = WrampParallel->Buttons;
		//button zero base 10 to ssd
		if(button == 0x1)
		{
			//rightmost ssd
			remi = switches % 10;
			WrampParallel->LowerRightSSD = remi;
			switches = switches/10;
			//next ssd
			remi = switches % 10;
			WrampParallel->LowerLeftSSD = remi;
			switches = switches/10;
			//next ssd
			remi = switches % 10;
			WrampParallel->UpperRightSSD = remi;
			switches = switches/10;
			//next sse\d
			remi = switches % 10;
			WrampParallel->UpperLeftSSD = remi;
		}
		//button one base 16 to ssd
		else if(button == 0x2)
		{
			//rightmost ssd
			remi = switches %16;
			WrampParallel->LowerRightSSD = remi;
			switches = switches>>=4;
			//next ssd
			remi = switches %16;
			WrampParallel->LowerLeftSSD = remi;
			switches = switches>>=4;
			//next ssd
			remi = switches %16;
			WrampParallel->UpperRightSSD = remi;
			switches = switches>>=4;
			//next ssd
			remi = switches %16;
			WrampParallel->UpperLeftSSD = remi;
		}
		//button two return
		else if(button == 0x4)
			return; 
			
	}
}
