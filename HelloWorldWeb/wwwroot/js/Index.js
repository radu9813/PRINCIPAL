$(document).ready(function () {

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        

        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMemeberHere",
            data: { name: newcomerName}
        })
            .done(function (msg) {
                $("#teamList").append(
                    `<li class="member">
                        <span>
                            ${newcomerName}
                        </span>
                        <span>
                            <i class="update fa fa-pencil" aria-hidden="true"></i>
                        </span>

                        <span>
                            <i class="delete fa fa-times" aria-hidden="true"></i>
                        </span>
                    </li>`);
                $("#nameField").val("");
                $("#teamList").
                document.getElementById("createButton").disabled = true;
            });

       
    })
});

(function () {
 
    $('#nameField').on('change textInput input', function () {
        var inputVal = this.value;
        if (inputVal != "") {
            document.getElementById("createButton").disabled = false;
        } else {
            document.getElementById("createButton").disabled = true;
        }
    });
}());