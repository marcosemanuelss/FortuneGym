function valida() {
        /* Required message */
        var requiredMsg = "Preencha todos os campos obrigatórios que possuem *.";
        /* E-mail message */
        var mailMsg = "O e-mail informado é inválido!";
        var valid = true;
        $('.bg-tabela').find('.required').each(function (i, elm) {
                /* required */
                if ($(this).hasClass('required') && $.trim($(this).val()) == "") {
                    $(this).removeClass('valid').addClass('invalid');
                    $(this).focus();
                    //MENSAGEM ALERTA PERSONALIZADO
                    mostraPopUpAlert(requiredMsg, '../img/icon-erro.png', false, this.id);
                    valid = false;
                    return false;
                }
                else {
                    $(this).removeClass('invalid').addClass('valid');
                }

                /* radio required */
                if ($(this).attr('type') == 'radio') {
                    var elmname = $(this).attr('name');
                    if (!$('input[name="' + elmname + '"]').is(':checked')) {
                        //MENSAGEM ALERTA PERSONALIZADO
                        mostraPopUpAlert(requiredMsg, '../img/icon-erro.png', false, this.id);
                        valid = false;
                        return false;
                    }
                }
                else {
                    $(this).removeClass('invalid').addClass('valid');
                }

                /* checkbox required */
                if ($(this).attr('type') == 'checkbox') {
                    var elmname = $(this).attr('name');
                    if (!$(this).is(':checked')) {
                        //MENSAGEM ALERTA PERSONALIZADO
                        mostraPopUpAlert(requiredMsg, '../img/icon-erro.png', false, this.id);
                        valid = false;
                        return false;
                    }
                }
                else {
                    $(this).removeClass('invalid').addClass('valid');
                }

                /* mail */
                if ($(this).hasClass('mail')) {
                    var er = new RegExp(/^[A-Za-z0-9_\-\.]+@[A-Za-z0-9_\-\.]{2,}\.[A-Za-z0-9]{2,}(\.[A-Za-z0-9])?/);
                    if (!er.test($.trim($(this).val()))) {
                        $(this).removeClass('valid').addClass('invalid');
                        $(this).select();
                        //MENSAGEM ALERTA PERSONALIZADO
                        mostraPopUpAlert(mailMsg, '../img/icon-erro.png', false, this.id);
                        valid = false;
                        return false;
                    }
                    else {
                        $(this).removeClass('invalid').addClass('valid');
                    }
                }
        });
        return valid;
        
}
