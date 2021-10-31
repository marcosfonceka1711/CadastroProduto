
RemoverTodasMensagensValidacao();


function Gravar() {

    RemoverTodasMensagensValidacao();


    var Descricao = $("#nome").val();
    var Estoque = $("#estoque").val();
    var Preco = $("#valor").val();

    var temValidacao = false;

    if (!Descricao) {
        MensagemErro('O campo Nome é obrigatório', $("#nome"));
        temValidacao = true;
    }

    if (!Estoque) {
        MensagemErro('O campo estoque é obrigatório', $("#estoque"));
        temValidacao = true;
    }

    if (!Preco) {
        MensagemErro('O campo valor é obrigatório', $("#valor"));
        temValidacao = true;
    } else {
        if (Preco < 0) {
            MensagemErro('O campo valor não pode ser menor que zero', $("#valor"));
            temValidacao = true;
        }
    }

    if (temValidacao) {
        return;
    }

    var produto = {
        Descricao,
        Estoque,
        Preco
    };

    $.ajax("/Cadastro/Cadastrar", {
        type: "POST",
        data: {
            "model": produto
        },
        statusCode: {
            200: function (response) {
                window.location.href = "/Home";
            },
            404: function (response) {
                alert('Alguma coisa aconteceu de errado... tente novamente mais tarde.');
            }
        }
    });

}




//#region Funções de mensagem de validação
function MensagemErro(mensagemErro, elemento) {
    if (elemento.next().is('p[name="erro"]')) {
        elemento.next().text(mensagemErro)
        return;
    }

    if (elemento.is('span') || elemento.is('div')) {
        elemento.css('border', 'solid 1px red');
    }
    else {
        elemento.css('border-color', 'red')
    }

    $("<p name='erro' class='w-100' style='color: red;'>" + mensagemErro + "</p>").insertAfter(elemento);
}

function RemoverMensagemErro(elemento) {
    if (elemento.next().is('p[name="erro"]')) {
        elemento.next().remove()

        if (elemento.is('span') || elemento.is('div')) {
            elemento.css('border', 'solid 0px');
        }
        else {
            elemento.css('border-color', '')
        }
    }
}

function RemoverTodasMensagensValidacao() {
    $("p[name='erro']").remove();
    var inputs = $("[style^='border']");

    inputs.each(function (i, elemento) {
        elemento = $(elemento);
        if (elemento.is('span') || elemento.is('div')) {
            elemento.css('border', 'solid 0px');
        }
        else {
            elemento.css('border-color', '');
        }
    })
    //$("[style^='border']").css('border', 'solid 0px');
}
//#endregion