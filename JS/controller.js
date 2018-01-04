/// <reference path="commonFunc.js" />

assignMe

// #region "Login"

    .controller('LoginController', function ($scope, assignFactory) {

        // #region "Variables"

        $scope.login = {
            email: "",
            password: ""
        }

        // #endregion

        // #region "Function"

        $scope.auth = function () {
            myParam = {
                email: $scope.login.email,
                password: $scope.login.password
            }
            assignFactory.call('http://localhost:50060/api/login',
                myParam,
                function (doneResp) {
                    console.log(doneResp);
                    if(doneResp.error == false && doneResp.data != null) {
                        setStorage("user", doneResp.data);
                    }
                },
                function (errResp) {
                    console.log(errResp);

                }, function (failResp) {
                    console.log(failResp);
                })
        }


        // #endregion

    })

// #endregion 

// #region "Signup"

 .controller('SignupController', function ($scope) {
     console.log('callled');
 })

// #endregion

// #region "Dashboard"

 .controller('DashboardController', function ($scope) {
     console.log('callled');
 })

// #endregion
