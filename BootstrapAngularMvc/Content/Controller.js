﻿app.controller("myCntrl", function ($scope, myService) {
    GetAllEmployees();

    //For sorting according to columns
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    //To Get All Records  
    function GetAllEmployees() {
        var getData = myService.getEmployees();

        getData.then(function (emp) {
            $scope.employees = emp.data;
        }, function (emp) {
            alert("Records gathering failed!");
        });
    }
});