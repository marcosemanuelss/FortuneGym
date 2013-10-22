//ATUALIZAR BROWSER 
function fechar()
{
    jQuery('#browser').hide();
}

jQuery(document).ready(function () {

    var version = jQuery.browser.version; //PEGA VERSION DO BROWSER
    //IE
    if (jQuery.browser.msie) {
        if (version < 9) {
            jQuery('#browser').css('display', 'block');
            // jQuery('#browser').append('<p>Para melhor visualização desse site, <a href="" target="_blank" style="color:#fff;">clique aqui</a> e atualize seu browser.</p>');
            jQuery('#browser').append('<div class="atualize"><p>Atualize seu internet explorer para acessar o Sistema!</p> </div>');

//            <a href="http://windows.microsoft.com/pt-BR/internet-explorer/products/ie/home" target="_blank" style="color:#fff;"><img src="../img/browser/explorer.png" alt="Internet Explorer"/></a>
            //Bloqueia btn de entrar
            document.getElementById('btnEntrar').disabled = true;
        }
    }
});

//Caso queira colocar um btn X de fechar a mensagem só colocar esse link no append acima.
//<a href="" onclick="fechar()" title="fechar" class="fechar">X</a>