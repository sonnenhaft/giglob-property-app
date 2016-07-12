var gulp = require('gulp');

var src = {
    js: 'app/**/*.js',
    scss: 'app/**/*.scss',
    css: 'app/**/*.css',
    html: 'app/**/*.html'
};

gulp.task('connect:localhost', ['sass:reload'], function() {
    var browserSync = require('browser-sync');
    var reload = browserSync.reload;

    browserSync({
        server: './'
    });

    gulp.watch(src.scss, ['sass:reload']);
    gulp.watch(src.html).on('change', reload);
    gulp.watch(src.js).on('change', reload);
});

gulp.task('_serve', function () {
    var inject = require('gulp-inject');

    return gulp.src('resources/index.html')
        .pipe(inject(gulp.src([src.js, src.css], {read: false})))
        .pipe(gulp.dest('./'));
});

gulp.task('sass:compile', function () {
    var sass = require('gulp-sass');

    return gulp.src('app/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('app'));
});

gulp.task('sass:watch', function () {
    gulp.watch('app/**/*.scss', ['sass']);
});

gulp.task('sass:reload', function() {
    var sass = require('gulp-sass');
    var browserSync = require('browser-sync');
    var reload = browserSync.reload;

    return gulp.src(src.scss)
        .pipe(sass())
        .pipe(gulp.dest('app'))
        .pipe(reload({stream: true}));
});

gulp.task('bump', function(){
    var bump = require('gulp-bump');

    return gulp.src('./package.json')
        .pipe(bump({type:'patch'}))
        .pipe(gulp.dest('./'));
});

gulp.task('concat', function() {
    var concat = require('gulp-concat');

    return gulp.src(src.js)
        .pipe(concat('app.js'))
        .pipe(gulp.dest('./dist/'));
});

gulp.task('process:templates', function() {
    var ngHtml2Js = require("gulp-ng-html2js");

    gulp.src(src.html)
        .pipe(ngHtml2Js({
            moduleName: 'templates',
            rename: function (templateUrl, templateFile) {
                return 'app/' + templateUrl;
            }
        }))
        .pipe(gulp.dest('./dist'));
});

gulp.task('minify:css', function() {
    var cleanCSS = require('gulp-clean-css');

    return gulp.src(src.css)
        .pipe(cleanCSS())
        .pipe(gulp.dest('dist'));
});

gulp.task('uglify', function() {
    var uglify = require('gulp-uglify');

    return gulp.src('dist/app.js')
        .pipe(uglify())
        .pipe(gulp.dest('dist'));
});

gulp.task('annotate', function () {
    var ngAnnotate = require('gulp-ng-annotate');

    return gulp.src('src/app.js')
        .pipe(ngAnnotate())
        .pipe(gulp.dest('dist'));
});

gulp.task('dev', function() {
    var runSequence = require('run-sequence');

    return runSequence('sass:compile', '_serve', 'connect:localhost');
});