function chkcontrol(j) {
 
    var total = 0;
    for (var i = 0; i < document.getElementsByClassName("negativeCBox").length  ; i++) {
        if (document.getElementsByClassName("negativeCBox")[i].checked) {
            total = total + 1;
        }
        if (total > 3) {
            alert("Please Select only three")
            document.getElementsByClassName("negativeCBox")[j].checked = false;
            return false;
        }
    }
}