$(document).ready(() => {
    console.log("Hello bro i am in console");
    $("#forName").hide();
    $("#forEmail").hide();
    $("#forSalary").hide();
    $("#forGender").hide();
    const namepattern = /^[a-zA-Z]+$/;
    const emailpattern = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    const salarypattern = /^(?!0+(?:\.0+)?$)[0-9]+(?:\.[0-9]+)?$/;
    const genderpattern = /^(M|F)$/;
    $("form").submit((e) => {    
        let name = document.getElementById("name").value;
        let email = document.getElementById("email").value;
        let salary = document.getElementById("salary").value;
        let gender = document.getElementById("gender").value;

        if (!namepattern.test(name) || !emailpattern.test(email) || !salarypattern.test(salary) || !genderpattern.test(gender)) {
            e.preventDefault();
            if (!namepattern.test(name)) {
                $("#forName").show();
            } else {
                $("#forName").hide();
            }
            if (!emailpattern.test(email)) {
                $("#forEmail").show();
            } else {
                $("#forEmail").hide();
            }
            if (!salarypattern.test(salary)) {
                $("#forSalary").show();
            } else {
                $("#forSalary").hide();
            }
            if (!genderpattern.test(gender)) {
                $("#forGender").show();
            } else {
                $("#forGender").hide();
            }
        } else {
            return true;
        }
    })
})
