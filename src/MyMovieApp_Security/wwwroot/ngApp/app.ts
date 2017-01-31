namespace MyMovieApp_Security {

    angular.module('MyMovieApp_Security', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('Home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: MyMovieApp_Security.Controllers.MoviesListController,
                controllerAs: 'controller'
            })
            .state('Add', {
                url: '/addMovie',
                templateUrl: '/ngApp/views/addMovie.html',
                controller: MyMovieApp_Security.Controllers.MoviesAddController,
                controllerAs: 'controller'
            })
            .state('Edit', {
                url: '/editMovie/:id',
                templateUrl: '/ngApp/views/editMovie.html',
                controller: MyMovieApp_Security.Controllers.MoviesEditController,
                controllerAs: 'controller'
            })
            .state('Delete', {
                url: '/deleteMovie/:id',
                templateUrl: '/ngApp/views/deleteMovie.html',
                controller: MyMovieApp_Security.Controllers.MoviesDeleteController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: MyMovieApp_Security.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: MyMovieApp_Security.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: MyMovieApp_Security.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: MyMovieApp_Security.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: MyMovieApp_Security.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });


    angular.module('MyMovieApp_Security').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('MyMovieApp_Security').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });



}
