
LimparCampos();


$('#termo-pesquisa').on('input', delay(function () {
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
    var filtro = 1;

    //Recuperação valores dos filtros
    var input = document.getElementById('termo-pesquisa');
    descricao = input.value;

    //Recuperação do filtro por Jquery
    filtro = $("#filtros").val();

    //Area de renderização da tabela da pesquisa
    var area = $('#area-tabela');

    //Requisição da pesquisa passando os parâmetros
    $.get('Cadastro/Pesquisar', { descricao: descricao, filtro: filtro }).done(function (data) {
        area.html(data);
    })
}


function LimparCampos() {
    $('#termo-pesquisa').val("");
    $('#filtros').val("1");
    Pesquisar();
}
