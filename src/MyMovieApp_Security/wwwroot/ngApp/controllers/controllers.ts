namespace MyMovieApp_Security.Controllers {

    const apiURL = '/api/movies/search/';

    export class MoviesListController {
        public movies;

        constructor(movieService: MyMovieApp_Security.Services.MovieService) {
            this.movies = movieService.listMovies();
        }
    }


    export class MoviesAddController {
        public movieToCreate;
        public categoryID;
        addMovie() {
            this.movieToCreate.id = 0;
            // this.movieToCreate.CategoryID = this.categoryID;
            this.movieService.save(this.movieToCreate).then(
                () => this.$state.go('Home')
            );
        }

        constructor(private movieService: MyMovieApp_Security.Services.MovieService, private $state: ng.ui.IStateService) { }
    }

    export class MoviesEditController {
        public movieToEdit;

        editMovie() {
            this.movieService.save(this.movieToEdit).then(
                () => this.$state.go('Home')
            );
        }

        constructor(private movieService: MyMovieApp_Security.Services.MovieService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {
            this.movieToEdit = movieService.getMovie($stateParams['id'])
        }
    }



    export class MoviesDeleteController {
        public movieToDelete;

        deleteMovie() {
            this.movieService.deleteMovie(this.movieToDelete.id).then(
                () => this.$state.go('Home')
            );
        }

        constructor(private movieService: MyMovieApp_Security.Services.MovieService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {
            this.movieToDelete = movieService.getMovie($stateParams['id'])
        }
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public search;
        public movies;

        fetch() {
            if (this.search) {
                console.log('searching');
                this.$http.get(apiURL + this.search)
                    .then((results) => {
                        this.movies = results.data;
                    });
            }
        }

        constructor(private $http: ng.IHttpService) { }
    }

}
