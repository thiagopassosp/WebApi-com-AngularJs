//Seta o módulo para o AngularJS
var app = angular.module('app', []);
//Cria o controller cliente
app.controller('clienteController', ['$scope', '$http', clienteController]);

//Método para o controller cliente do AngujarJS
function clienteController($scope, $http) {

    //Declaração de variáveis
    $scope.exibeformNovoCliente = false;
    $scope.ocultaTabelaListagemClientes = false;
    $scope.exibeformAlterarCliente = false;

    $scope.BuscarCep = function () {        
        $http({
            method: "GET",
            url: "http://cep.republicavirtual.com.br/web_cep.php?cep= " + $scope.model.cep + "&formato=json"
        }).then(function successCallback(response) {            
            if (response.resultado_txt = 'sucesso - cep completo') {
                $scope.model.endereco = response.data.tipo_logradouro + ' ' + response.data.logradouro;
                $scope.model.cidade = response.data.uf;
                $scope.model.bairro = response.data.bairro;
            }                
        }, function errorCallback(response) {                        
        });
    };

    //Função para exibir o form para cadastro do novo cliente
    $scope.funcformNovoCliente = function () {
        $scope.model = null; // Limpar Campos 
        $scope.exibeformNovoCliente = true;
        $scope.ocultaTabelaListagemClientes = true;
    };

    //Ocultar o form de novo cliente e exibir a listagem
    $scope.funcCancelarCadastro = function () {
        $scope.exibeformNovoCliente = false;
        $scope.ocultaTabelaListagemClientes = false;
    };

    //Cadastrar cliente
    $scope.cadastrarCliente = function () {
        var dataAtual = new Date();
        this.model.data_cadastro = dataAtual;
        $http.post('http://localhost:61017/api/Clientes/Postcliente/', this.model).success(function (data) {                        
            alert("Cliente cadastrado com sucesso.");
            $scope.exibeformNovoCliente = false;
            $scope.ocultaTabelaListagemClientes = false;
            $scope.clientes.push(data);
            $scope.model = null;            
        }).error(function (data) {
            $scope.error = "Erro ao cadastrar o cliente! " + data;
        });
    };

    //Buscar listagem de clientes
    $http.get('http://localhost:61017/api/Clientes/').success(function (data) {
        $scope.clientes = data;
    })
    .error(function () {
        $scope.error = "Erro ao carregar a listagem de clientes!";
    });

    //Função para exibir o form para cadastro do novo cliente
    $scope.funcformEditarCliente = function () {
        $scope.model = this.cliente;
        $scope.exibeformNovoCliente = false;
        $scope.ocultaTabelaListagemClientes = true;
        $scope.exibeformAlterarCliente = true;
    };

    //Ocultar o form de novo cliente e exibir a listagem
    $scope.funcCancelarEdicao = function () {
        $scope.exibeformNovoCliente = false;
        $scope.ocultaTabelaListagemClientes = false;
        $scope.exibeformAlterarCliente = false;
    };

    //Editar cliente
    $scope.editarCliente = function () {
        var cli = this.model;
        $http.put('http://localhost:61017/api/Clientes/Putcliente/' + cli.idcliente, cli).success(function (data) {
            alert("Cliente alterado com sucesso.");
            $scope.exibeformNovoCliente = false;
            $scope.ocultaTabelaListagemClientes = false;
            $scope.exibeformAlterarCliente = false;
        }).error(function (data) {
            $scope.error = "Erro ao alterar o cliente! " + data;
        });
    };

    //Deletar cliente
    $scope.deletarCliente = function () {
        var id = this.cliente.idcliente;
        $http.delete('http://localhost:61017/api/Clientes/Deletecliente/' + id).success(function (data) {
            alert("Cliente deletado com sucesso.");
            $.each($scope.clientes, function (i) {
                if ($scope.clientes[i].idcliente === id) {
                    $scope.clientes.splice(i, 1);
                    return false;
                }
            });
        }).error(function (data) {
            $scope.error = "Erro ao deletar o cliente." + data;
        });
    };

}