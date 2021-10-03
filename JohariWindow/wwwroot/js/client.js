function validateForm() {
    var x1 = document.forms["clientForm"]["email1"].value;
    var x2 = document.forms["clientForm"]["email2"].value;
    var x3 = document.forms["clientForm"]["email3"].value;
    var x4 = document.forms["clientForm"]["email4"].value;

    if (x1 == ""||x2==""||x3==""||x4=="") {
        alert("all emails  must be filled out");
        return false;
    }
}