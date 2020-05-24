function readMore() {
    var dots = document.getElementById("dots");
    var moreText = document.getElementById("more");
    var btnText = document.getElementById("myBtn");

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "Read more";
        moreText.style.display = "none";
    } else {
        dots.style.display = "none";
        btnText.innerHTML = "Read less";
        moreText.style.display = "inline";
    }
}

function searchForm() {
    var id = document.getElementById("id").value;
    if (id == "") {
        document.getElementById("tId").innerHTML = "Please Enter Transaction Id";
        return false;
    }
}

function showPassword() {
    var x = document.getElementById("emp_pass");
    if (x.type == "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

function setLastDate() {
    var today = document.getElementById("issue_date").value;
    var date = new Date(today);
    date.setDate(date.getDate() + 7);
    var dd = date.getDate();
    var mm = date.getMonth() + 1;
    var yyyy = date.getFullYear();
    var lastDate = dd + '-' + mm + '-' + yyyy;
    document.getElementById("last_date").value = lastDate;

}