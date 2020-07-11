$("#logForm").submit(function (e) {
    e.preventDefault();
    $.ajax({
        url: "Login", // Url
        data: {
            "Usuario": $("#Usuario").val(),
            "Contraseña": $("#Contraseña").val()
        },
        type: "post"
    }).done(function (result) {
        if (result != null) {
            if (result == "S") {
                window.location = "UsuarioMainView";
            } else {
                alert("No se encontró al usuario");
            }
        }
    })
});