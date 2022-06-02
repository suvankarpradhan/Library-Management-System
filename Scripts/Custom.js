function readServices() {
    var dots = document.getElementById("dots1");
    var moreText = document.getElementById("more1");
    var btnText = document.getElementById("myBtn1");

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

function readAbout() {
    var dots = document.getElementById("dots2");
    var moreText = document.getElementById("more2");
    var btnText = document.getElementById("myBtn2");

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
            data = JSON.parse(data);
            $("#bookTable tbody").empty();
            var row = "<tr><th>Book Name</th><th>Author Name</th><th>Status</th></tr>";
            $.each(data, function (i, v) {
                let status = v.available_copies > 0 ? "Available" : "Not Available";
                row += "<tr><td>" + v.book_name + "</td><td>" + v.author_name + "</td><td>" + status + "</td></tr> ";
            });
            $("#bookTable").append(row);
        },
        error: function (err) {
            console.error(err);
        }
    })
}

function getBookName() {
    var book_id = document.getElementById("book_id").value;
    $.ajax({
        url: "/Book/GetBookName",
        method: "GET",
        data: "id=" + book_id,
        success: function (data) {
            data = JSON.parse(data);
            if (data != null) {
                document.getElementById("book_name").value = data.book_name;
                if (data.available_copies > 0) {
                    $('#create_transaction_btn').css('display','inline-block');
                    $('#bookAvailableOrNot').css('display', 'none');
                } else {
                    $('#create_transaction_btn').css('display', 'none');
                    $('#bookAvailableOrNot').css('display', 'inline-block');
                }
            } else {
                alert("Invalid Book Id");
                document.getElementById("book_name").value = "";
            }
        },
        error: function (err) {
            console.error(err);
        }
    })
}

function getHistory() {
    var mem_id = document.getElementById("Mid").value;
    document.getElementById("MId").innerHTML = "";
    if (mem_id != "") {
        $.ajax({
            url: "/Transaction/GetHistory",
            method: "GET",
            data: "Mid=" + mem_id,
            success: function (data) {
                if (data == "[]") {
                    $("#historyTable tbody").empty();
                    alert("No History available on this Id.")
                } else {
                    data = JSON.parse(data);
                    $("#historyTable tbody").empty();
                    var row = "<tr><th>Book Name</th><th>Issue Date</th><th>Last Date</th><th>Penalty</th></tr>";
                    $.each(data, function (i, v) {
                        row += "<tr><td>" + v.book_name + "</td><td>" + v.issue_date + "</td><td>" + v.last_date + "</td><td>" + v.penalty + "</td></tr>";
                    });
                    $("#historyTable").append(row);
                }
            },
            error: function (err) {
                console.error(err);
            }
        })
    } else {
        document.getElementById("MId").innerHTML = "Please Enter Your Membership Id";
        $("#historyTable tbody").empty();
    }
}

function search() {
    var id = document.getElementById("id").value;
    if (id == "") {
        document.getElementById("tId").innerHTML = "Please Enter Transaction Id";
    } else {
        $.ajax({
            url: "/Transaction/search",
            method: "GET",
            data: "id=" + id,
            success: function (data) {
                data = JSON.parse(data);
                if (data == null) {
                    document.getElementById("edit").type = "hidden";
                    alert("Enter a valid Transaction Id");
                } else {
                    var info =
                        "<p><Strong>Transaction Id : </strong>"  + data.trans_id +
                        "<br/><Strong>Employee Id : </strong>" + data.emp_id +
                        "<br/><Strong>Book Id : </strong>" + data.book_id +
                        "<br/><Strong>Book Name : </strong>" + data.book_name +
                        "<br/><Strong>Member Id : </strong>" + data.mem_id +
                        "<br/><Strong>Issue Date : </strong>" + data.issue_date +
                        "<br/><Strong>Return Date : </strong>" + data.return_date +
                        "<br/><Strong>Last Date : </strong>" + data.last_date +
                        "<br/><Strong>Penalty : </strong>" + data.penalty + "</p>" ;
                    $("#traninfo").html(info);
                    $("#tranDetail").modal();
                    document.getElementById("edit").type = "submit";
                }
            },
            error: function (err) {
                console.error(err);
            }
        })
    }
}

function editBtn() {
    document.getElementById("tId").innerHTML = "";
    document.getElementById("edit").type = "hidden";
}

function getBookDetail(id) {
    $.ajax({
        url: "/Book/bookDetails",
        method: "GET",
        data: "id=" + id,
        success: function (data) {
            data = JSON.parse(data);
            let info = "<strong>Book Name : </strong>" + data.book_name +
                "<br/><strong>Author Name : </strong>" + data.author_name +
                "<br/><strong>Category : </strong>" + data.category +
                "<br/><strong>Total Copy : </strong>" + data.copies +
                "<br/><strong>Available Copy : </strong>" + data.available_copies ;
            $("#bookinfo").html(info);
            $("#bookDetail").modal();
        },
        error: function (err) {
            console.error(err);
        }
    })
}

function getMemBerDetail(id) {
    $.ajax({
        url: "/Member/memberDetails",
        method: "GET",
        data: "id=" + id,
        success: function (data) {
            data = JSON.parse(data);
            let info = "<p><strong>Name : </strong>" + data.mem_name +
                "<br/><strong>Email : </strong>" + data.mem_email +
                "<br/><strong>Phone : </strong>" + data.mem_phone +
                "<br/><strong>Address : </strong>" + data.mem_add + "</p>";
            $("#meminfo").html(info);
            $("#memDetail").modal();
        },
        error: function (err) {
            console.error(err);
        }
    })
}

function getEmployeeDetail(id) {
    $.ajax({
        url: "/Employee/employeeDetails",
        method: "GET",
        data: "id=" + id,
        success: function (data) {
            data = JSON.parse(data);
            let info = "<p><strong>Name : </strong>" + data.emp_name +
                "<br/><strong>Email : </strong>" + data.emp_email +
                "<br/><strong>Phone : </strong>" + data.emp_phone +
                "<br/><strong>Username : </strong>" + data.username +
                "<br/><strong>Role : </strong>" + data.role +
                "<br/><strong>Password : </strong>" + data.emp_pass +
                "<br/><strong>Address : </strong>" + data.emp_add + "</p>";
            $("#empinfo").html(info);
            $("#empDetail").modal();
        },
        error: function (err) {
            console.error(err);
        }
    })
}