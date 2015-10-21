//Cria o controller pedido cabeçalho
app.controller('pedidoCabecalhoController', ['$scope', '$http', pedidoCabecalhoController]);


//Método para o controller pedido cabeçalho
function pedidoCabecalhoController($scope, $http) {

    //Declaração de variáveis
    $scope.ocultaTabelaListagempedidoCabecalhos = false;
    $scope.exibeformAlterarpedidoCabecalho = false;

    //Buscar listagem de pedido cabeçalho
    $http.get('http://localhost:61017/api/PedidosCabecalho/').success(function (data) {
        $scope.pedidoCabecalhos = data;
    })
    .error(function () {
        $scope.error = "Erro ao carregar a listagem de pedidos!";
    });

    //Função para exibir o form para editar pedido
    $scope.funcformEditarpedidoCabecalho = function () {
        $scope.pedidoCabecalhoAlterar = this.pedidoCabecalho;
        $scope.ocultaTabelaListagempedidoCabecalhos = true;
        $scope.exibeformAlterarpedidoCabecalho = true;
    };

    //Ocultar o form de edição de pedido e exibir a listagem
    $scope.funcCancelarEdicao = function () {
        $scope.ocultaTabelaListagempedidoCabecalhos = false;
        $scope.exibeformAlterarpedidoCabecalho = false;
    };

    //Editar o status do pedido cabeçalho
    $scope.editarpedidoCabecalho = function () {
        var ped = this.pedidoCabecalhoAlterar;
        $http.put('http://localhost:61017/api/PedidosCabecalho/' + ped.idpedido_cabecalho, ped).success(function (data) {
            alert("Pedido alterado com sucesso.");
            $scope.ocultaTabelaListagempedidoCabecalhos = false;
            $scope.exibeformAlterarpedidoCabecalho = false;
        }).error(function (data) {
            $scope.error = "Erro ao alterar o pedido! " + data;
        });
    };

    //Deletar pedido
    $scope.deletarpedidoCabecalho = function () {
        var id = this.pedidoCabecalho.idpedido_cabecalho;
        $http.delete('http://localhost:61017/api/PedidosCabecalho/' + id).success(function (data) {
            alert("Pedido deletado com sucesso.");
            $.each($scope.pedidoCabecalhos, function (i) {
                if ($scope.pedidoCabecalhos[i].idpedidoCabecalho === id) {
                    $scope.pedidoCabecalhos.splice(i, 1);
                    return false;
                }
            });
        }).error(function (data) {
            $scope.error = "Erro ao deletar o pedido." + data;
        });
    };

}
