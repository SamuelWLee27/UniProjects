module elevator (
    input        i_clk,
    input        i_rst,
    input        i_button_pressed,
    input  [2:0] i_button_value,
    
    output reg [2:0] o_floor
);
//store values to visit highest floors going up and down 
reg [2:0] high_floor;
reg [2:0] low_floor;
//local parameter to store states
localparam s_IDLE = 2'b00,
           s_UP = 2'b01,
           s_DOWN = 2'b10;
//store state in reg
reg [1:0] state = s_IDLE;

//code for what happens in each state
always @(posedge i_clk) begin
    case(state)
    //stay idle untill need to go to new floor
    s_IDLE: begin
        //if button is pressed check if need to go to new floor
        if (i_button_pressed) begin
            //if height floor go to down state if lower floor 
            //go to up state
            if(i_button_value < o_floor) begin
                state <= s_DOWN;
            end else if (i_button_value > o_floor) begin
                state <= s_UP;
            end
        end
    end
    //state makes elevator go up to the highest floor where
    //a button has been pressed 
    s_UP: begin
        //check if a button for a higher floor has been pressed
        if(high_floor > o_floor) begin
            //go up a floor
            o_floor <= o_floor + 1;
            //if a button for a lower floor hasn't been pressed 
            //keep low floor the same as current floor
            if(low_floor == o_floor)
                low_floor <= low_floor + 1;
        //if the lowest floor needed to be visited is lower then
        //current floor go to down state
        end else if(low_floor != o_floor) begin
            state <= s_DOWN;
            o_floor <= o_floor - 1;
            high_floor <= high_floor - 1;
        end else begin
            //else go to idle state
            state <= s_IDLE;
        end
    end
    //state makes elevator go down to the lowest floor where
    //a button has been pressed
    s_DOWN: begin
        //check if a button for a lower floor has been pressed
        if(low_floor < o_floor) begin
            //if it has go down a floor
            o_floor <= o_floor - 1;
            //if a button for a higher floor hasn't been pressed 
            //keep high floor the same as current floor
            if(high_floor == o_floor)
                high_floor <= high_floor - 1;
        //if the highest floor needed to be visited is higher then
        //current floor go to up state
        end else if(high_floor != o_floor) begin
            state <= s_UP;
            o_floor <= o_floor + 1;
            low_floor <= low_floor + 1;
        end else begin
            //else go idle
            state <= s_IDLE;
        end
    end 
    endcase 
    //if a button is pressed and is not equal to the current floor
    //save to low floor if lower then current else save to high floor
    if (i_button_pressed) begin
        if(i_button_value < low_floor) begin
            low_floor <= i_button_value;
        end else if (i_button_value > high_floor) begin
            high_floor <= i_button_value;
        end
    end
    //if rest is pressed set high floor low floor and current floor to 0
    if(i_rst) begin 
        high_floor = 0;
        low_floor = 0;
        o_floor = 0;
    end    
end
endmodule

