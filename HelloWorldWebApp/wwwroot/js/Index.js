// This JS file now uses jQuery. Pls see here: https://jquery.com/

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();


connection.on("NewTeamMemberAdded", function (name, memberId) {
    console.log(`New team member added: ${name}, ${memberId}`);
    createNewcomer(name, memberId);
});

connection.start().then(function () {
    console.log("signalr connected");
}).catch(function (err) {
    return console.error(err.toString());
});

$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#addMembersButton").click(function () {
        var newcomerName = $("#nameField").val();

        $.ajax({
            url: "/Home/AddTeamMember",
            method: "POST",
            data: {
                teamMember: newcomerName
            },
            success: function (result) {
                // Remember string interpolation
                $("#teamMembers").append(
                    `<li class="member" member-id=${result}>
                        <span class="name" >${newcomerName}</span>
                        <span class="delete fa fa-remove" onclick="deleteMember(${result})"></span>
                        <span class="pencil fa fa-pencil"></span>
                    </li>`);

                $("#nameField").val("");
                document.getElementById("addMembersButton").disabled = true;
            }
        })
    })

    $('#submit').click(function () {
        const id = $('#editClassmate').attr('member-id');
        const newName = $('#classmateName').val();

        $.ajax({
            url: "/Home/UpdateMemberName",
            method: "POST",
            data: {
                memberId: id,
                name: newName
            },
            success: function (result) {
                location.reload();
            }
        })
    });

    $("#teamMembers").on("click", ".pencil", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('member-id');
        var currentName = targetMemberTag.find(".name").text();
        $('#editClassmate').attr("member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal('show');
    })
});

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

    $('#nameField').on('change textInput input', function () {
        var inputVal = this.value;
        if (inputVal != "") {
            document.getElementById("addMembersButton").disabled = false;
        } else {
            document.getElementById("addMembersButton").disabled = true;
        }
    });
}());

(function () {
    $("#clearButton").click(function () {
        document.getElementById("nameField").value = "";
    });
}());


function createNewcomer(name, id) {
    // Remember string interpolation
    $("#teamMembers").append(`
            <li class="member" member-id="${id}">
                <span class="name" >${name}</span>
                <span class="delete fa fa-remove" onclick="deleteMember(@member.Id)"></span>
                <span class="pencil fa fa-pencil"></span>
            </li>`
    );
}
$("#clear").click(function () {
    $("#newcomer").val("");
})