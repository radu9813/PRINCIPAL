$(document).ready(function () {

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        var length = $("#teamMembers").children().length;

        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMemeberHere",
            data: { name: newcomerName}
        })
            .done(function (response) {
                var g = response;
                $("#teamList").append(
                    `<li class="member">
                        <span>
                            ${newcomerName}
                        </span>
                        <span>
                            <i class="update fa fa-pencil" aria-hidden="true"></i>
                        </span>

                        <span>
                            <i class="delete fa fa-times" onclick="deleteMember(${g})" aria-hidden="true"></i>
                        </span>
                    </li>`);
                $("#nameField").val("");
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


function deleteMember(index) {


    $.ajax({
        url: "/Home/RemoveMember",
        method: "DELETE",
        data: {
            memberIndex: index
        },
        success: function (result) {
            location.reload();
        }
    })


        
}

(function () {
    $("#clearButton").click(function () {

        document.getElementById("nameField").value = "";
        document.getElementById("createButton").disabled = true;
    });

}());


$('#submit').click(function () {
    const id = $('#editClassmate').attr('member-id');
    const newName = $('#classmateName').val();

    $.ajax({
        url: "/Home/UpdateMemberName",
        method: "PUT",
        data: {
            memberId: id,
            name: newName
        },
        success: function (result) {
            location.reload();
        }
    })
});

$("#teamList").on("click", ".pencil", function () {

   var targetMemberTag = $(this).closest('li');

    var id = targetMemberTag.attr('member-id');

    var currentName = targetMemberTag.find(".name").text();

    $('#editClassmate').attr("member-id", id);

    $('#classmateName').val(currentName);

    $('#editClassmate').modal('show');

})