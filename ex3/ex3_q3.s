.text
.global main
#modifies switches with buttons then displays 
main:
	lw $11, 0x73001($0) #get value of push button
	
	beqz $11, main #check if button is pressed if not loop
	
	lw $6, 0x73000($0) #get switch value
	
	andi $2, $11, 4 #button two is pressed
	bnez $2, exit #branch to exit if button two is pressed

	andi $2, $11, 1 #button zero is pressed
	bnez $2, display #branch to display if pressed	

	andi $2, $11, 2 #button one is pressed
	bnez $2, buttonOne #branch to button one if pressed	

	j main
	
#if button two pressed flip bits in switch value 	
buttonOne:
	xori $6, $6, 0xffff #flip bits in switch value
	
	j display #go to display
	
#display modified switch values
display:
	
	add $7, $6, $0 #save value so can use it for leds
	
	andi $8, $6, 0xf #get first number
	srli $6, $6, 4 #shift for next number
	sw $8, 0x73009($0) #transmit hex number to ssd location
	
	andi $8, $6, 0xf #get first number
	srli $6, $6, 4 #shift for next number
	sw $8, 0x73008($0) #transmit hex number to ssd location
	
	andi $8, $6, 0xf #get first number
	srli $6, $6, 4 #shift for next number
	sw $8, 0x73007($0) #transmit hex number to ssd location
	
	andi $8, $6, 0xf #get first number
	sw $8, 0x73006($0) #transmit hex number to ssd location

	remi $7, $7, 4 #if check if switch value is divisable by 4
	
	beqz $7, turnOnLED #branch to turn on led if zero
	
	sw $0, 0x7300A($0) #turn off LEDS
	
	j main #loop back to main

#turn on LEDs
turnOnLED:
	addi $7, $0, 0xffff #get value for turned on leds
	
	sw $7, 0x7300A($0) #turn on LEDs
	
	j main #loop back to main
	
		
#exits program
exit:	
	
	jr $ra #exit program
