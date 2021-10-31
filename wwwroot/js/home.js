
$('#TermoPesquisa').on('input', delay(function () {
    Pesquisar();
}));


//Função que dá o delay antes de disparar a pesquisa
function delay(f, delay) {
    var timer = null;
    return function () {
        var context = this, args = arguments;
        clearTimeout(timer);
        timer = window.setTimeout(function () {
            f.apply(context, args);
        },
            delay || 1000);
    };
}


function Pesquisar() {
    //Declaração de Variáveis dos filtros
    var descricao = "";

    //Recuperação valores dos filtros
    var input = document.getElementById('TermoPesquisa');
    descricao = input.value;

    //Area de renderização da tabela da pesquisa
    var area = $('#Tabela');

    //Requisição da pesquisa passando os parâmetros
    $.get('Cor/PesquisarCores', { descricao: descricao }).done(function (data) {
        area.html(data);
    })
}


function LimparCampos() {
    $('#CodigoCor').val("");
    $('#Descricao').val("");
    $('#RgbCor').val("#FFFFFF");
    RemoverTodasMensagensValidacao();
}