$(document).ready(function () {

    var buttonVar = $("#buttonCreateUserId");

    buttonVar.click(function () {

        var passwordId = $("#passwordId").val();
        var emailId = $("#emailId").val();
        var phoneId = $("#phoneId").val();
        var nickNameId = $("#nickNameId").val();

        if (passwordId !== "" && emailId !== "" && phoneId !== "" && nickNameId !== "") {
            $.ajax({
                type: "POST",
                url: "https://localhost:7235/User/CreateANewUserMethod",
                data: { Password: passwordId, Email: emailId, Phone: phoneId, NickName: nickNameId },
                dataType: "json",  // Alterado para json, já que você está tratando um objeto JSON
                success: function (response) {
                    // Se a solicitação for feita com sucesso, a resposta representará os dados
                    if ((response.success)) {
                        alert(response.message)
                    }
                    else
                        alert(response.message)
                }
            });
        } else {
            alert("Preencha todos os campos!");
        }
    });
});
