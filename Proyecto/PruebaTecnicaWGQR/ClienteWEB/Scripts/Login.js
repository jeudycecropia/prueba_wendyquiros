$(function () {
    var form = $('#LogIn');

    form.submit(function () {
        var form = $(this);

        //Datos de usuario
        var vUsuario = $('#Usuario').val();
        var vContrasenna = $('#Contrasenna').val();

        //Se crea el json
        var datosUsrPost = { Usuario: vUsuario, Contrasenna: vContrasenna };
        var jsonPost = JSON.stringify(datosUsrPost);
        jQuery.support.cors = true;

        //Se invoca el metodo de login
        $.ajax({
            url: 'http://localhost:4083/Service1/api/login',
            type: 'POST',
            data: jsonPost,
            datatype: "json",
            processData: false,
            contentType: 'application/json; charset=utf-8',
            success: function (result) {

                //Retorna True si la validacion fue correcta
                if (result.resultado) {
                    alert(result.resultado)
                alert('usuario valido')
                    //Se asigna el token a un campo hidden para la utilización en el logout
                    $('#Token').val(result.token);

                    //Se llama al método para obtener los datos del perfil
                    $.ajax({
                        url: "http://localhost:4083/Service1/api/perfil?token=" + result.token,
                        type: 'GET',
                        dataType: 'json',
                        processData: false,
                        contentType: 'application/json; charset=utf-8',
                        success: function (datosUsuario) {

                            //Si la transacción se realizó correctamente
                            if (data.CodError == 0) {
                                //Se obtienen los datos del perfil
                                var perfil = data.perfil;

                                //Se llena la tabla html con la información
                                var strTablaPerfil = "<table border=\"1\";><tr style=\"font-style:italic; font-weight: bold; border-bottom: 2px solid #707070;\"><td>Nombre</td><td>Apellidos</td><td>Email</td><td>Dirección</td><td>Teléfono</td>";
                                strTablaPerfil += "<tr><td>" + perfil.sNombre + "</td><td> " + perfil.sApellidos + "</td><td>" + perfil.sEmail + "</td><td>" + perfil.sDireccion + "</td><td>" + perfil.sTelefono + "</tr>";
                                strTablaPerfil += "</table>";
                                $("#divPerfil").html(strTablaPerfil);

                                //Se reinician las credenciales del usuario
                                $('#usuarioId').val("");
                                $('#password').val("");

                                //Manejo de los div
                                $('#divAutenticacion').fadeOut('slow');
                                $('#divLogout').delay(500).fadeIn('slow');
                                $('#divDatosUsuario').delay(500).fadeIn('slow');
                            }
                            else {
                                //Mensaje de error
                                $(function () {
                                    $("#dialogError").html("<span>" + data.resultado + "</span>");
                                    $("#dialogError").dialog();
                                });
                            }
                        },
                        error: function (x, y, z) {
                            alert(x + '\n' + y + '\n' + z);
                        }
                    });
                }
                else {
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.status);
                        alert(xhr.responseText);
                    }
//                    //Mensaje de error
//                    $(function () {
//                        $("#dialogError").html("<span>" + resultadoPost + "</span>");
//                        $("#dialogError").dialog();
//                    });
                }
            }
        });

        return false;
    });
});