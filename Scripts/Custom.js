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

function penaltyCalculate() {
    var returnDate = document.getElementById("return_date").value;
    var rDate = new Date(returnDate);

    var lastDate = document.getElementById("last_date").value;
    lastDate = stringToDate(lastDate);
    var lDate = new Date(lastDate);

    var issueDate = document.getElementById("issue_date").value;
    issueDate = stringToDate(issueDate);
    var iDate = new Date(issueDate);

    if (rDate > iDate == 1) {
        if (rDate > lDate == 1) {
            var time = rDate.getTime() - lDate.getTime();
            var days = time / (1000 * 3600 * 24);
            var penalty = days * 2;
            document.getElementById("penalty").value = penalty;
        } else {
            alert("No penalty required.");
            document.getElementById("penalty").value = 0;
        }
    } else {
        alert("You enter a Invalid date or Issue date and Return date is same")
        document.getElementById("penalty").value = 0;
        document.getElementById("return_date").value = issueDate;
    }
}

function stringToDate(date) {
    var dd = (date.charAt(0)).concat(date.charAt(1));
    var mm = (date.charAt(3)).concat(date.charAt(4));
    var yyyy = ((date.charAt(6)).concat(date.charAt(7))).concat((date.charAt(8)).concat(date.charAt(9)));
    date = yyyy + '-' + mm + '-' + dd;
    return date;
}

function getEmpInfo() {
    var user = document.getElementById("User").innerHTML;
    user = user.slice(10, user.length)
    $.ajax({
        url: "/Employee/getInfo",
        method: "GET",
        data: "username=" + user,
        success: function (data) {
            data = JSON.parse(data);
            document.getElementById("emp_id").value = data.emp_id;
        },
        error: function (err) {
            console.error(err);
        }
    })
}

function getBooks() {
    var category = document.getElementById("category").value;
    $.ajax({
        url: "/Book/GetBooks",
        method: "GET",
        data: "category=" + category,
        success: function (data) {
            alert("done");
            data = JSON.parse(data);
            console.log(data);
            $("#bookTable tbody").empty();
            var row = "<tr><th>Book Name</th><th>Author Name</th></tr>";
            $.each(data, function (i, v) {
                row += "<tr><td>" + v.book_name + "</td><td>" + v.author_name + "</td></tr>";
            });
            $("#bookTable").append(row);
        },
        error: function (err) {
            console.error(err);
        }
    })
}