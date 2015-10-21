//Cria o controller produto
 app.controller('produtoController', ['$scope', '$http', produtoController]);

 //Método para o controller produto do AngujarJS
 function produtoController($scope, $http) {

    //Declaração de variáveis
    $scope.exibeformNovoProduto = false;
    $scope.ocultaTabelaListagemProdutos = false;
    $scope.exibeformAlterarProduto = false;

    //Função para exibir o form para cadastro do novo produto
    $scope.funcformNovoProduto = function () {
        $scope.exibeformNovoProduto = true;
        $scope.ocultaTabelaListagemProdutos = true;
    };

    //Ocultar o form de novo produto e exibir a listagem
    $scope.funcCancelarCadastro = function () {
        $scope.exibeformNovoProduto = false;
        $scope.ocultaTabelaListagemProdutos = false;
    };

    //Função cadastrar produto
    $scope.cadastrarProduto = function () {
        var dataAtual = new Date();
        this.novoproduto.data_cadastro = dataAtual;
        $http.post('http://localhost:61017/api/Produtos/', this.novoproduto).success(function (data) {
            alert("Produto cadastrado com sucesso.");
            $scope.exibeformNovoProduto = false;
            $scope.ocultaTabelaListagemProdutos = false;
            $scope.produtos.push(data);
            $scope.novoproduto = null;
        }).error(function (data) {
            $scope.error = "Erro ao cadastrar o produto! " + data;
        });
    };

    //Buscar listagem de produtos
    $http.get('http://localhost:61017/api/Produtos/').success(function (data) {
        $scope.produtos = data;
    })
    .error(function () {
        $scope.error = "Erro ao carregar a listagem de produtos!";
    });

    //Função para exibir o form para cadastro do novo produto
    $scope.funcformEditarProduto = function () {
        $scope.produtoAlterar = this.produto;
        $scope.exibeformNovoProduto = false;
        $scope.ocultaTabelaListagemProdutos = true;
        $scope.exibeformAlterarProduto = true;
    };

    //Ocultar o form de novo produto e exibir a listagem
    $scope.funcCancelarEdicao = function () {
        $scope.exibeformNovoProduto = false;
        $scope.ocultaTabelaListagemProdutos = false;
        $scope.exibeformAlterarProduto = false;
    };

    //Editar produto
    $scope.editarProduto = function () {
        var prod = this.produtoAlterar;
        $http.put('http://localhost:61017/api/Produtos/' + prod.idproduto, prod).success(function (data) {
            alert("Produto alterado com sucesso.");
            $scope.exibeformNovoProduto = false;
            $scope.ocultaTabelaListagemProdutos = false;
            $scope.exibeformAlterarProduto = false;
        }).error(function (data) {
            $scope.error = "Erro ao alterar o produto! " + data;
        });
    };

    //Deletar produto
    $scope.deletarProduto = function () {
        var id = this.produto.idproduto;
        $http.delete('http://localhost:61017/api/Produtos/' + id).success(function (data) {
            alert("Produto deletado com sucesso.");
            $.each($scope.produtos, function (i) {
                if ($scope.produtos[i].idproduto === id) {
                    $scope.produtos.splice(i, 1);
                    return false;
                }
            });
        }).error(function (data) {
            $scope.error = "Erro ao deletar o produto." + data;
        });
    };
 }