var app = angular.module('app', []);

app.controller('controller', ['$scope', '$http', function controller($scope, $http) {

    $scope.Historicos = [];
    $scope.historico = {};

    $scope.calcular = function () {

        $http.post(window.location + 'api/home', $scope.form)
            .then(function successCallback(res) {
                $scope.historico.valorCompra = res.data.valorCompra;
                $scope.historico.valorPago = res.data.valorPago;
                $scope.historico.troco = res.data.troco.toFixed(2);

                $scope.historico.totalCedulas = res.data.totalCedulas.reduce(function (cedulas, cedula) {
                    if ("R$" + cedula.toFixed(2) in cedulas) {
                        cedulas["R$" + cedula.toFixed(2)]++;
                    }
                    else {
                        cedulas["R$" + cedula.toFixed(2)] = 1;
                    }
                    return cedulas;
                }, {});

                $scope.historico.totalMoedas = res.data.totalMoedas.reduce(function (moedas, moeda) {
                    if ("R$" + moeda.toFixed(2) in moedas) {
                        moedas["R$" + moeda.toFixed(2)]++;
                    }
                    else {
                        moedas["R$" + moeda.toFixed(2)] = 1;
                    }
                    return moedas;
                }, {});

                $scope.form.ValorCompra = "";
                $scope.form.ValorPago = "";

                $scope.Historicos.push(JSON.parse(JSON.stringify($scope.historico)))},
            function errorCallback(err) {
                alert(err.data)

            });  
    }

}]);
