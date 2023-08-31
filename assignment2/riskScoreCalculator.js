//all varible for needed for classes
var riskScore;
var currentId = "ageGenderSet";
var age;
var gender = "female";
var totalCholesterol = 0;
var HDLCholesterol = 0;
var smoker = false;
var bloodPressure = 0;
var treated = false;
var riskPercent;

/**
 * show(id, msg)
 * 
 * @param {id of element you want to show} id 
 * @param {new question for element id parsed in} msg 
 * hides element in currentId then shows next question with element connected to id
 */
function show(id, msg){
    document.getElementById(currentId).style.display = "none";
    document.getElementById(id).style.display = "block";
    document.getElementById("question").innerHTML = msg;
    currentId = id;
}

/**
 * setAge
 * 
 * sets age from number with id age
 */
function setAge(){
    age = document.getElementById("age").value;
    if(age > 79 || age < 20)
    {
        var msg = "Must be a number between 20 and 79";
        displayError(document.getElementById("age"), msg);
    }
}

/**
 * setGender()
 * 
 * set gender based on radio button clicked that started this event
 */
function setGender(){
    var thisRadio = event.target;
    if(thisRadio.id == "female")
    {
        gender = "female";
    }
    else
    {
        gender = "male";
    }
}

/**
 * setSmoker()
 * 
 * set smoker based on radio button clicked that started this event
 */
function setSmoker(){
    var thisRadio = event.target;
    if(thisRadio.id == "smokeYes")
    {
        smoker = true;
    }
    else
    {
        smoker = false;
    }
}

/**
 * setTreated()
 * 
 * sets if treated based on radio button clicked that started this event
 */
function setTreated(){
    var thisRadio = event.target;
    if(thisRadio.id == "treatedYes")
    {
        treated = true;
    }
    else
    {
        treated = false;
    }
}

/**
 * setCholesterol()
 * 
 * set totalCholesterol or HDL depending on id of element that started the event
 * if less then 0 display error
 */
function setCholesterol()
{
    var thisNumber = event.target;
    if(thisNumber.id == "totalCholesterol")
    {
        totalCholesterol = document.getElementById("totalCholesterol").value;
        if(totalCholesterol < 0)
        {
            var msg = "Must be a positive number";
            displayError(document.getElementById("totalCholesterol"), msg);
        }
    }
    else
    {
        HDLCholesterol = document.getElementById("HDLCholesterol").value;
        if(totalCholesterol < 0)
        {
            var msg = "Must be a positive number";
            displayError(document.getElementById("HDLCholesterol"), msg);
        }
    }
}
/**
 * setBloodPresssure()
 * 
 * set blood pressure if less then 0 display error
 */
function setBloodPressure()
{
    bloodPressure = document.getElementById("bloodPressure").value;
    if(bloodPressure < 0)
    {
        var msg = "Must be a positive number";
        displayError(document.getElementById("bloodPressure"), msg);
    }
}

/**
 * displayError(element, msg)
 * 
 * @param {element that gives error} element 
 * @param {message you want displayed} msg 
 * puts red box arround element passed in the puts a error msg in red after the element passed in
 */
function displayError(element, msg){
    //check if message is already displayed
    if(element.nextSibling.tagName == "SPAN" && element.nextSibling.textContent.trim == msg.trim)
    {
        return;
    }
    //hightlight element and display error
    var msgElement = document.createElement("span");
    msgElement.textContent = msg;
    msgElement.style = "color:red";
    element.parentNode.insertBefore(msgElement, element.nextSibling)
    element.style.border = "solid 1px red";
    
}
/**
 * previous()
 * 
 * goes to the previous question
 */
function previous()
{
    //depending on the element goes to the element before it
    if(currentId == "riskScore")
    {
        show("bloodPressureSet", "Final question, what is your systolic blood pressure?");
        //reset risk score text
        document.getElementById("riskScore").innerHTML = '';
    }
    else if (currentId == "bloodPressureSet")
    {
        show("smokerSet", "Third question, Do you smoke cigarettes?");
    }
    else if(currentId == "smokerSet")
    {
        show("cholesterolSet", "Second question, what are your cholesterol levels?");
    }
    else if(currentId == "cholesterolSet")
    {
        show("ageGenderSet", "First thing you need to do is enter your age and gender.");
    }
}

/**
 * next()
 * 
 * goes to next question
 */
function next()
{
    //checks the current element then goes to the next one
    if(currentId == "ageGenderSet")
    {   //check if data is valid
        if(age > 79 || age < 20)
            return;
        else if(age == null)
        {
            var msg = "Can't be empty";
            displayError(document.getElementById("age"), msg);
        }
        else
        {
            show("cholesterolSet", "Second question, what are your cholesterol levels?");
        }
    }
    else if(currentId == "cholesterolSet")
    {
        if(totalCholesterol < 0 || HDLCholesterol < 0)
        {
            return;
        }
        else
        {
            show("smokerSet", "Third question, Do you smoke cigarettes?");
        }
    }
    else if(currentId == "smokerSet")
    {
        show("bloodPressureSet", "Final question, what is your systolic blood pressure?");
    }
    else if (currentId == "bloodPressureSet")
    {
        getRiskScore();
        riskPercent = getRiskPercent();
        /* didn't do inner html because i like have the gaps between question risk score and buttons 
        looks more profesional */
        //creates paragrah for result
        var para = document.createElement("p");
        var text = document.createTextNode("Your risk percentage is " + riskPercent);
        para.appendChild(text);
        document.getElementById("riskScore").appendChild(para);
        show("riskScore", "Results:");
    }
}

/**
 * femaleAgeScore()
 * 
 * @returns female score for the correct age
 */
function femaleAgeScore()
{
    if(age < 35 && age > 19)
        return -7;
   else if(age < 40 && age > 34)
        return -3;
   else if(age < 45 && age > 39)
        return 0;
   else if(age < 50 && age > 44)
        return 3;
   else if(age < 55 && age > 49)
        return 6;
   else if(age < 60 && age > 54)
        return 8;
   else if(age < 65 && age > 59)
        return 10;
   else if(age < 70 && age > 64)
        return 12;
   else if(age < 75 && age > 69)
        return 14;
   else
        return 16;
}

/**
 * femaleTotalCholesterolScore()
 * 
 * @returns returns score for female total cholesterol based on age and total cholesterol
 */
function femaleTotalCholesterolScore()
{
    if(age > 19 && age < 40)
    {
        if(totalCholesterol < 160)
            return 0;
        else if(totalCholesterol < 200 && totalCholesterol > 159)
            return 4;
        else if(totalCholesterol < 240 && totalCholesterol > 199)
            return 8;
        else if(totalCholesterol < 280 && totalCholesterol > 239)
            return 11;
        else
            return 13;    
    }
    else if(age > 39 && age < 50)
    {
        if(totalCholesterol < 160)
            return 0;
        else if(totalCholesterol < 200 && totalCholesterol > 159)
            return 3;
        else if(totalCholesterol < 240 && totalCholesterol > 199)
            return 6;
        else if(totalCholesterol < 280 && totalCholesterol > 239)
            return 8;
        else
            return 10;    
    }
    else if(age > 49 && age < 60)
    {
        if(totalCholesterol < 160)
            return 0;
        else if(totalCholesterol < 200 && totalCholesterol > 159)
            return 2;
        else if(totalCholesterol < 240 && totalCholesterol > 199)
            return 4;
        else if(totalCholesterol < 280 && totalCholesterol > 239)
            return 5;
        else
            return 7;    
    }
    else if(age > 59 && age < 70)
    {
        if(totalCholesterol < 160)
            return 0;
        else if(totalCholesterol < 200 && totalCholesterol > 159)
            return 1;
        else if(totalCholesterol < 240 && totalCholesterol > 199)
            return 2;
        else if(totalCholesterol < 280 && totalCholesterol > 239)
            return 3;
        else
            return 4;    
    }
    else if(age > 69 && age < 80)
    {
        if(totalCholesterol < 160)
            return 0;
        else if(totalCholesterol < 240 && totalCholesterol > 159)
            return 1;
        else 
            return 2;    
    }
}

/**
 * femaleSmokerScore()
 * 
 * @returns female smoker score based on age and if they are a smoker
 */
function femaleSmokerScore()
{
    if(smoker)
    {
        if(age > 19 && age < 40)
            return 9;
        else if(age > 39 && age < 50)
            return 7;
        else if(age > 49 && age < 60)
            return 4;
        else if(age > 59 && age < 70)
            return 2;
        else if(age > 69 && age < 80)
            return 1;
    }
    else
        return 0;
}

/**
 * femaleBloodPressureScore()
 * 
 * @returns female score returned based on blood pressure and if treated
 */
function femaleBloodPressureScore()
{
    if(treated)
    {
        if(bloodPressure < 120)
            return 0;
        else if(bloodPressure < 130 && bloodPressure > 119)
            return 3;
        else if(bloodPressure < 140 && bloodPressure > 129)
            return 4;
        else if(bloodPressure < 160 && bloodPressure > 139)
            return 5;
        else if(bloodPressure > 159)
            return 6;
    }
    else
    {
        if(bloodPressure < 120)
            return 0;
        else if(bloodPressure < 130 && bloodPressure > 119)
            return 1;
        else if(bloodPressure < 140 && bloodPressure > 129)
            return 2;
        else if(bloodPressure < 160 && bloodPressure > 139)
            return 3;
        else if(bloodPressure > 159)
            return 4;
    }
}

/**
 * maleAgeScore()
 * 
 * @returns male score for correct age
 */
function maleAgeScore()
{
    if(age < 35 && age > 19)
        return -9;
   else if(age < 40 && age > 34)
        return -4;
   else if(age < 45 && age > 39)
        return 0;
   else if(age < 50 && age > 44)
        return 3;
   else if(age < 55 && age > 49)
        return 6;
   else if(age < 60 && age > 54)
        return 8;
   else if(age < 65 && age > 59)
        return 10;
   else if(age < 70 && age > 64)
        return 11;
   else if(age < 75 && age > 69)
        return 12;
   else
        return 13;
}

/**
 * maleTotalCholesterolScore()
 * 
 * @returns returns score for male total cholesterol based on age and total cholesterol
 */
function maleTotalCholesterolScore()
{
    if(age > 19 && age < 40)
    {
        if(totalCholesterol < 160)
            return 0;
        else if(totalCholesterol < 200 && totalCholesterol > 159)
            return 4;
        else if(totalCholesterol < 240 && totalCholesterol > 199)
            return 7;
        else if(totalCholesterol < 280 && totalCholesterol > 239)
            return 9;
        else
            return 11;    
    }
    else if(age > 39 && age < 50)
    {
        if(totalCholesterol < 160)
            return 0;
        else if(totalCholesterol < 200 && totalCholesterol > 159)
            return 3;
        else if(totalCholesterol < 240 && totalCholesterol > 199)
            return 5;
        else if(totalCholesterol < 280 && totalCholesterol > 239)
            return 6;
        else
            return 8;    
    }
    else if(age > 49 && age < 60)
    {
        if(totalCholesterol < 160)
            return 0;
        else if(totalCholesterol < 200 && totalCholesterol > 159)
            return 2;
        else if(totalCholesterol < 240 && totalCholesterol > 199)
            return 3;
        else if(totalCholesterol < 280 && totalCholesterol > 239)
            return 4;
        else
            return 5;    
    }
    else if(age > 59 && age < 70)
    {
        if(totalCholesterol < 160)
            return 0;
        else if(totalCholesterol < 240 && totalCholesterol > 159)
            return 1;
        else if(totalCholesterol < 280 && totalCholesterol > 239)
            return 2;
        else
            return 3;    
    }
    else if(age > 69 && age < 80)
    {
        if(totalCholesterol < 240)
            return 0;
        else 
            return 1;    
    }
}

/**
 * maleSmokerScore()
 * 
 * @returns male smoker score based on age and if they are a smoker
 */
function maleSmokerScore()
{
    if(smoker)
    {
        if(age > 19 && age < 40)
            return 8;
        else if(age > 39 && age < 50)
            return 5;
        else if(age > 49 && age < 60)
            return 3;
        else if(age > 59 && age < 80)
            return 1;
    }
    else
        return 0;
}

/**
 * maleBloodPressureScore()
 * 
 * @returns male score returned based on blood pressure and if treated
 */
function maleBloodPressureScore()
{
    if(treated)
    {
        if(bloodPressure < 120)
            return 0;
        else if(bloodPressure < 130 && bloodPressure > 119)
            return 1;
        else if(bloodPressure < 160 && bloodPressure > 129)
            return 2;
        else if(bloodPressure > 159)
            return 3;
    }
    else
    {
        if(bloodPressure < 130)
            return 0;
        else if(bloodPressure < 160 && bloodPressure > 129)
            return 1;
        else if(bloodPressure > 159)
            return 2;
    }
}

/**
 * HDLCholesterol()
 * 
 * @returns score for HDL cholesterol
 */
function HDLCholesterolScore()
{
    if(HDLCholesterol > 59)
        return -1;
    else if(HDLCholesterol > 49 && HDLCholesterol < 60)
        return 0;
    else if(HDLCholesterol > 39 && HDLCholesterol < 50)
        return 1;
    else if(HDLCholesterol < 40)
        return 2;
}

/**
 * getRiskScore()
 * 
 * sets riskScore by checking gender then adds all the scores together
 */
function getRiskScore()
{
    riskScore = 0;
    if(gender == "female")
    {
        riskScore = riskScore + femaleAgeScore() + femaleTotalCholesterolScore()
        + femaleSmokerScore() + HDLCholesterolScore() + femaleBloodPressureScore();
    }
    else
    {
        riskScore = riskScore + maleAgeScore() + maleTotalCholesterolScore() 
        + maleSmokerScore() + HDLCholesterolScore() + maleBloodPressureScore();
    }
}

/**
 * getRiskPercent()
 * 
 * @returns returns risk percent based on the risk score
 */
function getRiskPercent()
{
    if(gender == "female")
    {
        if(riskScore < 9)
            return "<1%";
        else if(riskScore > 8 && riskScore < 13)
            return "1%";
        else if(riskScore == 13 || riskScore == 14)
            return "2%";
        else if(riskScore == 15)
            return "3%";
        else if(riskScore == 16)
            return "4%";
        else if(riskScore == 17)
            return "5%";
        else if(riskScore == 18)
            return "6%";
        else if(riskScore == 19)
            return "8%";
        else if(riskScore == 20)
            return "11%";
        else if(riskScore == 21)
            return "14%";
        else if(riskScore == 22)
            return "17%";
        else if(riskScore == 23)
            return "22%";
        else if(riskScore == 24)
            return "27%";
        else
            return "Over 30%";
    }
    else
    {
        if(riskScore < 1)
            return "<1%";
        else if(riskScore > 0 && riskScore < 5)
            return "1%";
        else if(riskScore == 6 || riskScore == 5)
            return "2%";
        else if(riskScore == 7)
            return "3%";
        else if(riskScore == 8)
            return "4%";
        else if(riskScore == 9)
            return "5%";
        else if(riskScore == 10)
            return "6%";
        else if(riskScore == 11)
            return "8%";
        else if(riskScore == 12)
            return "10%";
        else if(riskScore == 13)
            return "12%";
        else if(riskScore == 14)
            return "16%";
        else if(riskScore == 15)
            return "20%";
        else if(riskScore == 16)
            return "25%";
        else
            return "Over 30%";
    }
}
/**
 * reset()
 * 
 * reset the page to original
 */
function reset()
{
    location.reload();
}