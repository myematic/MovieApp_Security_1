namespace MyMovieApp_Security.Services {

    export class MovieService {
        private MovieResource;

        public listMovies() {
            return this.MovieResource.query();
        }

        public save(movie) {
            return this.MovieResource.save(movie).$promise;
        }

        public getMovie(id) {
            return this.MovieResource.get({ id: id });
        }

        public deleteMovie(id: number) {
            return this.MovieResource.delete({ id: id }).$promise;
        }

        constructor($resource: ng.resource.IResourceService) {
            this.MovieResource = $resource('/api/movies/:id');
        }
    }

    angular.module('MyMovieApp_Security').service('movieService', MovieService);



}
