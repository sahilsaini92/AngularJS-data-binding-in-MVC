app.service("myService", function ($http) {

    //get All Employee
    this.getEmployees = function () {
        return $http.get("/Employee/getAll");
    };
});