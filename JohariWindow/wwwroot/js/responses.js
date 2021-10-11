function validateCheckboxes() {

    var total = 0;
    var positiveTotal = 0;
    var negativeCBoxSize = document.getElementsByClassName("negativeCBox").length;
    var positiveCBoxSize = document.getElementsByClassName("positiveCBox").length;
   

    for (var i = 0; i < negativeCBoxSize; i++) {
       
        if (document.getElementsByClassName("negativeCBox")[i].checked) {
            
            total = total + 1;
           
        }
      
    }
    if (total != 7) {


        alert("Please Select  seven negative attributes and twelve positive attibutes" );

        return false;

    }
    for (var i = 0; i < positiveCBoxSize; i++) {
        if (document.getElementsByClassName("positiveCBox")[i].checked) {
            positiveTotal = positiveTotal + 1;
             
        }
       
    }
    if (positiveTotal != 12) {
        alert("Please Select  twelve positive attributes" );

        return false;

    }
 
    return true;
}